sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox",
    "../Model/Formatter",
    "sap/ui/core/date/UI5Date",
    "../Services/Validacao"
], function (Controller, History, JSONModel, FuncionarioRepository, MessageBox, Formatter, UI5Date, Validacao,) {
    'use strict';

    const NAMESPACE = "controle.funcionarios.controller.Cadastro";
    const IDADE_MINIMA = 18
    const DATA_DE_NASCIMENTO_MAXIMA = UI5Date.getInstance((new Date().getFullYear() - IDADE_MINIMA).toString());
    const ID_INPUT_NOME = "inputNome"
    const ID_INPUT_CPF = "inputCpf"
    const ID_INPUT_TELEFONE = "inputTelefone"
    const ID_INPUT_SALARIO = "inputSalario"
    const ID_INPUT_CALENDARIO = "calendarDataNascimento"
    const MODELO_FUNCIONARIO = "funcionario"
    const STATUS_NULO = "None"
    const STATUS_ERRO = "Error"
    const STATUS_SUCESSO = "Success"
    const PROPRIEDADE_VALUE = "value"
    const STRING_VAZIA = ""
    const duasCasasDecimais = 2
    const TODA_OCORRENCIA_DE_PONTO = /\./g
    const TODA_OCORRENCIA_DE_VIRGULA =/,/g 
    const STRING_PONTO = "."
    let listaDeErros;

    return Controller.extend(NAMESPACE, {

        onInit() {
            const rotaCadastro = "cadastro"
            const rota = this.getOwnerComponent().getRouter();
            rota.getRoute(rotaCadastro).attachPatternMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota() {
            this._modeloFuncionario()
            this._modeloData()
            this._limparTela()
        },

        _modeloData() {
            const idadeMaxima = 70
            const modeloCalendario = "calendario"
            const DataDeNascimentoMinima = UI5Date.getInstance((new Date().getFullYear() - idadeMaxima).toString());
            const calendario = new JSONModel();
            calendario.setData({
                maxData: DATA_DE_NASCIMENTO_MAXIMA,
                minData: DataDeNascimentoMinima
            })
            this.getView().setModel(calendario, modeloCalendario);
        },

        _modeloFuncionario() {
            let funcionario = new JSONModel();
            funcionario.setData({
                nome: STRING_VAZIA,
                cpf: STRING_VAZIA,
                telefone: STRING_VAZIA,
                salario: STRING_VAZIA,
                ehCasado: false,
                genero: STRING_VAZIA,
                dataNascimento: STRING_VAZIA
            })
            this.getView().setModel(funcionario, MODELO_FUNCIONARIO)
        },

        _obterRecursoi18n(nomeVariavelI18n) {
            const modeloi18n = "i18n"
            const recursos_i18n = this.getOwnerComponent().getModel(modeloi18n).getResourceBundle();
            return recursos_i18n.getText(nomeVariavelI18n)
        },

        _limparTela() {
            const textoErroNomeTamanhoInsuficiente = "erroInputNomeTamanhoInsuficiente"
            const textoErroCpfPreenchidoIncorretamente = "erroInputCpfPreenchidoIncorretamente"
            const textoErroTelefonePreenchidoIncorretamente = "erroInputTelefonePreenchidoIncorretamente"
            const textoErroSalarioValorInsuficiente = "erroInputSalarioValorInsuficiente"
            const textoErroCalendarioDataNaoInformada = "erroInputCalendarioDataNaoInformada"
            const idRadioButtonSolteiro = "solteiro"
            const calendario = this.byId(ID_INPUT_CALENDARIO)

            calendario.removeAllSelectedDates()
            calendario.focusDate(DATA_DE_NASCIMENTO_MAXIMA)

            listaDeErros = [
                {
                    id: ID_INPUT_NOME,
                    erro: this._obterRecursoi18n(textoErroNomeTamanhoInsuficiente)
                },
                {
                    id: ID_INPUT_CPF,
                    erro: this._obterRecursoi18n(textoErroCpfPreenchidoIncorretamente)
                },
                {
                    id: ID_INPUT_TELEFONE,
                    erro: this._obterRecursoi18n(textoErroTelefonePreenchidoIncorretamente)
                },
                {
                    id: ID_INPUT_SALARIO,
                    erro: this._obterRecursoi18n(textoErroSalarioValorInsuficiente)
                },
                {
                    id: ID_INPUT_CALENDARIO,
                    erro: this._obterRecursoi18n(textoErroCalendarioDataNaoInformada)
                }
            ]

            this.byId(ID_INPUT_NOME).setValueState(STATUS_NULO);
            this.byId(ID_INPUT_CPF).setValueState(STATUS_NULO);
            this.byId(ID_INPUT_TELEFONE).setValueState(STATUS_NULO);
            this.byId(ID_INPUT_SALARIO).setValueState(STATUS_NULO);
            this.byId(idRadioButtonSolteiro).setSelected(true)
        },

        diaSelecionado(evento) {
            try {
                const primeiroArray = 0
                let data = evento.getSource().getSelectedDates()[primeiroArray].getStartDate()
                let dataFormatada = Formatter.formatarData(data)
                Validacao.dataNascimentoValida(dataFormatada)
                this.getView().getModel(MODELO_FUNCIONARIO).getData().dataNascimento = dataFormatada
                this._removerErrosDaLista(ID_INPUT_CALENDARIO)
            } catch (erro) {
                this._adicionarErroNaLista(ID_INPUT_CALENDARIO, erro)
            }
        },

        _criar(modelo, controller) {
            const statusCreated = 201
            const msgSucesso = "msgSucessoAoCadastrar"
            FuncionarioRepository.criar(modelo)
                .then(async response => {
                    if (response.status == statusCreated) {
                        let funcionario = await response.json();
                        MessageBox.success(controller._obterRecursoi18n(msgSucesso), {
                            onClose() {
                                controller._irParaTelaDeDetalhes(funcionario);
                            }
                        })
                    } else {
                        return Promise.reject(response);
                    }
                })
                .catch(async erro => {
                    MessageBox.warning(await erro.text())
                });
        },

        aoClicarEmSalvar() {
            try {
                
                const quebraDeLinha = "\n"
                let salarioSemPontos;
                let modelo;
                if (listaDeErros.length) {
                    let erros = STRING_VAZIA
                    listaDeErros.forEach((elemento) => {
                        if (elemento.id != ID_INPUT_CALENDARIO) {
                            this.byId(elemento.id).setValueState(STATUS_ERRO).setValueStateText(elemento.erro);
                        }
                        erros += elemento.erro + quebraDeLinha
                    })
                    throw erros
                }
                modelo = this.getView().getModel(MODELO_FUNCIONARIO).getData()
                salarioSemPontos = modelo.salario.replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA)
                modelo.genero = Number(modelo.genero)
                modelo.salario = Number(salarioSemPontos.replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO)).toFixed(duasCasasDecimais)
                this._criar(modelo, this)

            } catch (erro) {
                MessageBox.warning(erro)
            }
        },

        aoClicarEmVoltar() {
            const msg_confirmar = "msgConfirmarAcaoVoltar";
            this._voltarParaPaginaAnterior(this._obterRecursoi18n(msg_confirmar), this)
        },

        aoClicarEmCancelar() {
            const msg_confirmar = "msgConfirmarAcaoCancelar";
            this._voltarParaPaginaAnterior(this._obterRecursoi18n(msg_confirmar), this)
        },

        _voltarParaPaginaAnterior(mensagem, controller) {
            const rotaListagem = "listagem";
            const paginaAnterior = -1;
            const historico = History.getInstance();
            const hashAnterior = historico.getPreviousHash();

            MessageBox.confirm(mensagem, {
                actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                emphasizedAction: MessageBox.Action.YES,
                onClose(acao) {
                    if (acao == MessageBox.Action.YES) {


                        if (hashAnterior !== undefined) {
                            window.history.go(paginaAnterior);
                        } else {
                            const rota = controller.getOwnerComponent().getRouter();
                            rota.navTo(rotaListagem, {}, true);
                        }
                    }
                }
            });
        },

        _irParaTelaDeDetalhes(funcionario) {
            const rotaDetalhes = "detalhes"
            const rota = this.getOwnerComponent().getRouter();
            rota.navTo(rotaDetalhes, {
                id: funcionario.id
            });
        },

        _adicionarErroNaLista(id, erro) {
            if (listaDeErros.find(x => x.id == id)) {
                let index = listaDeErros.findIndex(x => x.id == id)
                listaDeErros[index].erro = this._obterRecursoi18n(erro)
            } else {
                listaDeErros.push({
                    id: id,
                    erro: this._obterRecursoi18n(erro)
                })
            }
        },

        _removerErrosDaLista(id) {
            const apenasUmaOcorrencia = 1
            if (listaDeErros.find(x => x.id == id)) {
                let index = listaDeErros.findIndex(x => x.id == id)
                listaDeErros.splice(index, apenasUmaOcorrencia);
            }
        },

        aoMudarNome(evento) {
            try {
                Validacao.nomeValido(evento.getParameter(PROPRIEDADE_VALUE))
                evento.getSource().setValueState(STATUS_SUCESSO)
                this._removerErrosDaLista(ID_INPUT_NOME)
            } catch (erro) {
                this._adicionarErroNaLista(ID_INPUT_NOME, erro)
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(this._obterRecursoi18n(erro));
            }
        },

        aoMudarCpf(evento) {
            try {
                Validacao.cpfValido(evento.getParameter(PROPRIEDADE_VALUE))
                evento.getSource().setValueState(STATUS_SUCESSO)
                this._removerErrosDaLista(ID_INPUT_CPF)
            } catch (erro) {
                this._adicionarErroNaLista(ID_INPUT_CPF, erro)
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(this._obterRecursoi18n(erro));
            }
        },

        aoMudarTelefone(evento) {
            try {
                Validacao.telefoneValido(evento.getParameter(PROPRIEDADE_VALUE))
                evento.getSource().setValueState(STATUS_SUCESSO)
                this._removerErrosDaLista(ID_INPUT_TELEFONE)
            } catch (erro) {
                this._adicionarErroNaLista(ID_INPUT_TELEFONE, erro)
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(this._obterRecursoi18n(erro));
            }
        },

        aoMudarSalario(evento) {
            try {
                let texto = evento.getSource().getValue()
                if (texto.match(TODA_OCORRENCIA_DE_PONTO)) {
                    texto = texto.replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA)
                }

                Validacao.salarioValido(texto)
                evento.getSource().setValueState(STATUS_SUCESSO)
                this._removerErrosDaLista(ID_INPUT_SALARIO)
                
                evento.getSource().setValue(Formatter.salarioText(parseFloat(texto.replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO)).toFixed(duasCasasDecimais)))

            } catch (erro) {
                this._adicionarErroNaLista(ID_INPUT_SALARIO, erro)
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(this._obterRecursoi18n(erro));
            }
        }
    })
});