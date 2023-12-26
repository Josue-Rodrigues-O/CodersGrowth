sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History"
], function (Controller, History) {
    'use strict';

    return Controller.extend("controle.funcionarios.controller.Create", {
        aoClicarVoltarParaPaginaAnterior() {
            const paginaAnterior = -1;
            const historico = History.getInstance();
			const previousHash = historico.getPreviousHash();

			if (previousHash !== undefined) {
				window.history.go(paginaAnterior);
			} else {
				const rota = this.getOwnerComponent().getRouter();
				rota.navTo("overview", {}, true);
			}
        }
    })
});