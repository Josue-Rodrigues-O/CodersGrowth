sap.ui.define([], () => {
    "use strict";

    const MODELO_I18N = "i18n";

    return {

        generoText(genero) {
            const generoIndefinido = "indefinido"
            const generoMasculino = "masculino"
            const generoFeminino = "feminino"

            const recursos_i18n = this.getOwnerComponent().getModel(MODELO_I18N).getResourceBundle();
            switch (genero) {
                case 0:
                    return recursos_i18n.getText(generoIndefinido);
                case 1:
                    return recursos_i18n.getText(generoMasculino);
                case 2:
                    return recursos_i18n.getText(generoFeminino);
                default:
                    return genero;
            }
        },

        estadoCivilText(ehCasado) {
            const estadoCivilCasado = "casado"
            const estadoCivilSolteiro = "solteiro"

            const recursos_i18n = this.getOwnerComponent().getModel(MODELO_I18N).getResourceBundle();
            return ehCasado ? recursos_i18n.getText(estadoCivilCasado) : recursos_i18n.getText(estadoCivilSolteiro);
        }
    }
});