sap.ui.define([], () => {
  "use strict";

  return {
    async obterPorId(id) {
      const url = `/api/Funcionario/${id}`

      return fetch(url).then(funcionarios => funcionarios.json()).catch(erro => console.log(erro));
    },

    async obterTodos(condicao = "") {
      const url = `/api/Funcionario?condicao=${condicao}`

      return fetch(url).then(funcionarios => funcionarios.json()).catch(erro => console.log(erro));
    },

    async criar(funcionario) {
      const url = `/api/Funcionario`
      const configuracaoFetch = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(funcionario)
      }

      fetch(url, configuracaoFetch)
    }
  }
})
