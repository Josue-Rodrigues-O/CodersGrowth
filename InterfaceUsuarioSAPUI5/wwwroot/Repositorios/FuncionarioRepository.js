sap.ui.define([], () => {
  "use strict";

  const URL = "/api/Funcionario";

  return {
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
    
    obterTodos(filtroNome) {
      const uri = `?filtroNome=${filtroNome}`;
      let query = URL;
      if (filtroNome != (undefined || null)) {
        query += uri;
      }
      return fetch(query);
    },

    obterPorId(id) {
      return fetch(`${URL}/${id}`);
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
