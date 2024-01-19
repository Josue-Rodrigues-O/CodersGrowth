sap.ui.define([
    "../Model/Formatter",
    "sap/ui/core/date/UI5Date",
    "../Services/ListaErros"
], (Formatter, UI5Date, ListaErros) => {
    'use strict';

    const STRING_VAZIA = "";
    const TODA_OCORRENCIA_DE_UNDERLINE = /_/gi;
    let I18N;

    return {
        definirI18n(valor) {
            I18N = valor;
        },

        nomeValido(nome, id) {
            try {
                const todaOcorrenciaDeEspaco = / /gi;
                const textoErroTamanhoInsuficiente = "erroInputNomeTamanhoInsuficiente";
                const textoErroCaracteresEspeciais = "erroInputNomeCaracteresEspeciaisRecebidos";
                const regexNome = "[a-zA-ZáàâãäéèêëíìïóòôõöüúùçñÁÀÂÃÄÉÈÊËÍÌÏÓÒÔÕÖÜÚÙÇÑ ]";
                const tamanhoMinino = 3;

                for (let letra of nome) {
                    if (!letra.match(regexNome)) {
                        throw I18N.getText(textoErroCaracteresEspeciais);
                    }
                }
                if (nome.replace(todaOcorrenciaDeEspaco, STRING_VAZIA).length < tamanhoMinino) {
                    throw I18N.getText(textoErroTamanhoInsuficiente);
                }
                ListaErros.removerErrosDaLista(id);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(id, erro);
                return erro;
            }
        },

        cpfValido(cpf, id) {
            try {
                const textoErroPreenchidoIncorretamente = "erroInputCpfPreenchidoIncorretamente";
                const tamanhoCorreto = 14;

                if (cpf.replace(TODA_OCORRENCIA_DE_UNDERLINE, STRING_VAZIA).length < tamanhoCorreto) {
                    throw I18N.getText(textoErroPreenchidoIncorretamente);
                }
                ListaErros.removerErrosDaLista(id);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(id, erro);
                return erro;
            }
        },

        telefoneValido(telefone, id) {
            try {
                const textoErroPreenchidoIncorretamente = "erroInputTelefonePreenchidoIncorretamente";
                const tamanhoCorreto = 16;

                if (telefone.replace(TODA_OCORRENCIA_DE_UNDERLINE, STRING_VAZIA).length < tamanhoCorreto) {
                    throw I18N.getText(textoErroPreenchidoIncorretamente);
                }
                ListaErros.removerErrosDaLista(id);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(id, erro);
                return erro;
            }
        },

        salarioValido(salario, id) {
            try {
                const salarioValorMinimo = 1;
                const salarioValorMAximo = 9999999999.99;
                const textoErroValorInsuficiente = "erroInputSalarioValorInsuficiente";
                const textoErroValorMuitoAlto = "erroInputSalarioValorMuitoAlto";
                const textoErroValorInvalido = "erroInputSalarioValorInvalido";
                const regexSalario = "[0-9,.]";
                const todaOcorrenciaDeVirgula = /,/g;

                let salarioSemVirgula = salario.replace(todaOcorrenciaDeVirgula, STRING_VAZIA);

                if (!salarioSemVirgula || parseFloat(salarioSemVirgula) < salarioValorMinimo) {
                    throw I18N.getText(textoErroValorInsuficiente);
                }
                if (parseFloat(salario) > salarioValorMAximo) {
                    throw I18N.getText(textoErroValorMuitoAlto);
                }
                for (let digito of salario) {
                    if (!digito.match(regexSalario)) {
                        throw I18N.getText(textoErroValorInvalido);
                    }
                }
                ListaErros.removerErrosDaLista(id);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(id, erro);
                return erro;
            }
        },

        dataNascimentoValida(data, id) {
            try {
                const textoErroDataInvalida = "erroInputCalendarioEntradaInvalida";
                const textoErroDataNaoInformada = "erroInputCalendarioDataNaoInformada";
                const todaOcorrenciaDoSinalMenos = /-/gi;
                const idadeMinima = 18;
                const dataFormatada = Formatter.formatarDataParaSalvar(UI5Date.getInstance((new Date().getFullYear() - idadeMinima).toString()));
                const DataMaxima = Number(dataFormatada.replace(todaOcorrenciaDoSinalMenos, STRING_VAZIA));
                const dataRecebida = Number(data.replace(todaOcorrenciaDoSinalMenos, STRING_VAZIA));
                if (!data) {
                    throw I18N.getText(textoErroDataNaoInformada);
                }
                if (dataRecebida > DataMaxima) {
                    throw I18N.getText(textoErroDataInvalida);
                }
                ListaErros.removerErrosDaLista(id);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(id, erro);
                return erro;
            }
        }
    }
});