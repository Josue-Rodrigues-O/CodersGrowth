sap.ui.define([], () => {
  "use strict";

  const URL = "/api/Funcionario"

  return {
    obterPorId(id) {
      return fetch(`${URL}/${id}`)
    },

    obterTodos(condicao) {
      const uri = `?condicao=${condicao}`
      let URL_FILTRO = URL;
      if (condicao != (undefined || null)) {
        URL_FILTRO += uri
      }
      return fetch(URL_FILTRO);
    },

    criar(funcionario) {
      const configuracaoFetch = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(funcionario)
      }

      return fetch(URL, configuracaoFetch)
    }
  }
})
