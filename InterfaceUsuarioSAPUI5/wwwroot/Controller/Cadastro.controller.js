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
    const funcionario = {
        nome: null,
        cpf: null,
        telefone: null,
        salario: null,
        ehCasado: false,
        dataNascimento: null,
        genero: null
    }

    return Controller.extend(nameSpace, {

        formatter: formatter,

        onInit() {
            this._modeloFuncinario();
        },

        _modeloFuncinario() {
            let modelo = new JSONModel(funcionario);
            this.getView().setModel(modelo)
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
            funcionario.genero = parseInt(funcionario.genero)
            funcionario.salario = Number(funcionario.salario)
            FuncionarioRepository.criar(funcionario)
            this._voltarParaPaginaAnterior()
        },

        _aoClicarEmVoltar() {
            this._voltarParaPaginaAnterior()
        },

        _aoClicarEmCancelar() {
            this._voltarParaPaginaAnterior()
        }
    })
});