sap.ui.define([
  "sap/ui/model/json/JSONModel"
], (JSONModel) => {
  "use strict";

  return{
    obterTodos(view) {
      const url = "/api/Funcionario"
      fetch(url)
        .then(funcionarios => funcionarios.json())
        .then(funcionarios => view.getView().setModel(new JSONModel(funcionarios), "TabelaFuncionarios"))
        .catch((erro) => console.log(erro.error))
    }
  }
})
