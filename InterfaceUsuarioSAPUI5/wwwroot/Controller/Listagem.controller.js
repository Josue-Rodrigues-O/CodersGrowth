sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel"
], function (Controller, JSONModel) {
    "use strict";

    return Controller.extend("sap.ui.webc.main.sample.Table.C", {

        onInit: function () {
            var oModel = new JSONModel(sap.ui.require.toUrl("controle/funcionarios/Repositorios/funcio.json"));
            this.getView().setModel(oModel);
        }
    });
});