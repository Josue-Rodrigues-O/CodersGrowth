sap.ui.define([
  "sap/ui/model/json/JSONModel"
], (JSONModel) => {
  "use strict";

  return{
    obterTodos(controller) {
      const url = "/api/Funcionario"
      fetch(url)
        .then(funcionarios => funcionarios.json())
        .then(funcionarios => controller.getView().setModel(new JSONModel(funcionarios), "TabelaFuncionarios"))
        .catch((erro) => console.log(erro.error))
    },
    obterPorId(controller, id){
      const url = `/api/Funcionario/${id}`
      fetch(url)
        .then(funcionarios => funcionarios.json())
        .then(funcionarios => controller.getView().setModel(new JSONModel([funcionarios]), "TabelaFuncionarios"))
        .catch((erro) => console.log(erro.error))
    }
  }
})
