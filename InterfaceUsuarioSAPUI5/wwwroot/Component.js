sap.ui.define([
    "sap/ui/core/UIComponent",
    "sap/ui/model/resource/ResourceModel"
], (UIComponent,ResourceModel) => {
    'use strict';

    return UIComponent.extend("controle.funcionarios.Component", {
        metadata: {
            "interfaces": ["sap.ui.IAsyncContentCreation"],
            "rootView": {
                "viewName": "controle.funcionarios.view.App",
                "type": "XML",
                "id": "app"
            }
        },
        onInit() {
            UIComponent.prototype.init.apply(this, arguments);

            const i18nModel = new ResourceModel({
                bundleName: "controle.funcionarios.i18n.i18n"
            });
            this.setModel(i18nModel, "i18n");
        }
    });
});