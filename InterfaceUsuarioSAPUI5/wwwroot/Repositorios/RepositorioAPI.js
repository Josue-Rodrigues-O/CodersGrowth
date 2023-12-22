sap.ui.define([
  "sap/ui/model/json/JSONModel"
], (JSONModel) => {
  "use strict";

  const ID_TABELA = "TabelaFuncionarios";

  return {
    obterTodos(view) {
      const url = "/api/Funcionario/ObterTodos"
      fetch(url)
        .then(funcionarios => funcionarios.json())
        .then(funcionarios => view.setModel(new JSONModel(funcionarios), ID_TABELA))
        .catch((erro) => console.log(erro.error))
    },

    obterPorId(view, id){
      const url = `/api/Funcionario/ObterPorId/${id}`
      fetch(url)
        .then(funcionarios => funcionarios.json())
        .then(funcionarios => view.setModel(new JSONModel([funcionarios]), ID_TABELA))
        .catch((erro) => console.log(erro.error))
    },

    obterTodosComFiltro(view, condicao){
      const url = `/api/Funcionario/Filtrar/${condicao}`
      fetch(url)
        .then(funcionarios => funcionarios.json())
        .then(funcionarios => view.setModel(new JSONModel(funcionarios), ID_TABELA))
        .catch((erro) => console.log(erro.error))
    }
  }
})
