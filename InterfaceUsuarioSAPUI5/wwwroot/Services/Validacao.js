sap.ui.define([
    "../Model/Formatter",
    "sap/ui/core/date/UI5Date"
], (Formatter, UI5Date) => {
    'use strict';

    const STRING_VAZIA = ""
    const TODA_OCORRENCIA_DE_UNDERLINE = /_/gi

    return {
        nomeValido(nome) {
            const todaOcorrenciaDeEspaco = / /gi
            const textoErroTamanhoInsuficiente = "erroInputNomeTamanhoInsuficiente"
            const textoErroCaracteresEspeciais = "erroInputNomeCaracteresEspeciaisRecebidos"
            const regexNome = "[a-zA-ZáàâãäéèêëíìïóòôõöüúùçñÁÀÂÃÄÉÈÊËÍÌÏÓÒÔÕÖÜÚÙÇÑ ]"
            const tamanhoMinino = 3

            for (let letra of nome) {
                if (!letra.match(regexNome)) {
                    throw textoErroCaracteresEspeciais
                }
            }
            if (nome.replace(todaOcorrenciaDeEspaco, STRING_VAZIA).length < tamanhoMinino) {
                throw textoErroTamanhoInsuficiente
            }
        },

        cpfValido(cpf) {
            const textoErroPreenchidoIncorretamente = "erroInputCpfPreenchidoIncorretamente"
            const tamanhoCorreto = 14

            if (cpf.replace(TODA_OCORRENCIA_DE_UNDERLINE, STRING_VAZIA).length < tamanhoCorreto) {
                throw textoErroPreenchidoIncorretamente
            }
        },

        telefoneValido(telefone) {
            const textoErroPreenchidoIncorretamente = "erroInputTelefonePreenchidoIncorretamente"
            const tamanhoCorreto = 16

            if (telefone.replace(TODA_OCORRENCIA_DE_UNDERLINE, STRING_VAZIA).length < tamanhoCorreto) {
                throw textoErroPreenchidoIncorretamente
            }
        },

        salarioValido(salario) {
            const salarioValorMinimo = 1
            const salarioValorMAximo = 9999999999.99
            const textoErroValorInsuficiente = "erroInputSalarioValorInsuficiente"
            const textoErroValorMuitoAlto = "erroInputSalarioValorMuitoAlto"
            const textoErroValorInvalido = "erroInputSalarioValorInvalido"
            const regexSalario = "[0-9,.]"
            const todaOcorrenciaDeVirgula = /,/g

            let salarioSemVirgula = salario.replace(todaOcorrenciaDeVirgula, STRING_VAZIA)

            if (!salarioSemVirgula ||parseFloat(salarioSemVirgula) < salarioValorMinimo) {
                throw textoErroValorInsuficiente
            }
            if (parseFloat(salario) > salarioValorMAximo) {
                throw textoErroValorMuitoAlto
            }
            for (let digito of salario) {
                if (!digito.match(regexSalario)) {
                    throw textoErroValorInvalido
                }
            }
        },

        dataNascimentoValida(data) {
            const textoErroDataInvalida = "erroInputCalendarioEntradaInvalida"
            const textoErroDataNaoInformada = "erroInputCalendarioDataNaoInformada"
            const todaOcorrenciaDoSinalMenos = /-/gi
            const idadeMinima = 18
            const dataFormatada = Formatter.formatarData(UI5Date.getInstance((new Date().getFullYear() - idadeMinima).toString()));
            const DataMaxima = Number(dataFormatada.replace(todaOcorrenciaDoSinalMenos, STRING_VAZIA))
            const dataRecebida = Number(data.replace(todaOcorrenciaDoSinalMenos, STRING_VAZIA))
            console.log(DataMaxima + "\n" + dataRecebida)
            if (!data) {
                throw textoErroDataNaoInformada
            }

            if (dataRecebida > DataMaxima) {
                throw textoErroDataInvalida
            }

        }
    }
});