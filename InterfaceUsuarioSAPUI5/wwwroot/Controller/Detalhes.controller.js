sap.ui.define([
    "./BaseController",
    "../Model/Formatter",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox"
], function (BaseControler, Formatter, FuncionarioRepository, MessageBox) {
    'use strict';

    const NAMESPACE = "controle.funcionarios.Controller.Detalhes";
    const NOME_MODELO_FUNCIONARIO = "funcionario"
    const rotaListagem = "listagem";


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
                MessageBox.error(erro.message);
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
                        this.modelo(NOME_MODELO_FUNCIONARIO, response)
                    }).catch(async erro => MessageBox.warning(await erro.text()));
            } catch (erro) {
                MessageBox.error(erro.message);
            }
        },

        _remover(Controller) {
            const msgConfirmacao = "msgConfirmarAcaoRemover"
            const idFuncionario = this.modelo(NOME_MODELO_FUNCIONARIO).id;
            MessageBox.confirm(this.obterRecursoi18n(msgConfirmacao), {
                actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                emphasizedAction: MessageBox.Action.YES,
                onClose(acao) {
                    if (acao == MessageBox.Action.YES) {
                        FuncionarioRepository.remover(idFuncionario)
                        Controller.navegarPara(rotaListagem, {})
                    }
                }
            });
        },

        aoClicarEmEditar() {
            try {
                const rotaEdicao = "edicao"
                this.navegarPara(rotaEdicao, { id: this.modelo(NOME_MODELO_FUNCIONARIO).id })
            } catch (erro) {
                MessageBox.error(erro.message);
            }
        },

        aoClicarEmRemover() {
            try {
                this._remover(this)
            } catch (erro) {
                MessageBox.error(erro)
            }
        },

        aoClicarEmVoltar() {
            try {
                this.navegarPara(rotaListagem, {})
            } catch (erro) {
                MessageBox.error(erro);
            }
        },
    });
});