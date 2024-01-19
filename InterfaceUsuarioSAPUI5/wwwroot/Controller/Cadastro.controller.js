sap.ui.define([
    "./BaseController",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox",
    "../Model/Formatter",
    "sap/ui/core/date/UI5Date",
    "../Services/Validacao",
    "../Services/ListaErros"
], function (BaseController, FuncionarioRepository, MessageBox, Formatter, UI5Date, Validacao, ListaErros) {
    "use strict";

    const NAMESPACE = "controle.funcionarios.controller.Cadastro";
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_CPF = "inputCpf";
    const ID_INPUT_TELEFONE = "inputTelefone";
    const ID_INPUT_SALARIO = "inputSalario";
    const ID_INPUT_CALENDARIO = "calendarDataNascimento";
    const ID_TEXT_DATA = "dataText";
    const NOME_MODELO_FUNCIONARIO = "funcionario";
    const STATUS_NENHUM = "None";
    const STATUS_ERRO = "Error";
    const STATUS_SUCESSO = "Success";
    const PROPRIEDADE_VALUE = "value";
    const STRING_VAZIA = "";
    const duasCasasDecimais = 2;
    const TODA_OCORRENCIA_DE_PONTO = /\./g;
    const TODA_OCORRENCIA_DE_VIRGULA = /,/g;
    const STRING_PONTO = ".";
    const ROTA_DETALHES = "detalhes";


    return BaseController.extend(NAMESPACE, {
        onInit() {
            const modeloI18n = "i18n";
            const rotaCadastro = "cadastro";
            const rotaEdicao = "edicao"
            this.vincularRota(rotaCadastro, this._aoCoincidirRotaCriacao)
            this.vincularRota(rotaEdicao, this._aoCoincidirRotaEdicao)
            Validacao.definirI18n(this.getOwnerComponent().getModel(modeloI18n).getResourceBundle());
        },

        _modeloData() {
            const idadeMaxima = 70;
            const idadeMinima = 18;
            const modeloCalendario = "calendario";
            const calendario = {
                maxData: UI5Date.getInstance((new Date().getFullYear() - idadeMinima).toString()),
                minData: UI5Date.getInstance((new Date().getFullYear() - idadeMaxima).toString())
            }
            this.modelo(modeloCalendario, calendario)
        },

        _modeloFuncionario(func) {
            let funcionario;
            if (func == (null || undefined)) {
                funcionario = {
                    nome: STRING_VAZIA,
                    cpf: STRING_VAZIA,
                    telefone: STRING_VAZIA,
                    salario: STRING_VAZIA,
                    ehCasado: false,
                    genero: STRING_VAZIA,
                    dataNascimento: STRING_VAZIA
                }
            } else {
                funcionario = {
                    id: func.id,
                    nome: func.nome,
                    cpf: func.cpf,
                    telefone: func.telefone,
                    salario: Formatter.salarioText(func.salario),
                    ehCasado: func.ehCasado,
                    genero: func.genero,
                    dataNascimento: func.dataNascimento
                }
            }
            this.modelo(NOME_MODELO_FUNCIONARIO, funcionario);
        },

        _aoCoincidirRotaCriacao() {
            this._modeloFuncionario();
            this._modeloData();
            this._limparTelaCriacao();
        },

        _limparTelaCriacao() {
            const idRadioButtonSolteiro = "solteiro";
            const calendario = this.byId(ID_INPUT_CALENDARIO);
            const dataVazia = "-- / -- / ----";

            calendario.removeAllSelectedDates();

            this._definirValueStateComoNenhum()
            this.byId(idRadioButtonSolteiro).setSelected(true);
            this.byId(ID_TEXT_DATA).setText(dataVazia);
        },

        _limparTelaEdicao(func) {
            const calendario = this.byId(ID_INPUT_CALENDARIO);
            calendario.removeAllSelectedDates();

            this._definirValueStateComoNenhum()
            this.byId(ID_TEXT_DATA).setText(Formatter.formatarDataParaExibir(new Date(func.dataNascimento)));
        },

        _definirValueStateComoNenhum() {
            this.byId(ID_INPUT_NOME).setValueState(STATUS_NENHUM);
            this.byId(ID_INPUT_CPF).setValueState(STATUS_NENHUM);
            this.byId(ID_INPUT_TELEFONE).setValueState(STATUS_NENHUM);
            this.byId(ID_INPUT_SALARIO).setValueState(STATUS_NENHUM);
        },

        _formatarValoresParaSalvar(modelo) {
            modelo.genero = Number(modelo.genero);
            let salarioSemPontos = modelo.salario.replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA);
            modelo.salario = Number(salarioSemPontos.replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO)).toFixed(duasCasasDecimais);
        },

        _aoCoincidirRotaEdicao(evento) {
            const parametroArgumentos = "arguments";
            const idFuncionario = evento.getParameter(parametroArgumentos).id
            FuncionarioRepository.obterPorId(idFuncionario)
                .then(response => response.json())
                .then(response => {
                    this._modeloFuncionario(response);
                    this._modeloData();
                    this._limparTelaEdicao(response);
                });
        },

        _validarTodosOsCampos(modelo) {
            Validacao.nomeValido(modelo.nome, ID_INPUT_NOME)
            Validacao.cpfValido(modelo.cpf, ID_INPUT_CPF)
            Validacao.telefoneValido(modelo.telefone, ID_INPUT_TELEFONE)
            Validacao.salarioValido(modelo.salario, ID_INPUT_SALARIO)
            Validacao.dataNascimentoValida(modelo.dataNascimento, ID_INPUT_CALENDARIO)
        },

        _criar(modelo, controller) {
            const statusCreated = 201;
            const msgSucesso = "msgSucessoAoCadastrar";
            FuncionarioRepository.criar(modelo)
                .then(async response => {
                    if (response.status == statusCreated) {
                        let funcionario = await response.json();
                        MessageBox.success(controller.obterRecursoi18n(msgSucesso), {
                            onClose() {
                                controller.navegarPara(ROTA_DETALHES, { id: funcionario.id })
                            }
                        });
                    } else {
                        return Promise.reject(response);
                    }
                })
                .catch(async erro => {
                    MessageBox.warning(await erro.text());
                });
        },

        _atualizar(modelo, controller) {
            const statusNoContent = 204;
            const msgSucesso = "msgSucessoAoAtualizar";
            FuncionarioRepository.atualizar(modelo)
                .then(response => {
                    if (response.status == statusNoContent) {
                        MessageBox.success(controller.obterRecursoi18n(msgSucesso), {
                            onClose() {
                                controller.navegarPara(ROTA_DETALHES, { id: modelo.id })
                            }
                        });
                    } else {
                        return Promise.reject(response);
                    }
                })
                .catch(async erro => {
                    MessageBox.warning(await erro.text());
                });
        },

        aoClicarEmSalvar() {
            try {
                const modelo = this.modelo(NOME_MODELO_FUNCIONARIO);
                const propriedadeId = "id";

                this._validarTodosOsCampos(modelo)
                ListaErros.verificarListaDeErros(this);
                this._formatarValoresParaSalvar(modelo);
                let modeloFuncionarioPossuiAtributoId = modelo.hasOwnProperty(propriedadeId);


                if (modeloFuncionarioPossuiAtributoId) {
                    this._atualizar(modelo, this);
                } else {
                    this._criar(modelo, this);
                }
            } catch (erro) {
                MessageBox.warning(erro);
            }
        },

        aoClicarEmVoltar() {
            const msg_confirmar = "msgConfirmarAcaoVoltar";
            this._navegarParaListagem(this.obterRecursoi18n(msg_confirmar), this);
        },

        aoClicarEmCancelar() {
            const msg_confirmar = "msgConfirmarAcaoCancelar";
            this._navegarParaListagem(this.obterRecursoi18n(msg_confirmar), this);
        },

        aoMudarNome(evento) {
            try {
                const erro = Validacao.nomeValido(evento.getParameter(PROPRIEDADE_VALUE), ID_INPUT_NOME);

                if (erro) { throw erro }

                evento.getSource().setValueState(STATUS_SUCESSO);
            } catch (erro) {
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(erro);
            }
        },

        aoMudarCpf(evento) {
            try {
                const erro = Validacao.cpfValido(evento.getParameter(PROPRIEDADE_VALUE), ID_INPUT_CPF);

                if (erro) { throw erro }

                evento.getSource().setValueState(STATUS_SUCESSO);
            } catch (erro) {
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(erro);
            }
        },

        aoMudarTelefone(evento) {
            try {
                const erro = Validacao.telefoneValido(evento.getParameter(PROPRIEDADE_VALUE), ID_INPUT_TELEFONE);

                if (erro) { throw erro }

                evento.getSource().setValueState(STATUS_SUCESSO);
            } catch (erro) {
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(erro);
            }
        },

        aoMudarSalario(evento) {
            try {
                let texto = evento.getSource().getValue();
                if (texto.match(TODA_OCORRENCIA_DE_PONTO)) {
                    texto = texto.replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA);
                }

                const erro = Validacao.salarioValido(texto, ID_INPUT_SALARIO);

                if (erro) { throw erro }
                evento.getSource().setValueState(STATUS_SUCESSO);

                evento.getSource().setValue(Formatter.salarioText(parseFloat(texto.replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO)).toFixed(duasCasasDecimais)));
            } catch (erro) {
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(erro);
            }
        },

        aoSelecionarUmaData(evento) {
            try {
                const primeiroArray = 0;
                let data = evento.getSource().getSelectedDates()[primeiroArray].getStartDate();
                let dataFormatada = Formatter.formatarDataParaSalvar(data);

                this.byId(ID_TEXT_DATA).setText(Formatter.formatarDataParaExibir(data))

                Validacao.dataNascimentoValida(ID_INPUT_CALENDARIO);

                this.modelo(NOME_MODELO_FUNCIONARIO).dataNascimento = dataFormatada;
            } catch (erro) {
                MessageBox.error(erro)
            }
        },

        _navegarParaListagem(mensagem, controller) {
            const rotaListagem = "listagem";

            MessageBox.confirm(mensagem, {
                actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                emphasizedAction: MessageBox.Action.YES,
                onClose(acao) {
                    if (acao == MessageBox.Action.YES) {
                        controller.navegarPara(rotaListagem, {})
                    }
                }
            });
        },
    })
});