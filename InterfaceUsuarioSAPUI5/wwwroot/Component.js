sap.ui.define([
    "sap/ui/core/UIComponent",
    "sap/ui/model/resource/ResourceModel"
], (UIComponent, ResourceModel) => {
    "use strict";

    return UIComponent.extend("controle.funcionarios.Component", {
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
