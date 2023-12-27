sap.ui.define([
    "sap/ui/core/UIComponent",
], (UIComponent) => {
    "use strict";

    const COMPONENT = "controle.funcionarios.Component";
    const IASYNC_CONTENT_CREATION = "sap.ui.core.IAsyncContentCreation";
    const TIPO_DE_ARQUIVO_MANIFEST = "json";

    return UIComponent.extend(COMPONENT, {
        metadata: {
            interfaces: [IASYNC_CONTENT_CREATION],
            manifest: TIPO_DE_ARQUIVO_MANIFEST
        },

        init() {
            UIComponent.prototype.init.apply(this, arguments);
            this.getRouter().initialize();
        }
    });
});
