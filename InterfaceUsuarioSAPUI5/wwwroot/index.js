sap.ui.define([
    "sap/ui/core/ComponentContainer"
], (ComponentContainer) => {
    "use strict";

    new ComponentContainer({
        name: "controle.funcionarios",
        settings: {
            id: "funcionarios"
        },
        async: true
    }).placeAt("content");
});