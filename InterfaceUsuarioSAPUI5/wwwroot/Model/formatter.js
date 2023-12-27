sap.ui.define([], () => {
    "use strict";

    return {
        generoText(sexo) {
            const recursos_i18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            switch (sexo) {
                case 0:
                    return recursos_i18n.getText("indefinido");
                case 1:
                    return recursos_i18n.getText("masculino");
                case 2:
                    return recursos_i18n.getText("feminino");
                default:
                    return sexo;
            }
        },
        estadoCivilText(ehCasado) {
            const recursos_i18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            switch (ehCasado) {
                case true:
                    return recursos_i18n.getText("sim");
                case false:
                    return recursos_i18n.getText("nao");
                default:
                    return ehCasado;
            }
        }
    }
});