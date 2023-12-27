sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../Model/formatter",
    "../Repositorios/RepositorioAPI"
], function (Controller, JSONModel, formatter, RepositorioAPI) {
    "use strict";

    const MODELO_TABELA = "ModeloTabelaFuncionarios";
    const MODELO_SALARIO = "ModeloSalario"
    const ROTA_CREATE = "create";
    const ROTA_DETAILS = "details";
    const MOEDA = "BRL";

    return Controller.extend("controle.funcionarios.Controller.Listagem", {
        formatter: formatter,
        onInit: function () {
            this.definirModeloMoeda();
            this.chamarObterTodos();
        },

        definirModeloMoeda() {
            const modeloMoeda = new JSONModel({
                currency: MOEDA
            });
            this.getView().setModel(modeloMoeda, MODELO_SALARIO);
        },

        chamarObterTodos() {
            RepositorioAPI.obterTodos().then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), MODELO_TABELA));
        },

        aoClicarAbreTelaDeCadastro() {
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo(ROTA_CREATE);
        },

        aoPesquisarFiltrarFuncionarios(condicao) {
            const stringCondicao = condicao.getParameter("query");
            RepositorioAPI.obterTodos(stringCondicao).then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), MODELO_TABELA));
        },

        aoClicarAbrirDetails() {
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo(ROTA_DETAILS);
        }
    });
});