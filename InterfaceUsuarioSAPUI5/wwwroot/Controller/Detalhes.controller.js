sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History",
    "../Model/formatter",
    "../Repositorios/FuncionarioRepository"
], function (Controller, JSONModel, History, formatter, FuncionarioRepository) {
    'use strict';

    const nameSpace = "controle.funcionarios.Controller.Detalhes";
    const ROTA_LISTAGEM = "listagem"
    const ROTA_DETALHES = "detalhes"

    return Controller.extend(nameSpace, {

        formatter: formatter,

        //#region CORRIGIR NOMES
        
        onInit() {
            this._aoCoincidirRota();
        },

        _aoCoincidirRota() {
            const rota = this.getOwnerComponent().getRouter();
            rota.getRoute(ROTA_DETALHES).attachPatternMatched(this.onObjectMatched, this);
        },
        onObjectMatched(oEvent) {
            try {
                const id = oEvent.getParameter("arguments").id;

                FuncionarioRepository.obterPorId(id).then(funcionarios => {
                    this.getView()
                        .setModel(new JSONModel(funcionarios))
                }).catch(erro => console.log(erro));

            } catch (error) {
                console.log(error)
            }
        },
        //#endregion
        aoClicarAbreTelaDeEdicao() {
            alert("Tela de Edição");
        },

        aoClicarRemoveFuncionario() {
            alert("Remover Funcionário");
        },

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
        }
    })
});