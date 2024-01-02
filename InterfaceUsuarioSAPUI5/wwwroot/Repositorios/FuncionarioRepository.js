sap.ui.define([], () => {
  "use strict";

  return {
    async obterPorId(id) {
      const url = `/api/Funcionario/${id}`

      return fetch(url).then(funcionarios => funcionarios.json()).catch(erro => console.log(erro));
    },

    async obterTodos(condicao="") {
      const url = `/api/Funcionario?condicao=${condicao}`
      
      return fetch(url).then(funcionarios => funcionarios.json()).catch(erro => console.log(erro));
    },
  }
})
