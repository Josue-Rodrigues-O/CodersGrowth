sap.ui.define([], () => {
  "use strict";

  return {
    async obterPorId(id) {
      const url = `/api/Funcionario/${id}`
      try {
        const funcionarios = await fetch(url);
        return await funcionarios.json();
      } catch (erro) {
        return console.log(erro.error);
      }
    },

    async obterTodos(condicao="") {
      const url = `/api/Funcionario?condicao=${condicao}`
      try {
        const funcionarios = await fetch(url);
        return await funcionarios.json();
      } catch (erro) {
        return console.log(erro.error);
      }
    },
  }
})
