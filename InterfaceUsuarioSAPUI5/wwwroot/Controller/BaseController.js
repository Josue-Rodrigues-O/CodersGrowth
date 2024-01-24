sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"
], function (Controller, JSONModel, MessageBox) {
    "use strict";

    const NAMESPACE = "controle.funcionarios.Controller.BaseController"
    return Controller.extend(NAMESPACE, {
        vincularRota(nomeDaRota, metodo) {
            const rota = this.getOwnerComponent().getRouter()
            rota.getRoute(nomeDaRota).attachPatternMatched(metodo, this)
        },

        obterRecursoi18n(nomeVariavelI18n) {
            const modeloI18n = "i18n"
            const recursos_i18n = this.getOwnerComponent().getModel(modeloI18n).getResourceBundle();
            return recursos_i18n.getText(nomeVariavelI18n);
        },

        navegarPara(nomeDaRota, parametroDeRota) {
            const rota = this.getOwnerComponent().getRouter()
            rota.navTo(nomeDaRota, parametroDeRota, true)
        },

        modelo(nomeDoModelo, objeto) {
            if (objeto == (undefined || null)) {
                return this.getView().getModel(nomeDoModelo).getData()
            }
            this.getView().setModel(new JSONModel(objeto), nomeDoModelo)
        },

        messageBoxConfirmacao(mensagem, metodo) {
            MessageBox.confirm(mensagem, {
                actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                emphasizedAction: MessageBox.Action.YES,
                onClose: (acao) => {
                    if (acao == MessageBox.Action.YES) {
                        metodo();
                    }
                }
            });
        },
    });
});