sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../Model/Formatter",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox"
], function (Controller, JSONModel, Formatter, FuncionarioRepository, MessageBox) {
    "use strict";

    const NAMESPACE = "controle.funcionarios.Controller.Listagem";
    const MODELO_TABELA = "modeloTabelaFuncionarios";
    const STATUS_OK = 200

    return Controller.extend(NAMESPACE, {

        formatter: Formatter,

        onInit() {
            const rotaListagem = "listagem"
            let rota = this.getOwnerComponent().getRouter();
            rota.getRoute(rotaListagem).attachPatternMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota() {
            try {
                FuncionarioRepository.obterTodos()
                    .then(response => {
                        if (response.status == STATUS_OK) {
                            return response.json()
                        }
                        else {
                            return Promise.reject(response)
                        }
                    })
                    .then(response => this.getView().setModel(new JSONModel(response), MODELO_TABELA))
                    .catch(async erro => MessageBox.warning(await erro.text()));
            } catch (erro) {
                MessageBox.warning(erro.message)
            }
        },

        aoPesquisarFiltrarFuncionarios(condicao) {
            try {
                const parametroQuery = "query";
                const stringCondicao = condicao.getParameter(parametroQuery);
                FuncionarioRepository.obterTodos(stringCondicao)
                    .then(response => {
                        if (response.status == STATUS_OK) {
                            return response.json()
                        }
                        else {
                            return Promise.reject(response)
                        }
                    })
                    .then(response => this.getView().setModel(new JSONModel(response), MODELO_TABELA))
                    .catch(async erro => MessageBox.warning(await erro.text()));
            } catch (erro) {
                MessageBox.warning(erro.message)
            }
        },

        aoClicarAbreTelaDeCadastro() {
            try {
                const rotaCadastro = "cadastro";
                const rota = this.getOwnerComponent().getRouter();
                rota.navTo(rotaCadastro);
            }
            catch (erro) {
                MessageBox.warning(erro.message)
            }
        },

        aoClicarAbreTelaDeDetalhes(linhaSelecionada) {
            try {
                const idFuncionario = "id"
                const rotaDetalhes = "detalhes";
                const recursosLinhaSelecionada = linhaSelecionada.getSource();

                const rota = this.getOwnerComponent().getRouter();

                rota.navTo(rotaDetalhes, {
                    id: window.encodeURIComponent(recursosLinhaSelecionada.getBindingContext(MODELO_TABELA).getProperty(idFuncionario))
                });
            } catch (erro) {
                MessageBox.warning(erro.message)
            }
        }
    });
});