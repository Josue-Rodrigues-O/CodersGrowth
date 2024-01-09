sap.ui.define([], () => {
    'use strict';
    return {
        nomeValido(nome) {
            for (let letra of nome) {
                if (!letra.match("[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]")) {
                    throw "O campo nome não pode conter caracteres especiais!"
                }
            }
            if (nome.replace(/ /gi, "").length < 3) {
                throw "O nome não pode conter menos de três letras!"
            }
        },

        cpfValido(cpf) {
            if (cpf.replace(/_/gi, "").length < 14) {
                throw "Preencha o campo CPF corretamente!"
            }
        },

        telefoneValido(telefone) {
            if (telefone.replace(/_/gi, "").length < 16) {
                throw "Preencha o campo telefone corretamente!"
            }
        },

        salarioValido(salario) {
            if (Number(salario) <= 0) {
                throw "O campo salário não pode ficar vazio!"
            }
            if (salario.length - 2 > 11) {
                throw "O campo salário não pode ser maior que 9.999.999.999,99!"
            }
        },

        dataNascimentoValido(data) {
            if(!data){

            }
        }
    }
});