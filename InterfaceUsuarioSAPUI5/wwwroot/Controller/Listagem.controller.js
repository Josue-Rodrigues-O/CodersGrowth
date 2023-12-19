sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel"
], function (Controller, JSONModel) {
    "use strict";

    return Controller.extend("controle.funcionarios.Controller.Listagem", {

        onInit: function () {

            this.ObterTodos();
        },
        ObterTodos(){
            const url = "/api/Funcionario"
            fetch(url)
            .then(jogos => jogos.json())
            .then(jogos => this.getView().setModel(new JSONModel(jogos), "tabelinha"))
            .catch((erro)=>console.log(erro.error))
        }
    });
});