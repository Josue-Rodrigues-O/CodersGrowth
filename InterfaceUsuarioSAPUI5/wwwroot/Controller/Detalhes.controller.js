sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "sap/ui/core/routing/History",
    "../Model/Formatter",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox"
], function (Controller, JSONModel, History, Formatter, FuncionarioRepository, MessageBox) {
    'use strict';

    const nameSpace = "controle.funcionarios.Controller.Detalhes";
    const ROTA_LISTAGEM = "listagem"
    const ROTA_DETALHES = "detalhes"

    return Controller.extend(nameSpace, {

        formatter: Formatter,

        onInit() {
            const rota = this.getOwnerComponent().getRouter();
            rota.getRoute(ROTA_DETALHES).attachPatternMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota(evento) {
            const ARGUMENTOS = "arguments";
            const id = evento.getParameter(ARGUMENTOS).id;
            try {
                FuncionarioRepository.obterPorId(id)
                    .then(funcionarios => {
                        if (funcionarios.status == 200) {
                            return funcionarios.json()
                        } else {
                            return Promise.reject(funcionarios)
                        }
                    })
                    .then(funcionarios => {
                        this.getView()
                            .setModel(new JSONModel(funcionarios))
                    }).catch(async erro => MessageBox.warning(await erro.text()));
            } catch (erro) {
                MessageBox.warning(erro)
            }
        },

        aoClicarAbreTelaDeEdicao() {

        },

        aoClicarRemoveFuncionario() {

        },

        aoClicarVoltarParaPaginaAnterior() {
            const rota = this.getOwnerComponent().getRouter();
            rota.navTo(ROTA_LISTAGEM, {}, true);
        }
    });
});