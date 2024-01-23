sap.ui.define([
    "./BaseController",
    "../Model/Formatter",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox",
    "../Services/ProcessadorDeEventos"
], function (BaseControler, Formatter, FuncionarioRepository, MessageBox, ProcessadorDeEventos) {
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
            ProcessadorDeEventos.processarEvento(() => {
                const parametroArgumentos = "arguments";
                const idFuncionario = evento.getParameter(parametroArgumentos).id;
                this._obterFuncionario(idFuncionario);
            })
        },

        _obterFuncionario(id) {
            try {
                FuncionarioRepository.obterPorId(id)
                    .then(response => {
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(response => {
                        this.modelo(NOME_MODELO_FUNCIONARIO, response)
                    }).catch(async erro => MessageBox.warning(await erro.text()));
            } catch (erro) {
                MessageBox.error(erro.message);
            }
        },

        _removerFuncionario(id) {
            try {
                FuncionarioRepository.remover(id)
            } catch (error) {
                MessageBox.error(error.message)
            }
        },

        aoClicarEmEditar() {
            ProcessadorDeEventos.processarEvento(() => {
                const rotaEdicao = "edicao"
                this.navegarPara(rotaEdicao, { id: this.modelo(NOME_MODELO_FUNCIONARIO).id })
            });
        },

        aoClicarEmRemover() {
            ProcessadorDeEventos.processarEvento(() => {
                const msgConfirmacao = "msgConfirmarAcaoRemover"
                const msgSucesso = "msgSucessoAoRemover"
                const idFuncionario = this.modelo(NOME_MODELO_FUNCIONARIO).id;
                MessageBox.confirm(this.obterRecursoi18n(msgConfirmacao), {
                    actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                    emphasizedAction: MessageBox.Action.YES,
                    onClose: (acao) => {
                        if (acao == MessageBox.Action.YES) {
                            this._removerFuncionario(idFuncionario)
                            MessageBox.success(this.obterRecursoi18n(msgSucesso), {
                                onClose: () => {
                                    this.navegarPara(rotaListagem, {})
                                }
                            });
                        }
                    }
                });
            });
        },

        aoClicarEmVoltar() {
            ProcessadorDeEventos.processarEvento(() => {
                this.navegarPara(rotaListagem, {})
            });
        }
    });
});