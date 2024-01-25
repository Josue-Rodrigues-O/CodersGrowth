sap.ui.define([
    "./BaseController",
    "../Model/Formatter",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox",
    "../Services/ProcessadorDeEventos"
], function (BaseControler, Formatter, FuncionarioRepository, MessageBox, ProcessadorDeEventos) {
    "use strict";

    const NAMESPACE = "controle.funcionarios.Controller.Listagem";
    const MODELO_TABELA = "modeloTabelaFuncionarios";

    return BaseControler.extend(NAMESPACE, {
        formatter: Formatter,

        onInit() {
            const rotaListagem = "listagem";
            this.vincularRota(rotaListagem, this._aoCoincidirRota);
        },

        _obterFuncionarios(condicao) {
            try {
                FuncionarioRepository.obterTodos(condicao)
                    .then(response => {
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(response => this.modelo(MODELO_TABELA, response))
                    .catch(async erro => MessageBox.warning(await erro.text()));
            } catch (error) {
                MessageBox.error(error.message);
            }
        },

        aoPesquisar(filtroNome) {
            ProcessadorDeEventos.processarEvento(() => {
                const parametroQuery = "query";
                const stringCondicao = filtroNome.getParameter(parametroQuery);
                this._obterFuncionarios(stringCondicao);
            });
        },

        aoClicarEmAdicionar() {
            ProcessadorDeEventos.processarEvento(() => {
                const rotaCadastro = "cadastro";
                this.navegarPara(rotaCadastro, {})
            });
        },

        aoClicarNaLinha(linhaSelecionada) {
            ProcessadorDeEventos.processarEvento(() => {
                const propriedadeId = "id";
                const rotaDetalhes = "detalhes";
                const recursosLinhaSelecionada = linhaSelecionada.getSource().getBindingContext(MODELO_TABELA);
                const idFuncionario = recursosLinhaSelecionada.getProperty(propriedadeId)

                this.navegarPara(rotaDetalhes, { id: idFuncionario })
            });
        },

        _aoCoincidirRota() {
            this._obterFuncionarios();
        }
    });
});