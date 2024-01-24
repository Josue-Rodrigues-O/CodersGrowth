sap.ui.define([
    "./BaseController",
    "../Repositorios/FuncionarioRepository",
    "sap/m/MessageBox",
    "../Model/Formatter",
    "sap/ui/core/date/UI5Date",
    "../Services/Validacao",
    "../Services/ListaErros",
    "../Services/ProcessadorDeEventos"
], function (BaseController, FuncionarioRepository, MessageBox, Formatter, UI5Date, Validacao, ListaErros, ProcessadorDeEventos) {
    "use strict";

    const NAMESPACE = "controle.funcionarios.controller.Cadastro";
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_CPF = "inputCpf";
    const ID_INPUT_TELEFONE = "inputTelefone";
    const ID_INPUT_SALARIO = "inputSalario";
    const ID_INPUT_CALENDARIO = "calendarDataNascimento";
    const ID_TITULO_PAGINA = "idTituloPagina";
    const NOME_MODELO_FUNCIONARIO = "funcionario";
    const STRING_VAZIA = "";

    return BaseController.extend(NAMESPACE, {
        onInit() {
            const modeloI18n = "i18n";
            const rotaCadastro = "cadastro";
            const rotaEdicao = "edicao"
            this.vincularRota(rotaCadastro, this._aoCoincidirRotaCriacao)
            this.vincularRota(rotaEdicao, this._aoCoincidirRotaEdicao)
            Validacao.definirI18n(this.getOwnerComponent().getModel(modeloI18n).getResourceBundle());
        },

        _modeloData() {
            const idadeMaxima = 70;
            const idadeMinima = 14;
            const modeloCalendario = "calendario";
            const calendario = {
                maxData: UI5Date.getInstance((new Date().getFullYear() - idadeMinima).toString()),
                minData: UI5Date.getInstance((new Date().getFullYear() - idadeMaxima).toString())
            }
            this.modelo(modeloCalendario, calendario)
        },

        _modeloFuncionario(func) {
            let funcionario;
            if (func == (null || undefined)) {
                funcionario = {
                    nome: STRING_VAZIA,
                    cpf: STRING_VAZIA,
                    telefone: STRING_VAZIA,
                    salario: STRING_VAZIA,
                    ehCasado: false,
                    genero: STRING_VAZIA,
                    dataNascimento: STRING_VAZIA
                }
                this.modelo(NOME_MODELO_FUNCIONARIO, funcionario);
            } else {
                func.salario = Formatter.formatarSalario(func.salario)
                this.modelo(NOME_MODELO_FUNCIONARIO, func);
            }
        },

        _limparTela(func) {
            const calendario = this.byId(ID_INPUT_CALENDARIO);
            this._limparValueStateDosCampos();
            calendario.removeAllSelectedDates();
            const idRadioButtonSolteiro = "idRadioButtonSolteiro";
            const idRadioButtonCasado = "idRadioButtonCasado";
            if (func) {
                this._definirDataDeExibicao(func.dataNascimento)
                this.byId(idRadioButtonSolteiro).setSelected(!func.ehCasado);
                this.byId(idRadioButtonCasado).setSelected(func.ehCasado);
            } else {
                this.byId(idRadioButtonSolteiro).setSelected(true);
                this.byId(idRadioButtonCasado).setSelected(false);
                this._definirDataDeExibicao();
            }
        },

        _limparValueStateDosCampos() {
            const STATUS_NENHUM = "None";
            this.byId(ID_INPUT_NOME).setValueState(STATUS_NENHUM);
            this.byId(ID_INPUT_CPF).setValueState(STATUS_NENHUM);
            this.byId(ID_INPUT_TELEFONE).setValueState(STATUS_NENHUM);
            this.byId(ID_INPUT_SALARIO).setValueState(STATUS_NENHUM);
        },

        _definirValueState(objeto, erro) {
            const statusErro = "Error";
            const statusSucesso = "Success";
            erro
                ? objeto.getSource().setValueState(statusErro).setValueStateText(erro)
                : objeto.getSource().setValueState(statusSucesso)
        },

        _formatarValoresParaSalvar(modelo) {
            const duasCasasDecimais = 2;
            let salarioSemPontos = this._removerTodosOsPontos(modelo.salario);
            modelo.genero = Number(modelo.genero);
            modelo.salario = Number(this._substituirVirgulaPorPonto(salarioSemPontos))
                .toFixed(duasCasasDecimais);
        },

        _validarTodosOsCampos(modelo) {
            Validacao.validarNome(modelo.nome, ID_INPUT_NOME);
            Validacao.validarCpf(modelo.cpf, ID_INPUT_CPF);
            Validacao.validarTelefone(modelo.telefone, ID_INPUT_TELEFONE);
            Validacao.validarSalario(modelo.salario, ID_INPUT_SALARIO);
            Validacao.validarDataNascimento(modelo.dataNascimento, ID_INPUT_CALENDARIO);
            return ListaErros.verificarListaDeErros(this);
        },

        _definirDataDeExibicao(data) {
            const idTextData = "dataText";
            const dataVazia = "-- / -- / ----";
            data
                ? this.byId(idTextData).setText(Formatter.formatarDataParaExibir(new Date(data)))
                : this.byId(idTextData).setText(dataVazia);
        },

        _removerTodosOsPontos(texto) {
            const todaOcorrenciaDePonto = /\./g
            return texto.replace(todaOcorrenciaDePonto, STRING_VAZIA)
        },

        _substituirVirgulaPorPonto(texto) {
            const stringPonto = ".";
            const TodaOcorrenciaDeVirgula = /,/g;
            return texto.replace(TodaOcorrenciaDeVirgula, stringPonto)
        },

        _adicionarFuncionario(modelo) {
            try {
                const statusCreated = 201;
                const msgSucesso = "msgSucessoAoCadastrar";
                FuncionarioRepository.criar(modelo)
                    .then(response => {
                        return response.status == statusCreated
                            ? response.json()
                            : Promise.reject(response)
                    })
                    .then(response => {
                        MessageBox.success(this.obterRecursoi18n(msgSucesso), {
                            onClose: () => {
                                this._navegarParaTelaDetalhes(response.id)
                            }
                        });
                    })
                    .catch(async erro => {
                        MessageBox.warning(await erro.text());
                    });
            } catch (error) {
                MessageBox.error(error.message);
            }
        },

        _atualizarFuncionario(modelo) {
            try {
                const statusNoContent = 204;
                const msgSucesso = "msgSucessoAoAtualizar";
                FuncionarioRepository.atualizar(modelo)
                    .then(response => {
                        return response.status == statusNoContent
                            ? MessageBox.success(this.obterRecursoi18n(msgSucesso), {
                                onClose: () => {
                                    this._navegarParaTelaDetalhes(modelo.id)
                                }
                            })
                            : Promise.reject(response)
                    })
                    .catch(async erro => {
                        MessageBox.warning(await erro.text());
                    });
            } catch (error) {
                MessageBox.error(error.message);
            }
        },

        _obterFuncionario(id) {
            try {
                FuncionarioRepository.obterPorId(id)
                    .then(response => response.json())
                    .then(response => {
                        this._modeloFuncionario(response);
                        this._modeloData();
                        this._limparTela(response);
                    });
            } catch (error) {
                MessageBox.error(error.message);
            }
        },

        aoClicarEmSalvar() {
            ProcessadorDeEventos.processarEvento(() => {
                const modelo = this.modelo(NOME_MODELO_FUNCIONARIO);
                const propriedadeId = "id";

                const erros = this._validarTodosOsCampos(modelo);

                if (erros) {
                    MessageBox.warning(erros)
                } else {
                    this._formatarValoresParaSalvar(modelo);
                    modelo.hasOwnProperty(propriedadeId)
                        ? this._atualizarFuncionario(modelo)
                        : this._adicionarFuncionario(modelo);
                }
            });
        },

        aoClicarEmVoltar() {
            ProcessadorDeEventos.processarEvento(() => {
                const msg_confirmar = "msgConfirmarAcaoVoltar";
                this.messageBoxConfirmacao(this.obterRecursoi18n(msg_confirmar), () => { this._navegarParaTelaListagem() })
            });
        },

        aoClicarEmCancelar() {
            ProcessadorDeEventos.processarEvento(() => {
                const msg_confirmar = "msgConfirmarAcaoCancelar";
                this.messageBoxConfirmacao(this.obterRecursoi18n(msg_confirmar), () => { this._navegarParaTelaListagem() })
            });
        },

        aoMudarNome(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const erro = Validacao.validarNome(evento.getSource().getValue(), ID_INPUT_NOME);
                this._definirValueState(evento, erro)
            });
        },

        aoMudarCpf(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const erro = Validacao.validarCpf(evento.getSource().getValue(), ID_INPUT_CPF);
                this._definirValueState(evento, erro)
            });
        },

        aoMudarTelefone(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const erro = Validacao.validarTelefone(evento.getSource().getValue(), ID_INPUT_TELEFONE);
                this._definirValueState(evento, erro)
            });
        },

        aoMudarSalario(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const salario = evento.getSource().getValue();
                const salarioSemPonto = this._removerTodosOsPontos(salario)
                const salarioSemVirgula = this._substituirVirgulaPorPonto(salarioSemPonto);
                const salarioFormatado = Formatter.formatarSalario(salarioSemVirgula);
                const erro = Validacao.validarSalario(salarioFormatado, ID_INPUT_SALARIO);
                this._definirValueState(evento, erro);
                evento.getSource().setValue(salarioFormatado);
            });
        },

        aoSelecionarUmaData(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const primeiroArray = 0;
                let data = evento.getSource().getSelectedDates()[primeiroArray].getStartDate();
                let dataFormatada = Formatter.formatarDataParaSalvar(data);
                this._definirDataDeExibicao(dataFormatada)
                Validacao.validarDataNascimento(dataFormatada, ID_INPUT_CALENDARIO);
                this.modelo(NOME_MODELO_FUNCIONARIO).dataNascimento = dataFormatada;
            });
        },

        _aoCoincidirRotaCriacao() {
            ProcessadorDeEventos.processarEvento(() => {
                const textoTituloPagina = "tituloPaginaCriacao";
                this._modeloFuncionario();
                this._modeloData();
                this._limparTela();
                this.byId(ID_TITULO_PAGINA).setText(this.obterRecursoi18n(textoTituloPagina))
            });
        },

        _aoCoincidirRotaEdicao(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const textoTituloPagina = "tituloPaginaEdicao";
                const parametroArgumentos = "arguments";
                const idFuncionario = evento.getParameter(parametroArgumentos).id
                this._obterFuncionario(idFuncionario);
                this.byId(ID_TITULO_PAGINA).setText(this.obterRecursoi18n(textoTituloPagina))
            });
        },

        _navegarParaTelaListagem() {
            const rotaListagem = "listagem";
            this.navegarPara(rotaListagem, {})
        },

        _navegarParaTelaDetalhes(id) {
            const rotaDetalher = "detalhes"
            this.navegarPara(rotaDetalher, { id: id })
        }
    })
});