sap.ui.define([], () => {
    "use strict";

    return {
        generoText(sexo) {
            const resourceBuendle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            switch (sexo) {
                case 0:
                    return resourceBuendle.getText("indefinido");
                case 1:
                    return resourceBuendle.getText("masculino");
                case 2:
                    return resourceBuendle.getText("feminino");
                default:
                    return sexo;
            }
        },
        estadoCivilText(estadoCivil) {
            const resourceBuendle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            switch (estadoCivil) {
                case true:
                    return resourceBuendle.getText("sim");
                case false:
                    return resourceBuendle.getText("nao");
                default:
                    return estadoCivil;
            }
        }
    }
});