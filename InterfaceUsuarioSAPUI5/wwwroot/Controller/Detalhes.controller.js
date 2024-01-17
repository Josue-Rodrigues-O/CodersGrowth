sap.ui.define([
    "./BaseController",
    "../Model/Formatter",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox"
], function (BaseControler, Formatter, FuncionarioRepository, MessageBox) {
    'use strict';

    const NAMESPACE = "controle.funcionarios.Controller.Detalhes";
    const nomeModeloFuncionario = "funcionario"


    return BaseControler.extend(NAMESPACE, {

        formatter: Formatter,

        onInit() {
            const rotaDetalhes = "detalhes"
            this.vincularRota(rotaDetalhes, this._aoCoincidirRota)
        },

        _aoCoincidirRota(evento) {
            try {
                const parametroArgumentos = "arguments";
                const idFuncionario = evento.getParameter(parametroArgumentos).id;
                this._obterPorId(idFuncionario);
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        },

        _obterPorId(id) {
            try {
                FuncionarioRepository.obterPorId(id)
                    .then(response => {
                        if (response.ok) {
                            return response.json();
                        } else {
                            return Promise.reject(response);
                        }
                    })
                    .then(response => {
                        this.modelo(nomeModeloFuncionario, response)
                    }).catch(async erro => MessageBox.warning(await erro.text()));
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        },

        aoClicarEmEditar() {
            try {
                const rotaEdicao = "edicao"
                this.navegarPara(rotaEdicao, { id: this.modelo(nomeModeloFuncionario).id })
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        },

        aoClicarEmRemover() {
            
        },

        aoClicarEmVoltar() {
            try {
                const rotaListagem = "listagem";
                this.navegarPara(rotaListagem, {})
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        }
    });
});