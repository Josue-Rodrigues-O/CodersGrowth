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
    const ROTA_LISTAGEM = "listagem"

    return Controller.extend(nameSpace, {

        formatter: formatter,

        onInit() {
            let rota = this.getOwnerComponent().getRouter();
            rota.getRoute(ROTA_LISTAGEM).attachPatternMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota() {
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

        aoClicarAbreTelaDeDetalhes(linhaSelecionada) {
            const recursosLinhaSelecionada = linhaSelecionada.getSource();

            const indexLinhaSelecionada = window.encodeURIComponent(recursosLinhaSelecionada.getBindingContext(MODELO_TABELA).getPath().substr(1));

            const listaDeFuncionarios = recursosLinhaSelecionada.getBindingContext(MODELO_TABELA).oModel.oData;

            const funcionario = listaDeFuncionarios[indexLinhaSelecionada];

            const rota = this.getOwnerComponent().getRouter();


            rota.navTo(ROTA_DETALHES, {
                id: window.encodeURIComponent(funcionario.id)
            });
        }
    });
});