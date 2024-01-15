sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../Model/Formatter",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox"
], function (Controller, JSONModel, Formatter, FuncionarioRepository, MessageBox) {
    'use strict';

    const NAMESPACE = "controle.funcionarios.Controller.Detalhes";

    return Controller.extend(NAMESPACE, {

        formatter: Formatter,

        onInit() {
            const rotaDetalhes = "detalhes"
            const rota = this.getOwnerComponent().getRouter();
            rota.getRoute(rotaDetalhes).attachPatternMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota(evento) {
            try {
                const parametroArgumentos = "arguments";
                const idFuncionario = evento.getParameter(parametroArgumentos).id;
                this._obterPorId(idFuncionario);
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        },

        _obterPorId(id) {
            try {
                const statusOk = 200;
                FuncionarioRepository.obterPorId(id)
                    .then(response => {
                        if (response.status == statusOk) {
                            return response.json();
                        } else {
                            return Promise.reject(response);
                        }
                    })
                    .then(response => {
                        this.getView()
                            .setModel(new JSONModel(response));
                    }).catch(async erro => MessageBox.warning(await erro.text()));
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        },

        aoClicarAbreTelaDeEdicao() {

        },

        aoClicarRemoveFuncionario() {

        },

        aoClicarVoltarParaPaginaAnterior() {
            try {
                const rotaListagem = "listagem";
                const rota = this.getOwnerComponent().getRouter();
                rota.navTo(rotaListagem, {}, true);
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        }
    });
});