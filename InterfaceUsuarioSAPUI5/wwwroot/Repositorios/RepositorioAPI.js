sap.ui.define([], () => {
  "use strict";

  return {
    async obterPorId(id) {
      const url = `/api/Funcionario/${id}`
      try {
        return funcionarios = await fetch(url)
        .then(funcionario => funcionario.json);
      } catch (erro) {
        return console.log(erro.error);
      }
    },

    async obterTodos(condicao="") {
      const url = `/api/Funcionario?condicao=${condicao}`
      try {
        return funcionarios = await fetch(url)
        .then(funcionario => funcionario.json);
      } catch (erro) {
        return console.log(erro.error);
      }
    },
  }
})
