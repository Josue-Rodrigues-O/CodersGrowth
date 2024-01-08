sap.ui.define([], () => {
    'use strict';
    return {
        nomeValido(nome) {
            for (let letra of nome){
                if (!letra.match("[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]")) {
                    return false
                }
            }
            if (nome.trim().length >= 3) {
                return true;
            }
            return false
        },

        cpfValido(cpf) {
            
        },

        telefoneValido(telefone) {

        },

        salarioValido(salario) {

        },

        dataNacimentoValida(data) {

        }
    }
});