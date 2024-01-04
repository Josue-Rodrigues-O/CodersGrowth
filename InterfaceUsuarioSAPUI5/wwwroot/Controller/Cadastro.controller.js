sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox"
], function (Controller, History, JSONModel, FuncionarioRepository, MessageBox) {
    'use strict';

    const nameSpace = "controle.funcionarios.controller.Cadastro";
    const ROTA_LISTAGEM = "listagem";
    const ROTA_CADASTRO = "cadastro"

    return Controller.extend(nameSpace, {
        onInit() {
            this._aoCoincidirRota()
        },

        _aoCoincidirRota() {
            const rota = this.getOwnerComponent().getRouter();
            rota.getRoute(ROTA_CADASTRO).attachPatternMatched(this._modeloFuncinario, this);
        },

        _modeloFuncinario() {
            const funcionario = {
                nome: "",
                cpf: "",
                telefone: "",
                salario: "",
                ehCasado: false,
                genero: 0,
                dataNascimento: ""
            }
            let modelo = new JSONModel(funcionario);
            this.getView().setModel(modelo)
        },

        _voltarParaPaginaAnterior() {
            const PAGINA_ANTERIOR = -1;
            const historico = History.getInstance();
            const hashAnterior = historico.getPreviousHash();

            this.byId("solteiro").setSelected(true)
            if (hashAnterior !== undefined) {
                window.history.go(PAGINA_ANTERIOR);
            } else {
                const rota = this.getOwnerComponent().getRouter();
                rota.navTo(ROTA_LISTAGEM, {}, true);
            }
        },

        _obterRecursoi18n(variavel) {
            const i18n = "i18n"
            const recursos_i18n = this.getOwnerComponent().getModel(i18n).getResourceBundle();
            return recursos_i18n.getText(variavel)
        },

        _aoClicarEmSalvar() {
            try {
                const cadastro = this;
                const MSG_SUCESSO = "MSG_SUCESSO_AO_CADASTRAR"
                let modelo = this.getView().getModel().oData
                modelo.genero = Number(modelo.genero)
                modelo.salario = Number(modelo.salario)
                FuncionarioRepository.criar(modelo)
                    .then(async response => {
                        if (response.status == 201) {
                            let funcionario = await response.json();
                            MessageBox.success(this._obterRecursoi18n(MSG_SUCESSO), {
                                onClose() {
                                    cadastro._irParaTelaDeDetalhes(funcionario);
                                }
                            })
                        } else {
                            return Promise.reject(response);
                        }
                    })
                    .catch(async erro => {
                        MessageBox.warning(await erro.text())
                    });

            } catch (erro) {
                MessageBox.warning(erro)
            }
        },

        _aoClicarEmVoltar() {
            const msg_confirmar = "MSG_CONFIRMAR_ACAO_CANCELAR";
            const SIM = "botaoSim";
            const NAO = "botaoNao";
            const cadastro = this;

            MessageBox.confirm(cadastro._obterRecursoi18n(msg_confirmar), {
                actions: [cadastro._obterRecursoi18n(SIM), cadastro._obterRecursoi18n(NAO)],
                emphasizedAction: cadastro._obterRecursoi18n(SIM),
                onClose: function (acao) {
                    if (acao == cadastro._obterRecursoi18n(SIM)) {
                        cadastro._voltarParaPaginaAnterior()
                    }
                }
            });
        },

        _aoClicarEmCancelar() {
            const msg_confirmar = "MSG_CONFIRMAR_ACAO_CANCELAR";
            const SIM = "botaoSim";
            const NAO = "botaoNao";
            const cadastro = this;

            MessageBox.confirm(cadastro._obterRecursoi18n(msg_confirmar), {
                actions: [cadastro._obterRecursoi18n(SIM), cadastro._obterRecursoi18n(NAO)],
                emphasizedAction: cadastro._obterRecursoi18n(SIM),
                onClose: function (acao) {
                    if (acao == cadastro._obterRecursoi18n(SIM)) {
                        cadastro._voltarParaPaginaAnterior()
                    }
                }
            });
        },

        _irParaTelaDeDetalhes(funcionario) {
            const rota = this.getOwnerComponent().getRouter();
            rota.navTo("detalhes", {
                id: window.encodeURIComponent(funcionario.id)
            });
        }
    })
});