sap.ui.define([
    "sap/ui/core/UIComponent",
], (UIComponent) => {
    "use strict";

    const COMPONENT = "controle.funcionarios.Component";

    return UIComponent.extend(COMPONENT, {
        metadata: {
            interfaces: ["sap.ui.core.IAsyncContentCreation"],
            manifest: "json"
        },

        init() {
            UIComponent.prototype.init.apply(this, arguments);
            this.getRouter().initialize();
        }
    });
});
