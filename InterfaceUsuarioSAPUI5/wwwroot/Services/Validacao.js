sap.ui.define([], () => {
    'use strict';

    const stringVazia = ""
    const todaOcorrenciaDeUnderline = /_/gi

    return {
        nomeValido(nome) {
            const todaOcorrenciaDeEspaco = / /gi
            const textoErroTamanhoInsuficiente = "erroInputNomeTamanhoInsuficiente"
            const textoErroCaracteresEspeciais = "erroInputNomeCaracteresEspeciaisRecebidos"
            const regexNome = "[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ ]"
            const tamanhoMinino = 3

            for (let letra of nome) {
                if (!letra.match(regexNome)) {
                    throw textoErroCaracteresEspeciais
                }
            }
            if (nome.replace(todaOcorrenciaDeEspaco, stringVazia).length < tamanhoMinino) {
                throw textoErroTamanhoInsuficiente
            }
        },

        cpfValido(cpf) {
            const textoErroPreenchidoIncorretamente = "erroInputCpfPreenchidoIncorretamente"
            const tamanhoCorreto = 14

            if (cpf.replace(todaOcorrenciaDeUnderline, stringVazia).length < tamanhoCorreto) {
                throw textoErroPreenchidoIncorretamente
            }
        },

        telefoneValido(telefone) {
            const textoErroPreenchidoIncorretamente = "erroInputTelefonePreenchidoIncorretamente"
            const tamanhoCorreto = 16

            if (telefone.replace(todaOcorrenciaDeUnderline, stringVazia).length < tamanhoCorreto) {
                throw textoErroPreenchidoIncorretamente
            }
        },

        salarioValido(salario) {
            const salarioValorMinimo = 1
            const salarioValorMAximo = 9999999999.99
            const textoErroValorInsuficiente = "erroInputSalarioValorInsuficiente"
            const textoErroValorMuitoAlto = "erroInputSalarioValorMuitoAlto"

            if (Number(salario) < salarioValorMinimo) {
                throw textoErroValorInsuficiente
            }
            if (parseFloat(salario) > salarioValorMAximo) {
                throw textoErroValorMuitoAlto
            }
        },

        dataNascimentoValida(data) {
            const textoErroDataNaoInformada = "erroInputCalendarioDataNaoInformada"

            if (!data) {
                throw textoErroDataNaoInformada
            }
        }
    }
});