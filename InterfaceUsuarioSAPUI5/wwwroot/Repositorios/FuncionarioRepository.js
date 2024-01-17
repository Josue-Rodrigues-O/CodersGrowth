sap.ui.define([], () => {
  "use strict";

  const URL = "/api/Funcionario";

  return {
    obterPorId(id) {
      return fetch(`${URL}/${id}`);
    },

    obterTodos(condicao) {
      const uri = `?condicao=${condicao}`;
      let query = URL;
      if (condicao != (undefined || null)) {
        query += uri;
      }
      return fetch(query);
    },

    criar(funcionario) {
      const configuracaoFetch = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(funcionario)
      };

      return fetch(URL, configuracaoFetch);
    },

    atualizar(funcionario) {
      const configuracaoFetch = {
        method: 'PATCH',
        headers: {
          'Content-Type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(funcionario)
      };

      return fetch(URL, configuracaoFetch);
    },

    remover(id) {
      const configuracaoFetch = {
        method: 'DELETE'
      }

      return fetch(`${URL}/${id}`, configuracaoFetch);
    }
  }
})
