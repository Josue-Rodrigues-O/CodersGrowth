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
    const DATA_DE_NASCIMENTO_MAXIMA = UI5Date.getInstance((new Date().getFullYear() - 18).toString());
    const ID_INPUT_NOME = "inputNome"
    const ID_INPUT_CPF = "inputCpf"
    const ID_INPUT_TELEFONE = "inputTelefone"
    const ID_INPUT_SALARIO = "inputSalario"
    const ID_INPUT_CALENDARIO = "calendarDataNascimento"
    const MODELO_FUNCIONARIO = "funcionario"
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
            const stringVazia = ""
            let funcionario = new JSONModel();
            funcionario.setData({
                nome: stringVazia,
                cpf: stringVazia,
                telefone: stringVazia,
                salario: stringVazia,
                ehCasado: false,
                genero: stringVazia,
                dataNascimento: stringVazia
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
            const idCalendario = "calendarDataNascimento"
            const calendario = this.byId(idCalendario)

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

            this.byId(ID_INPUT_NOME).setValueState("None");
            this.byId(ID_INPUT_CPF).setValueState("None");
            this.byId(ID_INPUT_TELEFONE).setValueState("None");
            this.byId(ID_INPUT_SALARIO).setValueState("None");
            this.byId(ID_INPUT_CALENDARIO).setValueState("None");
            this.byId(idRadioButtonSolteiro).setSelected(true)

            calendario.removeAllSelectedDates()
            calendario.focusDate(DATA_DE_NASCIMENTO_MAXIMA)
        },

        diaSelecionado(evento) {
            try {
                const primeiroArray = 0
                let data = Formatter.formatarData(evento.getSource().getSelectedDates()[primeiroArray].getStartDate())
                this.getView().getModel(MODELO_FUNCIONARIO).getData().dataNascimento = data
                Validacao.dataNascimentoValida(this.getView().getModel(MODELO_FUNCIONARIO).getData().dataNascimento)
                this.removerErrosDaLista(ID_INPUT_CALENDARIO)
            } catch (erro) {
                this.adicionarErroNaLista(ID_INPUT_CALENDARIO, erro)
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
                if (listaDeErros.length) {
                    let erros = ""
                    listaDeErros.forEach((elemento) => {
                        if (elemento.id != ID_INPUT_CALENDARIO) {
                            this.byId(elemento.id).setValueState("Error").setValueStateText(elemento.erro);
                        }
                        erros += elemento.erro + "\n"
                    })
                    throw erros

                } else {
                    let modelo = this.getView().getModel(MODELO_FUNCIONARIO).getData()
                    modelo.genero = Number(modelo.genero)
                    modelo.salario = parseFloat(modelo.salario).toFixed(2)
                    this._criar(modelo, this)
                }

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

        adicionarErroNaLista(id, erro) {
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

        removerErrosDaLista(id) {
            if (listaDeErros.find(x => x.id == id)) {
                let index = listaDeErros.findIndex(x => x.id == id)
                listaDeErros.splice(index, 1);
            }
        },

        changeNome(evento) {
            try {
                Validacao.nomeValido(evento.getParameter("value"))
                evento.getSource().setValueState("Success")
                this.removerErrosDaLista(ID_INPUT_NOME)
            } catch (erro) {
                this.adicionarErroNaLista(ID_INPUT_NOME, erro)
                evento.getSource().setValueState("Error").setValueStateText(this._obterRecursoi18n(erro));
            }
        },

        changeCpf(evento) {
            try {
                Validacao.cpfValido(evento.getParameter("value"))
                evento.getSource().setValueState("Success")
                this.removerErrosDaLista(ID_INPUT_CPF)
            } catch (erro) {
                this.adicionarErroNaLista(ID_INPUT_CPF, erro)
                evento.getSource().setValueState("Error").setValueStateText(this._obterRecursoi18n(erro));
            }
        },

        changeTelefone(evento) {
            try {
                Validacao.telefoneValido(evento.getParameter("value"))
                evento.getSource().setValueState("Success")
                this.removerErrosDaLista(ID_INPUT_TELEFONE)
            } catch (erro) {
                this.adicionarErroNaLista(ID_INPUT_TELEFONE, erro)
                evento.getSource().setValueState("Error").setValueStateText(this._obterRecursoi18n(erro));
            }
        },

        changeSalario(evento) {
            try {
                Validacao.salarioValido(evento.getParameter("value"))
                evento.getSource().setValueState("Success")
                this.removerErrosDaLista(ID_INPUT_SALARIO)
            } catch (erro) {
                this.adicionarErroNaLista(ID_INPUT_SALARIO, erro)
                evento.getSource().setValueState("Error").setValueStateText(this._obterRecursoi18n(erro));
            }
        }
    })
});