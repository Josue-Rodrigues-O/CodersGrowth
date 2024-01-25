sap.ui.define([
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat",
], (DateFormat, NumberFormat) => {
    "use strict";

    const MODELO_I18N = "i18n";

    return {
        generoText(genero) {
            const generoIndefinido = {id: 0, genero: "indefinido"};
            const generoMasculino = {id: 1, genero: "masculino"};
            const generoFeminino = {id: 2, genero: "feminino"};

            const recursos_i18n = this.getOwnerComponent().getModel(MODELO_I18N).getResourceBundle();
            switch (genero) {
                case generoIndefinido.id:
                    return recursos_i18n.getText(generoIndefinido.genero);
                case generoMasculino.id:
                    return recursos_i18n.getText(generoMasculino.genero);
                case generoFeminino.id:
                    return recursos_i18n.getText(generoFeminino.genero);
                default:
                    return genero;
            }
        },

        formatarCivilText(ehCasado) {
            const estadoCivilCasado = "casado";
            const estadoCivilSolteiro = "solteiro";
            const recursos_i18n = this.getOwnerComponent().getModel(MODELO_I18N).getResourceBundle();
            return ehCasado ? recursos_i18n.getText(estadoCivilCasado) : recursos_i18n.getText(estadoCivilSolteiro);
        },

        formatarSalario(salario){
            const duasCasasDecimais = 2;
            const formatoSalarioOpcoes = {
                decimals: 2
            };
            const formatarSalario = NumberFormat.getFloatInstance(formatoSalarioOpcoes);
            return formatarSalario.format(parseFloat(salario).toFixed(duasCasasDecimais));
        },

        formatarDataParaSalvar(data){
            const formatoData = "yyyy-MM-dd";
            let formatador = DateFormat.getDateInstance({
                pattern: formatoData
            });
            return formatador.format(data);
        },

        formatarDataParaExibir(data){
            const formatoData = "dd/MM/yyyy";
            let formatador = DateFormat.getDateInstance({
                pattern: formatoData
            });
            return formatador.format((data));
        }
    }
});