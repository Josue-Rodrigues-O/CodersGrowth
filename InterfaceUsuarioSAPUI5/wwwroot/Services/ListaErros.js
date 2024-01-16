sap.ui.define([], function() {
    "use strict";
    
    let LISTA_DE_ERROS = []
    
    return {
        iniciarLista(novoValorLista) {
            LISTA_DE_ERROS = novoValorLista
        },

        _verificarListaDeErros(controller){
            const stringVazia = ""
            const idCalendario = "calendarDataNascimento";
            const quebraDeLinha = "\n";
            const statusErro = "Error"
                if (LISTA_DE_ERROS.length > 0) {
                    let erros = stringVazia;
                    LISTA_DE_ERROS.forEach((elemento) => {
                        if (elemento.id != idCalendario) {
                            controller.byId(elemento.id).setValueState(statusErro).setValueStateText(elemento.erro);
                        }
                        erros += elemento.erro + quebraDeLinha;
                    })
                    throw erros;
                }
        },

        _adicionarErroNaLista(id, erro) {
            if (LISTA_DE_ERROS.find(x => x.id == id)) {
                let index = LISTA_DE_ERROS.findIndex(x => x.id == id);
                LISTA_DE_ERROS[index].erro = erro;
            } else {
                LISTA_DE_ERROS.push({
                    id: id,
                    erro: erro
                });
            }
        },

        _removerErrosDaLista(id) {
            const apenasUmaOcorrencia = 1;
            if (LISTA_DE_ERROS.find(x => x.id == id)) {
                let index = LISTA_DE_ERROS.findIndex(x => x.id == id);
                LISTA_DE_ERROS.splice(index, apenasUmaOcorrencia);
            }
        },
    }
});