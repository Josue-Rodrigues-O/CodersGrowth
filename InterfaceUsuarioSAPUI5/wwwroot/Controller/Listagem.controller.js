sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../Model/formatter",
    "../Repositorios/FuncionarioRepository"
], function (Controller, JSONModel, formatter, FuncionarioRepository) {
    "use strict";

    const CONTROLE_LISTAGEM = "controle.funcionarios.Controller.Listagem";
    const MODELO_TABELA = "modeloTabelaFuncionarios";
    const MODELO_SALARIO = "modeloSalario"
    const ROTA_CRIAR = "criar";
    const ROTA_DETALHES = "detalhes";
    const MOEDA = "BRL";

    return Controller.extend(CONTROLE_LISTAGEM, {
        formatter: formatter,
        onInit: function () {
            this.definirModeloMoeda();
            this.chamarObterTodos();
        },

        definirModeloMoeda() {
            const modeloMoeda = new JSONModel({
                currency: MOEDA
            });
            this.getView().setModel(modeloMoeda, MODELO_SALARIO);
        },

        chamarObterTodos() {
            FuncionarioRepository.obterTodos().then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), MODELO_TABELA));
        },

        aoClicarAbreTelaDeCadastro() {
            const rota = this.getOwnerComponent().getRouter();
            rota.navTo(ROTA_CRIAR);
        },

        aoPesquisarFiltrarFuncionarios(condicao) {
            const parametroQuery = "query";
            const stringCondicao = condicao.getParameter(parametroQuery);
            FuncionarioRepository.obterTodos(stringCondicao).then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), MODELO_TABELA));
        },

        aoClicarAbrirDetails() {
            const rota = this.getOwnerComponent().getRouter();
            rota.navTo(ROTA_DETALHES);
        }
    });
});