sap.ui.define([
  "sap/ui/model/json/JSONModel"
], (JSONModel) => {
  "use strict";

  const ID_TABELA = "TabelaFuncionarios";

  return {
    obterTodos(controller) {
      const url = "/api/Funcionario"
      fetch(url)
        .then(funcionarios => funcionarios.json())
        .then(funcionarios => controller.getView().setModel(new JSONModel(funcionarios), ID_TABELA))
        .catch((erro) => console.log(erro.error))
    },

    obterPorId(controller, id){
      const url = `/api/Funcionario/${id}`
      fetch(url)
        .then(funcionarios => funcionarios.json())
        .then(funcionarios => controller.getView().setModel(new JSONModel([funcionarios]), ID_TABELA))
        .catch((erro) => console.log(erro.error))
    }
  }
})
