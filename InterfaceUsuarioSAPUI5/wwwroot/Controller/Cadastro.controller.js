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
    const NOME_MODELO_FUNCIONARIO = "funcionario";
    const PROPRIEDADE_VALUE = "value";
    const STRING_VAZIA = "";
    const duasCasasDecimais = 2;
    const TODA_OCORRENCIA_DE_PONTO = /\./g;
    const TODA_OCORRENCIA_DE_VIRGULA = /,/g;
    const STRING_PONTO = ".";
    const ROTA_DETALHES = "detalhes";


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
                func.salario = Formatter.salarioText(func.salario)
                this.modelo(NOME_MODELO_FUNCIONARIO, func);
            }
        },

        _aoCoincidirRotaCriacao() {
            this._modeloFuncionario();
            this._modeloData();
            this._limparTelaCriacao();
        },

        _limparTelaCriacao() {
            const idRadioButtonSolteiro = "solteiro";
            const calendario = this.byId(ID_INPUT_CALENDARIO);
            calendario.removeAllSelectedDates();

            this._definirValueStateComoNone()
            this.byId(idRadioButtonSolteiro).setSelected(true);
            this._definirTextData()
        },

        _limparTelaEdicao(func) {
            const calendario = this.byId(ID_INPUT_CALENDARIO);
            calendario.removeAllSelectedDates();
            this._definirValueStateComoNone()
            this._definirTextData(func.dataNascimento);
        },

        _definirValueStateComoNone() {
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
            modelo.genero = Number(modelo.genero);
            let salarioSemPontos = modelo.salario
                .replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA);
            modelo.salario = Number(salarioSemPontos
                .replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO))
                .toFixed(duasCasasDecimais);
        },

        _aoCoincidirRotaEdicao(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const parametroArgumentos = "arguments";
                const idFuncionario = evento.getParameter(parametroArgumentos).id
                FuncionarioRepository.obterPorId(idFuncionario)
                    .then(response => response.json())
                    .then(response => {
                        this._modeloFuncionario(response);
                        this._modeloData();
                        this._limparTelaEdicao(response);
                    });
            })
        },

        _validarTodosOsCampos(modelo) {
            Validacao.nomeValido(modelo.nome, ID_INPUT_NOME)
            Validacao.cpfValido(modelo.cpf, ID_INPUT_CPF)
            Validacao.telefoneValido(modelo.telefone, ID_INPUT_TELEFONE)
            Validacao.salarioValido(modelo.salario, ID_INPUT_SALARIO)
            Validacao.dataNascimentoValida(modelo.dataNascimento, ID_INPUT_CALENDARIO)
        },

        _definirTextData(data) {
            const idTextData = "dataText";
            const dataVazia = "-- / -- / ----";
            data
                ? this.byId(idTextData).setText(Formatter.formatarDataParaExibir(new Date(data)))
                : this.byId(idTextData).setText(dataVazia);
        },

        _criar(modelo) {
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
                            this.navegarPara(ROTA_DETALHES, { id: response.id })
                        }
                    });
                })
                .catch(async erro => {
                    MessageBox.warning(await erro.text());
                });
        },

        _atualizar(modelo) {
            const statusNoContent = 204;
            const msgSucesso = "msgSucessoAoAtualizar";
            FuncionarioRepository.atualizar(modelo)
                .then(response => {
                    return response.status == statusNoContent
                        ? MessageBox.success(this.obterRecursoi18n(msgSucesso), {
                            onClose: () => {
                                this.navegarPara(ROTA_DETALHES, { id: modelo.id })
                            }
                        })
                        : Promise.reject(response)
                })
                .catch(async erro => {
                    MessageBox.warning(await erro.text());
                });
        },

        aoClicarEmSalvar() {
            ProcessadorDeEventos.processarEvento(() => {
                const modelo = this.modelo(NOME_MODELO_FUNCIONARIO);
                const propriedadeId = "id";

                this._validarTodosOsCampos(modelo)
                const erros = ListaErros.verificarListaDeErros(this);

                if (erros) {
                    MessageBox.warning(erros)
                } else {
                    this._formatarValoresParaSalvar(modelo);
                    modelo.hasOwnProperty(propriedadeId)
                        ? this._atualizar(modelo)
                        : this._criar(modelo);
                }
            });
        },

        aoClicarEmVoltar() {
            ProcessadorDeEventos.processarEvento(() => {
                const msg_confirmar = "msgConfirmarAcaoVoltar";
                this._navegarParaListagem(this.obterRecursoi18n(msg_confirmar));
            });
        },

        aoClicarEmCancelar() {
            ProcessadorDeEventos.processarEvento(() => {
                const msg_confirmar = "msgConfirmarAcaoCancelar";
                this._navegarParaListagem(this.obterRecursoi18n(msg_confirmar));
            });
        },

        aoMudarNome(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const erro = Validacao.nomeValido(evento.getParameter(PROPRIEDADE_VALUE), ID_INPUT_NOME);
                this._definirValueState(evento, erro)
            });
        },

        aoMudarCpf(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const erro = Validacao.cpfValido(evento.getParameter(PROPRIEDADE_VALUE), ID_INPUT_CPF);
                this._definirValueState(evento, erro)
            });
        },

        aoMudarTelefone(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const erro = Validacao.telefoneValido(evento.getParameter(PROPRIEDADE_VALUE), ID_INPUT_TELEFONE);
                this._definirValueState(evento, erro)
            });
        },

        aoMudarSalario(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                let texto = evento.getSource().getValue();

                if (texto.match(TODA_OCORRENCIA_DE_PONTO)) {
                    texto = texto.replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA);
                }

                const erro = Validacao.salarioValido(texto, ID_INPUT_SALARIO);

                this._definirValueState(evento, erro)
                evento.getSource().setValue(Formatter.salarioText(parseFloat(texto.replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO)).toFixed(duasCasasDecimais)));
            });
        },

        aoSelecionarUmaData(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const primeiroArray = 0;
                let data = evento.getSource().getSelectedDates()[primeiroArray].getStartDate();
                let dataFormatada = Formatter.formatarDataParaSalvar(data);
                this._definirTextData(data)
                Validacao.dataNascimentoValida(ID_INPUT_CALENDARIO);

                this.modelo(NOME_MODELO_FUNCIONARIO).dataNascimento = dataFormatada;
            });
        },

        _navegarParaListagem(mensagem) {
            const rotaListagem = "listagem";

            MessageBox.confirm(mensagem, {
                actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                emphasizedAction: MessageBox.Action.YES,
                onClose: (acao) => {
                    if (acao == MessageBox.Action.YES) {
                        this.navegarPara(rotaListagem, {})
                    }
                }
            });
        }
    })
});