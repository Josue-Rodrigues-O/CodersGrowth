sap.ui.define([
    "sap/ui/core/UIComponent",
], (UIComponent) => {
    "use strict";

    const NAMESPACE = "controle.funcionarios.Component";
    const IASYNC_CONTENT_CREATION = "sap.ui.core.IAsyncContentCreation";
    const TIPO_DO_ARQUIVO_MANIFEST = "json";

    return UIComponent.extend(NAMESPACE, {
        metadata: {
            interfaces: [IASYNC_CONTENT_CREATION],
            manifest: TIPO_DO_ARQUIVO_MANIFEST
        },

        init() {
            UIComponent.prototype.init.apply(this, arguments);
            this.getRouter().initialize();
        }
    });
});
