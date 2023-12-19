sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../Model/formatter"
], function (Controller, JSONModel, formatter) {
    "use strict";

    return Controller.extend("controle.funcionarios.Controller.Listagem", {
        formatter: formatter,
        onInit: function () {
            const oViewModel = new JSONModel({
                currency: "BRL"
            });
            this.getView().setModel(oViewModel, "view");

            this.ObterTodos();
        },
        ObterTodos() {
            const url = "/api/Funcionario"
            fetch(url)
                .then(jogos => jogos.json())
                .then(jogos => this.getView().setModel(new JSONModel(jogos), "TabelaFuncionarios"))
                .catch((erro) => console.log(erro.error))
        }
    });
});