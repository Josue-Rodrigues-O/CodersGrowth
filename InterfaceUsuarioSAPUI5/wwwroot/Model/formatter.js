sap.ui.define([], () => {
    "use strict";

    const i18n = "i18n";

    return {
        
        generoText(sexo) {
            const indefinido = "indefinido"
            const masculino = "masculino"
            const feminino = "feminino"
            
            const recursos_i18n = this.getOwnerComponent().getModel(i18n).getResourceBundle();
            switch (sexo) {
                case 0:
                    return recursos_i18n.getText(indefinido);
                case 1:
                    return recursos_i18n.getText(masculino);
                case 2:
                    return recursos_i18n.getText(feminino);
                default:
                    return sexo;
            }
        },

        estadoCivilText(ehCasado) {
            const casado = "casado"
            const solteiro = "solteiro"

            const recursos_i18n = this.getOwnerComponent().getModel(i18n).getResourceBundle();
            switch (ehCasado) {
                case true:
                    return recursos_i18n.getText(casado);
                case false:
                    return recursos_i18n.getText(solteiro);
                default:
                    return ehCasado;
            }
        }
    }
});