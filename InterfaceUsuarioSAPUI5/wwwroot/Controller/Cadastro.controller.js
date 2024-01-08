sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox",
    "../Model/Formatter",
    "sap/ui/core/date/UI5Date",
    "../Services/Validacao",
    "sap/ui/core/ValueState"
], function (Controller, History, JSONModel, FuncionarioRepository, MessageBox, Formatter, UI5Date, Validacao, ValueState) {
    'use strict';

    const NAMESPACE = "controle.funcionarios.controller.Cadastro";

    return Controller.extend(NAMESPACE, {

        onInit() {
            const rotaCadastro = "cadastro"
            const rota = this.getOwnerComponent().getRouter();
            rota.getRoute(rotaCadastro).attachPatternMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota() {
            this._modeloFuncionario()
            this._limparTela()
        },

        _modeloFuncionario() {
            const stringVazia = ""
            const funcionario = {
                nome: stringVazia,
                cpf: stringVazia,
                telefone: stringVazia,
                salario: stringVazia,
                ehCasado: false,
                genero: stringVazia,
                dataNascimento: Formatter.formatarData(UI5Date.getInstance())
            }
            let modelo = new JSONModel(funcionario);
            this.getView().setModel(modelo)
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
            calendario.focusDate(UI5Date.getInstance())
            this.byId(idRadioButtonSolteiro).setSelected(true)
        },

        diaSelecionado(evento) {
            const primeiroArray = 0
            let data = Formatter.formatarData(evento.getSource().getSelectedDates()[primeiroArray].getStartDate())
            this.getView().getModel().getData().dataNascimento = data
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
                let modelo = this.getView().getModel().getData()
                modelo.genero = Number(modelo.genero)
                modelo.salario = Number(modelo.salario)
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
            if(!Validacao.nomeValido(evento.getParameter("value"))){
                evento.getSource().setValueState("Error")
            }else{
                evento.getSource().setValueState("Success")
            }
        }
    })
});