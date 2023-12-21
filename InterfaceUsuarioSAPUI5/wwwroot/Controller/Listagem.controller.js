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
            const viewModelo = new JSONModel({
                currency: "BRL"
            });
            this.getView().setModel(viewModelo, "view");

            RepositorioAPI.obterTodos(this);
        },

        aoClicarAbreTelaDeCadastro(){
            alert("Abrir tela de cadastro");
        },

        aoPesquisarFiltrarFuncionarios(Evento){
            const arrayFiltrado = [];
            const stringQuery = Evento.getParameter("query");
            if(stringQuery) {
                arrayFiltrado.push(new Filter("nome", FilterOperator.Contains, stringQuery));
            }

            const listaFiltrada = this.byId("TabelaFuncionarios");
            const objetoBinding = listaFiltrada.getBinding("items");
            objetoBinding.filter(arrayFiltrado);
        }
    });
});