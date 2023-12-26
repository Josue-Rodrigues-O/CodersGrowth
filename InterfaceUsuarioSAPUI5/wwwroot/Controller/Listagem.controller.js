sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../Model/formatter",
    "../Repositorios/RepositorioAPI"
], function (Controller, JSONModel, formatter, RepositorioAPI) {
    "use strict";

    const ID_TABELA = "TabelaFuncionarios";

    return Controller.extend("controle.funcionarios.Controller.Listagem", {
        formatter: formatter,
        onInit: function () {
            this.definirModeloMoeda();
            this.chamarObterTodos();
        },

        definirModeloMoeda() {
            const modeloMoeda = new JSONModel({
                currency: "BRL"
            });
            this.getView().setModel(modeloMoeda, "view");
        },

        chamarObterTodos() {
            RepositorioAPI.obterTodos().then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), ID_TABELA));
        },

        aoClicarAbreTelaDeCadastro() {
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo("create");
        },

        aoPesquisarFiltrarFuncionarios(condicao) {
            const stringCondicao = condicao.getParameter("query");
            RepositorioAPI.obterTodos(stringCondicao).then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), ID_TABELA));
        },

        aoClicarAbrirDetails() {
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo("details");
        }
    });
});