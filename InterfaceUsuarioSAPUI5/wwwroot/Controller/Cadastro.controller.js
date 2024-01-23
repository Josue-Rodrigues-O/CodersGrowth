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
    const STRING_VAZIA = "";
    const DUAS_CASAS_DECIMAIS = 2;
    const TODA_OCORRENCIA_DE_PONTO = /\./g
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
            this._limparTela();
        },

        _aoCoincidirRotaEdicao(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const parametroArgumentos = "arguments";
                const idFuncionario = evento.getParameter(parametroArgumentos).id
                this._obterPorId(idFuncionario);
            })
        },

        _limparTela(func) {
            const calendario = this.byId(ID_INPUT_CALENDARIO);
            this._definirValueStateComoNone()
            calendario.removeAllSelectedDates();
            const idRadioButtonSolteiro = "solteiro";
            this.byId(idRadioButtonSolteiro).setSelected(true);
            func
                ? this._definirTextData(func.dataNascimento)
                : this._definirTextData();
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
            let salarioSemPontos = modelo.salario.replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA);
            modelo.genero = Number(modelo.genero);
            modelo.salario = Number(salarioSemPontos
                .replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO))
                .toFixed(DUAS_CASAS_DECIMAIS);
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
                                this.navegarPara(ROTA_DETALHES, { id: response.id })
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

        _atualizar(modelo) {
            try {
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
            } catch (error) {
                MessageBox.error(error.message);
            }
        },

        _obterPorId(id) {
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
                this._navegarParaTelaListagem(this.obterRecursoi18n(msg_confirmar));
            });
        },

        aoClicarEmCancelar() {
            ProcessadorDeEventos.processarEvento(() => {
                const msg_confirmar = "msgConfirmarAcaoCancelar";
                this._navegarParaTelaListagem(this.obterRecursoi18n(msg_confirmar));
            });
        },

        aoMudarNome(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const erro = Validacao.nomeValido(evento.getSource().getValue(), ID_INPUT_NOME);
                this._definirValueState(evento, erro)
            });
        },

        aoMudarCpf(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const erro = Validacao.cpfValido(evento.getSource().getValue(), ID_INPUT_CPF);
                this._definirValueState(evento, erro)
            });
        },

        aoMudarTelefone(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const erro = Validacao.telefoneValido(evento.getSource().getValue(), ID_INPUT_TELEFONE);
                this._definirValueState(evento, erro)
            });
        },

        aoMudarSalario(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                let texto = evento.getSource().getValue();
                let textoSemPonto = texto.replace(TODA_OCORRENCIA_DE_PONTO, STRING_VAZIA)
                const erro = Validacao.salarioValido(textoSemPonto, ID_INPUT_SALARIO);
                this._definirValueState(evento, erro);
                let salarioSemVirgula = textoSemPonto.replace(TODA_OCORRENCIA_DE_VIRGULA, STRING_PONTO);
                let salarioFormatado = Formatter.salarioText(parseFloat(salarioSemVirgula).toFixed(DUAS_CASAS_DECIMAIS));
                evento.getSource().setValue(salarioFormatado);
            });
        },

        aoSelecionarUmaData(evento) {
            ProcessadorDeEventos.processarEvento(() => {
                const primeiroArray = 0;
                let data = evento.getSource().getSelectedDates()[primeiroArray].getStartDate();
                let dataFormatada = Formatter.formatarDataParaSalvar(data);
                this._definirTextData(data)
                Validacao.dataNascimentoValida(dataFormatada, ID_INPUT_CALENDARIO);
                this.modelo(NOME_MODELO_FUNCIONARIO).dataNascimento = dataFormatada;
            });
        },

        _navegarParaTelaListagem(mensagem) {
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