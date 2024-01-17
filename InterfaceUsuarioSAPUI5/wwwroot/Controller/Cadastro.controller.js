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

    //#region 
    const NAMESPACE = "controle.funcionarios.controller.Cadastro";
    const IDADE_MINIMA = 18;
    const DATA_DE_NASCIMENTO_MAXIMA = UI5Date.getInstance((new Date().getFullYear() - IDADE_MINIMA).toString());
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_CPF = "inputCpf";
    const ID_INPUT_TELEFONE = "inputTelefone";
    const ID_INPUT_SALARIO = "inputSalario";
    const ID_INPUT_CALENDARIO = "calendarDataNascimento";
    const ID_TEXT_DATA = "dataText";
    const NOME_MODELO_FUNCIONARIO = "funcionario";
    const STATUS_NULO = "None";
    const STATUS_ERRO = "Error";
    const STATUS_SUCESSO = "Success";
    const PROPRIEDADE_VALUE = "value";
    const STRING_VAZIA = "";
    const duasCasasDecimais = 2;
    const TODA_OCORRENCIA_DE_PONTO = /\./g;
    const TODA_OCORRENCIA_DE_VIRGULA = /,/g;
    const STRING_PONTO = ".";
    const ROTA_DETALHES = "detalhes";

    //#endregion

    return BaseController.extend(NAMESPACE, {
        onInit() {
            const modeloI18n = "i18n";
            const rotaCadastro = "cadastro";
            const rotaEdicao = "edicao"
            this.vincularRota(rotaCadastro, this._aoCoincidirRotaCriacao)
            this.vincularRota(rotaEdicao, this._aoCoincidirRotaEdicao)
            Validacao.definirI18n(this.getOwnerComponent().getModel(modeloI18n).getResourceBundle());
        },

        _aoCoincidirRotaCriacao() {
            this._modeloFuncionario();
            this._modeloData();
            this._limparTela();
        },

        _aoCoincidirRotaEdicao(evento) {
            FuncionarioRepository.obterPorId(evento.getParameter("arguments").id)
                .then(response => response.json())
                .then(response => {
                    this._modeloFuncionario(response);
                    this._modeloData();
                    this._limparTelaEdicao(response);
                });
        },

        _modeloData() {
            const idadeMaxima = 70;
            const modeloCalendario = "calendario";
            const DataDeNascimentoMinima = UI5Date.getInstance((new Date().getFullYear() - idadeMaxima).toString());

            const calendario = {
                maxData: DATA_DE_NASCIMENTO_MAXIMA,
                minData: DataDeNascimentoMinima
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

        _limparTelaEdicao(func) {
            const calendario = this.byId(ID_INPUT_CALENDARIO);
            calendario.removeAllSelectedDates();

            ListaErros.iniciarLista([]);

            this.byId(ID_INPUT_NOME).setValueState(STATUS_NULO);
            this.byId(ID_INPUT_CPF).setValueState(STATUS_NULO);
            this.byId(ID_INPUT_TELEFONE).setValueState(STATUS_NULO);
            this.byId(ID_INPUT_SALARIO).setValueState(STATUS_NULO);
            this.byId(ID_TEXT_DATA).setText(Formatter.formatarDataParaExibir(new Date(func.dataNascimento)));
        },

        _limparTela() {
            const textoErroNomeTamanhoInsuficiente = "erroInputNomeTamanhoInsuficiente";
            const textoErroCpfPreenchidoIncorretamente = "erroInputCpfPreenchidoIncorretamente";
            const textoErroTelefonePreenchidoIncorretamente = "erroInputTelefonePreenchidoIncorretamente";
            const textoErroSalarioValorInsuficiente = "erroInputSalarioValorInsuficiente";
            const textoErroCalendarioDataNaoInformada = "erroInputCalendarioDataNaoInformada";
            const idRadioButtonSolteiro = "solteiro";
            const calendario = this.byId(ID_INPUT_CALENDARIO);
            const dataVazia = "-- / -- / ----";

            calendario.removeAllSelectedDates();
            calendario.focusDate(DATA_DE_NASCIMENTO_MAXIMA);

            ListaErros.iniciarLista([
                {
                    id: ID_INPUT_NOME,
                    erro: this.obterRecursoi18n(textoErroNomeTamanhoInsuficiente)
                },
                {
                    id: ID_INPUT_CPF,
                    erro: this.obterRecursoi18n(textoErroCpfPreenchidoIncorretamente)
                },
                {
                    id: ID_INPUT_TELEFONE,
                    erro: this.obterRecursoi18n(textoErroTelefonePreenchidoIncorretamente)
                },
                {
                    id: ID_INPUT_SALARIO,
                    erro: this.obterRecursoi18n(textoErroSalarioValorInsuficiente)
                },
                {
                    id: ID_INPUT_CALENDARIO,
                    erro: this.obterRecursoi18n(textoErroCalendarioDataNaoInformada)
                }
            ]);

            this.byId(ID_INPUT_NOME).setValueState(STATUS_NULO);
            this.byId(ID_INPUT_CPF).setValueState(STATUS_NULO);
            this.byId(ID_INPUT_TELEFONE).setValueState(STATUS_NULO);
            this.byId(ID_INPUT_SALARIO).setValueState(STATUS_NULO);
            this.byId(idRadioButtonSolteiro).setSelected(true);
            this.byId(ID_TEXT_DATA).setText(dataVazia);
        },

        diaSelecionado(evento) {
            try {
                const primeiroArray = 0;
                let data = evento.getSource().getSelectedDates()[primeiroArray].getStartDate();
                let dataFormatada = Formatter.formatarDataParaSalvar(data);

                this.byId(ID_TEXT_DATA).setText(Formatter.formatarDataParaExibir(data))

                Validacao.dataNascimentoValida(dataFormatada);

                this.modelo(NOME_MODELO_FUNCIONARIO).dataNascimento = dataFormatada;

                ListaErros.removerErrosDaLista(ID_INPUT_CALENDARIO);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(ID_INPUT_CALENDARIO, erro);
            }
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

        _formatarValoresParaSalvar(modelo) {
            modelo.genero = Number(modelo.genero);

            let salarioSemPontos = modelo.salario.replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA);
            modelo.salario = Number(salarioSemPontos.replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO)).toFixed(duasCasasDecimais);
        },

        aoClicarEmSalvar() {
            try {
                const modelo = this.modelo(NOME_MODELO_FUNCIONARIO);
                const propriedadeId = "id";

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

        aoMudarNome(evento) {
            try {
                Validacao.nomeValido(evento.getParameter(PROPRIEDADE_VALUE));
                evento.getSource().setValueState(STATUS_SUCESSO);
                ListaErros.removerErrosDaLista(ID_INPUT_NOME);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(ID_INPUT_NOME, erro);
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(erro);
            }
        },

        aoMudarCpf(evento) {
            try {
                Validacao.cpfValido(evento.getParameter(PROPRIEDADE_VALUE));
                evento.getSource().setValueState(STATUS_SUCESSO);
                ListaErros.removerErrosDaLista(ID_INPUT_CPF);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(ID_INPUT_CPF, erro);
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(erro);
            }
        },

        aoMudarTelefone(evento) {
            try {
                Validacao.telefoneValido(evento.getParameter(PROPRIEDADE_VALUE));
                evento.getSource().setValueState(STATUS_SUCESSO);
                ListaErros.removerErrosDaLista(ID_INPUT_TELEFONE);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(ID_INPUT_TELEFONE, erro);
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(erro);
            }
        },

        aoMudarSalario(evento) {
            try {
                let texto = evento.getSource().getValue();
                if (texto.match(TODA_OCORRENCIA_DE_PONTO)) {
                    texto = texto.replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA);
                }

                Validacao.salarioValido(texto);
                evento.getSource().setValueState(STATUS_SUCESSO);
                ListaErros.removerErrosDaLista(ID_INPUT_SALARIO);

                evento.getSource().setValue(Formatter.salarioText(parseFloat(texto.replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO)).toFixed(duasCasasDecimais)));

            } catch (erro) {
                ListaErros.adicionarErroNaLista(ID_INPUT_SALARIO, erro);
                evento.getSource().setValueState(STATUS_ERRO).setValueStateText(erro);
            }
        }
    })
});