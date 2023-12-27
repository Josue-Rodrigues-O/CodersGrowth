sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History"
], function (Controller, History) {
    'use strict';

    const CONTROLADOR_DETALHES = "controle.funcionarios.controller.Detalhes";
    const ROTA_OVERVIEW = "overview"

    return Controller.extend(CONTROLADOR_DETALHES, {
        aoClicarVoltarParaPaginaAnterior() {
            const PAGINA_ANTERIOR = -1;
            const historico = History.getInstance();
			const hashAnterior = historico.getPreviousHash();

			if (hashAnterior !== undefined) {
				window.history.go(PAGINA_ANTERIOR);
			} else {
				const rota = this.getOwnerComponent().getRouter();
				rota.navTo(ROTA_OVERVIEW, {}, true);
			}
        }
    })
});