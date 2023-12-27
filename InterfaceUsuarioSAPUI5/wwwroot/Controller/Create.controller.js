sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History"
], function (Controller, History) {
    'use strict';

    const CREAT_CONTROLLER = "controle.funcionarios.controller.Create";
    const ROTA_OVERVIEW = "overview";

    return Controller.extend(CREAT_CONTROLLER, {
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