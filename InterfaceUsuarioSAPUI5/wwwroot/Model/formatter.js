sap.ui.define([], () => {
    "use strict";

    return {
        generoText(sexo) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            switch (sexo) {
                case 0:
                    return oResourceBundle.getText("indefinido");
                case 1:
                    return oResourceBundle.getText("masculino");
                case 2:
                    return oResourceBundle.getText("feminino");
                default:
                    return sexo;
            }
        },
        estadoCivilText(estadoCivil) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            switch (estadoCivil) {
                case true:
                    return oResourceBundle.getText("sim");
                case false:
                    return oResourceBundle.getText("nao");
                default:
                    return estadoCivil;
            }
        }
    }
});