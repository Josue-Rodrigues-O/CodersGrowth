sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../Model/formatter",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "../Repositorios/RepositorioAPI"
], function (Controller, JSONModel, formatter, Filter, FilterOperator, RepositorioAPI) {
    "use strict";

    return Controller.extend("controle.funcionarios.Controller.Listagem", {
        formatter: formatter,
        onInit: function () {
            const oViewModel = new JSONModel({
                currency: "BRL"
            });
            this.getView().setModel(oViewModel, "view");

            RepositorioAPI.obterTodos(this);
        },

        Ao_Clicar_Abre_Tela_De_Cadastro(){
            alert("Abrir tela de cadastro");
        },

        Filtro_Da_Tela_De_Listagem(oEvent){
            const aFilter = [];
            const sQuery = oEvent.getParameter("query");
            if(sQuery) {
                aFilter.push(new Filter("nome", FilterOperator.Contains, sQuery));
            }

            const oList = this.byId("TabelaFuncionarios");
            const oBinding = oList.getBinding("items");
            oBinding.filter(aFilter);
        }
    });
});