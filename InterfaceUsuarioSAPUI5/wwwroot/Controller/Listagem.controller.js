sap.ui.define([
    "./BaseController",
    "../Model/Formatter",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox"
], function (BaseControler, Formatter, FuncionarioRepository, MessageBox) {
    "use strict";

    const NAMESPACE = "controle.funcionarios.Controller.Listagem";
    const MODELO_TABELA = "modeloTabelaFuncionarios";

    return BaseControler.extend(NAMESPACE, {

        formatter: Formatter,

        onInit() {
            const rotaListagem = "listagem";
            this.vincularRota(rotaListagem, this._aoCoincidirRota)
        },

        _aoCoincidirRota() {
            this._obterFuncionarios();
        },

        _obterFuncionarios(condicao) {
            try {
                FuncionarioRepository.obterTodos(condicao)
                    .then(response => {
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(response => this.modelo(MODELO_TABELA, response))
                    .catch(async erro => MessageBox.warning(await erro.text()));
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        },

        aoPesquisar(condicao) {
            try {
                const parametroQuery = "query";
                const stringCondicao = condicao.getParameter(parametroQuery);
                this._obterFuncionarios(stringCondicao);
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        },

        aoClicarEmAdicionar() {
            try {
                const rotaCadastro = "cadastro";
                this.navegarPara(rotaCadastro, {})
            }
            catch (erro) {
                MessageBox.warning(erro.message);
            }
        },

        aoClicarNaLinha(linhaSelecionada) {
            try {
                const propriedadeId = "id";
                const rotaDetalhes = "detalhes";
                const recursosLinhaSelecionada = linhaSelecionada.getSource().getBindingContext(MODELO_TABELA);
                const idFuncionario = recursosLinhaSelecionada.getProperty(propriedadeId)

                this.navegarPara(rotaDetalhes, { id: idFuncionario })
            } catch (erro) {
                MessageBox.warning(erro.message);
            }
        }
    });
});