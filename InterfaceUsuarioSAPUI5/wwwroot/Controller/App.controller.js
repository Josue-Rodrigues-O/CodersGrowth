sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/m/MessageToast",
], (Controller, MessageToast)  => {
    "use strict";
    
    return Controller.extend("controle.funcionarios.controller.App", {
        onMostrarOla(){
            MessageToast.show("OLAAAAAA");
        }
    });
});