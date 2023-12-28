sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../Model/formatter",
    "../Repositorios/FuncionarioRepository"
], function (Controller, JSONModel, formatter, FuncionarioRepository) {
    "use strict";

    const nameSpace = "controle.funcionarios.Controller.Listagem";
    const MODELO_TABELA = "modeloTabelaFuncionarios";
    const ROTA_CRIAR = "criar";
    const ROTA_DETALHES = "detalhes";

    return Controller.extend(nameSpace, {
        formatter: formatter,
        onInit: function () {
            this._carregarFuncionarios();
        },
        
        _carregarFuncionarios() {
            FuncionarioRepository.obterTodos().then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), MODELO_TABELA));
        },
        
        _pesquisarFiltrarFuncionarios(condicao) {
            const parametroQuery = "query";
            const stringCondicao = condicao.getParameter(parametroQuery);
            FuncionarioRepository.obterTodos(stringCondicao).then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), MODELO_TABELA));
        },

        aoClicarAbreTelaDeCadastro() {
            const rota = this.getOwnerComponent().getRouter();
            rota.navTo(ROTA_CRIAR);
        },

        aoClicarAbreTelaDeDetalhes() {
            const rota = this.getOwnerComponent().getRouter();
            rota.navTo(ROTA_DETALHES);
        }
    });
});