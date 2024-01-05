sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox",
    "../Model/Formatter",
    "sap/ui/core/date/UI5Date"
], function (Controller, History, JSONModel, FuncionarioRepository, MessageBox, Formatter, UI5Date) {
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
            const funcionario = {
                nome: "",
                cpf: "",
                telefone: "",
                salario: "",
                ehCasado: false,
                genero: "",
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
            calendario._oFocusedDate._oUDate.oDate = UI5Date.getInstance()
            this.byId(idRadioButtonSolteiro).setSelected(true)
        },

        diaSelecionado(evento) {
            const primeiroArray = 0
            let data = Formatter.formatarData(evento.getSource().getSelectedDates()[primeiroArray].getStartDate())
            this.getView().getModel().oData.dataNascimento = data
        },

        aoClicarEmSalvar() {
            try {
                const statusCreated = 201
                const cadastro = this;
                const msgSucesso = "msgSucessoAoCadastrar"
                let modelo = this.getView().getModel().oData

                modelo.genero = Number(modelo.genero)
                modelo.salario = Number(modelo.salario)

                FuncionarioRepository.criar(modelo)
                    .then(async response => {
                        if (response.status == statusCreated) {
                            let funcionario = await response.json();
                            MessageBox.success(cadastro._obterRecursoi18n(msgSucesso), {
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
                MessageBox.warning(erro.message)
            }
        },

        aoClicarEmVoltar() {
            const msg_confirmar = "msgConfirmarAcaoVoltar";
            const botaoSim = "botaoSim";
            const botaoNao = "botaoNao";
            const cadastro = this;

            MessageBox.confirm(cadastro._obterRecursoi18n(msg_confirmar), {
                actions: [cadastro._obterRecursoi18n(botaoSim), cadastro._obterRecursoi18n(botaoNao)],
                emphasizedAction: cadastro._obterRecursoi18n(botaoSim),
                onClose(acao) {
                    if (acao == cadastro._obterRecursoi18n(botaoSim)) {
                        cadastro._voltarParaPaginaAnterior()
                    }
                }
            });
        },

        aoClicarEmCancelar() {
            const msg_confirmar = "msgConfirmarAcaoCancelar";
            const botaoSim = "botaoSim";
            const botaoNao = "botaoNao";
            const cadastro = this;

            MessageBox.confirm(cadastro._obterRecursoi18n(msg_confirmar), {
                actions: [cadastro._obterRecursoi18n(botaoSim), cadastro._obterRecursoi18n(botaoNao)],
                emphasizedAction: cadastro._obterRecursoi18n(botaoSim),
                onClose(acao) {
                    if (acao == cadastro._obterRecursoi18n(botaoSim)) {
                        cadastro._voltarParaPaginaAnterior()
                    }
                }
            });
        },

        _voltarParaPaginaAnterior() {
            const rotaListagem = "listagem";
            const paginaAnterior = -1;
            const historico = History.getInstance();
            const hashAnterior = historico.getPreviousHash();

            if (hashAnterior !== undefined) {
                window.history.go(paginaAnterior);
            } else {
                const rota = this.getOwnerComponent().getRouter();
                rota.navTo(rotaListagem, {}, true);
            }
        },

        _irParaTelaDeDetalhes(funcionario) {
            const rotaDetalhes = "detalhes"
            const rota = this.getOwnerComponent().getRouter();
            rota.navTo(rotaDetalhes, {
                id: window.encodeURIComponent(funcionario.id)
            });
        }
    })
});