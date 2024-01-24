sap.ui.define([
    "../Services/ListaErros"
], (ListaErros) => {
    'use strict';

    const STRING_VAZIA = "";
    const TODA_OCORRENCIA_DE_UNDERLINE = /_/gi;
    let I18N;

    return {
        definirI18n(valor) {
            I18N = valor;
        },

        validarNome(nome, id) {
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

        validarCpf(cpf, id) {
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

        validarTelefone(telefone, id) {
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

        validarSalario(salario, id) {
            try {
                const salarioValorMinimo = 0;
                const salarioValorMaximo = 9999999999.99;
                const textoErroValorInsuficiente = "erroInputSalarioValorInsuficiente";
                const textoErroValorMuitoAlto = "erroInputSalarioValorMuitoAlto";
                const textoErroValorInvalido = "erroInputSalarioValorInvalido";
                const regexSalario = "[0-9,.]";

                let salarioSemPonto = salario.replace(/\./g, "");

                if (!salario || parseFloat(salario) <= salarioValorMinimo) {
                    throw I18N.getText(textoErroValorInsuficiente);
                }
                if (parseFloat(salarioSemPonto) > salarioValorMaximo) {
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

        validarDataNascimento(data, id) {
            try {
                const textoErroDataNaoInformada = "erroInputCalendarioDataNaoInformada";

                if (!data) {
                    throw I18N.getText(textoErroDataNaoInformada);
                }
                ListaErros.removerErrosDaLista(id);
            } catch (erro) {
                ListaErros.adicionarErroNaLista(id, erro);
                return erro;
            }
        }
    }
});