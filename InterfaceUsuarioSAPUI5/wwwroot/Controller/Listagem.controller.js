sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
    "../Model/Formatter",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox"
], function (Controller, JSONModel, Formatter, FuncionarioRepository, MessageBox) {
    "use strict";

    const nameSpace = "controle.funcionarios.Controller.Listagem";
    const MODELO_TABELA = "modeloTabelaFuncionarios";
    const ROTA_CADASTRO = "cadastro";
    const ROTA_DETALHES = "detalhes";
    const ROTA_LISTAGEM = "listagem"

    return Controller.extend(nameSpace, {

        formatter: Formatter,

        onInit() {
            let rota = this.getOwnerComponent().getRouter();
            rota.getRoute(ROTA_LISTAGEM).attachPatternMatched(this._aoCoincidirRota, this);
        },

        _aoCoincidirRota() {
            try {
                FuncionarioRepository.obterTodos()
                    .then(funcionarios => funcionarios.json())
                    .then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), MODELO_TABELA))
                    .catch(async erro => MessageBox.warning(await erro.text()));
            } catch (erro) {
                MessageBox.warning(erro)                
            }
        },

        _pesquisarFiltrarFuncionarios(condicao) {
            const parametroQuery = "query";
            const stringCondicao = condicao.getParameter(parametroQuery);
            FuncionarioRepository.obterTodos(stringCondicao).then(funcionarios => funcionarios.json()).then(funcionarios => this.getView().setModel(new JSONModel(funcionarios), MODELO_TABELA));
        },

        aoClicarAbreTelaDeCadastro() {
            const rota = this.getOwnerComponent().getRouter();
            rota.navTo(ROTA_CADASTRO);
        },

        aoClicarAbreTelaDeDetalhes(linhaSelecionada) {
            const recursosLinhaSelecionada = linhaSelecionada.getSource();

            const rota = this.getOwnerComponent().getRouter();

            rota.navTo(ROTA_DETALHES, {
                id: window.encodeURIComponent(recursosLinhaSelecionada.getBindingContext(MODELO_TABELA).getProperty("id"))
            });
        }
    });
});