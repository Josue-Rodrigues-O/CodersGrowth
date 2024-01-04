sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/ui/model/json/JSONModel",
    "../Repositorios/FuncionarioRepository",
    "../Model/formatter"
], function (Controller, History, JSONModel, FuncionarioRepository, formatter) {
    'use strict';

    const nameSpace = "controle.funcionarios.controller.Cadastro";
    const ROTA_LISTAGEM = "listagem";
    const ROTA_CADASTRO = "cadastro"


    return Controller.extend(nameSpace, {

        formatter: formatter,

        onInit() {
            this._aoCoincidirRota()
        },

        _aoCoincidirRota() {
            const rota = this.getOwnerComponent().getRouter();
            rota.getRoute(ROTA_CADASTRO).attachPatternMatched(this._modeloFuncinario, this);
        },

        _modeloFuncinario() {
            const funcionario = new Object()
            let modelo = new JSONModel(funcionario);
            this.getView().setModel(modelo)
        },

        _reiniciaModelo() {
            let modelo = this.getView().getModel().oData
            modelo.nome = null
            modelo.cpf = null
            modelo.telefone = null
            modelo.salario = null
            modelo.ehCasado = false
            modelo.dataNascimento = null
            modelo.genero = null
        },

        _voltarParaPaginaAnterior() {
            
            const PAGINA_ANTERIOR = -1;
            const historico = History.getInstance();
            const hashAnterior = historico.getPreviousHash();

            if (hashAnterior !== undefined) {
                window.history.go(PAGINA_ANTERIOR);
            } else {
                const rota = this.getOwnerComponent().getRouter();
                rota.navTo(ROTA_LISTAGEM, {}, true);
            }
        },

        _aoClicarEmSalvar() {
            let modelo = this.getView().getModel().oData
            modelo.genero = parseInt(modelo.genero)
            modelo.salario = Number(modelo.salario)
            FuncionarioRepository.criar(modelo)
            this._reiniciaModelo()
            this._voltarParaPaginaAnterior()
        },

        _aoClicarEmVoltar() {
            this._reiniciaModelo()
            this._voltarParaPaginaAnterior()
        },

        _aoClicarEmCancelar() {
            this._reiniciaModelo()
            this._voltarParaPaginaAnterior()
        }
    })
});