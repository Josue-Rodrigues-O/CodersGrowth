sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History"
], function (Controller, History) {
    'use strict';

    const nameSpace = "controle.funcionarios.Controller.Detalhes";
    const ROTA_LISTAGEM = "Listagem"
    const ROTA_DETALHES = "detalhes"

    return Controller.extend(nameSpace, {

        aoClicarVoltarParaPaginaAnterior() {
            const PAGINA_ANTERIOR = -1;
            const historico = History.getInstance();
            const hashAnterior = historico.getPreviousHash();

            if (hashAnterior !== undefined) {
                window.history.go(PAGINA_ANTERIOR);
            } else {
                const rota = this.getOwnerComponent().getRouter();
                rota.navTo(ROTA_LISTAGEM, {}, true);
            }
        },

        onInit() {
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.getRoute(ROTA_DETALHES).attachPatternMatched(this.onObjectMatched, this);
        },

        onObjectMatched(oEvent) {
            this.getView().bindElement({
                path: "/" + window.decodeURIComponent(oEvent.getParameter("arguments").id),
                model: "modeloTabelaFuncionarios"
            });
        }
    })
});