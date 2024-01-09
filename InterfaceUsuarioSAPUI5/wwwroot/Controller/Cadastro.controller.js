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
            const modeloFuncionario = "funcionario"
            const funcionario = {
                nome: stringVazia,
                cpf: stringVazia,
                telefone: stringVazia,
                salario: stringVazia,
                ehCasado: false,
                genero: stringVazia,
                dataNascimento: stringVazia
            }
            let modelo = new JSONModel(funcionario);
            this.getView().setModel(modelo, modeloFuncionario)
        },

        _obterRecursoi18n(nomeVariavelI18n) {
            const modeloi18n = "i18n"
            const recursos_i18n = this.getOwnerComponent().getModel(modeloi18n).getResourceBundle();
            return recursos_i18n.getText(nomeVariavelI18n)
        },

        _limparTela() {
            const idRadioButtonSolteiro = "solteiro"
            const idCalendario = "calendarDataNascimento"
            const calendario = this.byId(idCalendario)
            calendario.removeAllSelectedDates()
            calendario.focusDate(DATA_DE_NASCIMENTO_MAXIMA)
            this.byId(idRadioButtonSolteiro).setSelected(true)
        },

        diaSelecionado(evento) {
            const primeiroArray = 0
            let data = Formatter.formatarData(evento.getSource().getSelectedDates()[primeiroArray].getStartDate())
            this.getView().getModel("funcionario").getData().dataNascimento = data
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
                let modelo = this.getView().getModel("funcionario").getData()
                modelo.genero = Number(modelo.genero)
                modelo.salario = parseFloat(modelo.salario).toFixed(2)
                this._criar(modelo, this)
            } catch (erro) {
                MessageBox.warning(erro.message)
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

        changeNome(evento) {
            try {
                Validacao.nomeValido(evento.getParameter("value"))
                evento.getSource().setValueState("Success")
            } catch (erro) {
                evento.getSource().setValueState("Error").setValueStateText(erro);
            }
        },

        changeCpf(evento) {
            try {
                Validacao.cpfValido(evento.getParameter("value"))
                evento.getSource().setValueState("Success")
            } catch (erro) {
                evento.getSource().setValueState("Error").setValueStateText(erro);
            }
        },

        changeTelefone(evento) {
            try {
                Validacao.telefoneValido(evento.getParameter("value"))
                evento.getSource().setValueState("Success")
            } catch (erro) {
                evento.getSource().setValueState("Error").setValueStateText(erro);
            }
        },

        changeSalario(evento) {
            try {
                Validacao.salarioValido(evento.getParameter("value"))
                evento.getSource().setValueState("Success")
            } catch (erro) {
                evento.getSource().setValueState("Error").setValueStateText(erro);
            }
        }
    })
});