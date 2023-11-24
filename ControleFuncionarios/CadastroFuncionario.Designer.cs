namespace ControleFuncionarios
{
    partial class CadastroFuncionario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LblNome = new Label();
            TxtNome = new TextBox();
            LblCpf = new Label();
            LblTelefone = new Label();
            LbllSalario = new Label();
            LblEstadoCivil = new Label();
            LblDataNascimento = new Label();
            LblGenero = new Label();
            BtnSalvar = new Button();
            BtnCancelar = new Button();
            tableLayout1 = new TableLayoutPanel();
            TxtSalario = new TextBox();
            tableLayoutEstadoCivil = new TableLayoutPanel();
            RadSolteiro = new RadioButton();
            RadCasado = new RadioButton();
            ComboGenero = new ComboBox();
            TxtCpf = new MaskedTextBox();
            TxtTelefone = new MaskedTextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            Calendario = new MonthCalendar();
            tableLayout1.SuspendLayout();
            tableLayoutEstadoCivil.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // LblNome
            // 
            LblNome.AutoSize = true;
            LblNome.Location = new Point(3, 0);
            LblNome.Name = "LblNome";
            LblNome.Size = new Size(40, 15);
            LblNome.TabIndex = 0;
            LblNome.Text = "Nome";
            // 
            // TxtNome
            // 
            TxtNome.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtNome.Location = new Point(77, 3);
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(366, 23);
            TxtNome.TabIndex = 1;
            TxtNome.KeyDown += TxtNome_KeyDown;
            TxtNome.KeyPress += TxtNome_KeyPress;
            // 
            // LblCpf
            // 
            LblCpf.AutoSize = true;
            LblCpf.Location = new Point(3, 71);
            LblCpf.Name = "LblCpf";
            LblCpf.Size = new Size(28, 15);
            LblCpf.TabIndex = 2;
            LblCpf.Text = "CPF";
            // 
            // LblTelefone
            // 
            LblTelefone.AutoSize = true;
            LblTelefone.Location = new Point(3, 142);
            LblTelefone.Name = "LblTelefone";
            LblTelefone.Size = new Size(51, 15);
            LblTelefone.TabIndex = 3;
            LblTelefone.Text = "Telefone";
            // 
            // LbllSalario
            // 
            LbllSalario.AutoSize = true;
            LbllSalario.Location = new Point(3, 213);
            LbllSalario.Name = "LbllSalario";
            LbllSalario.Size = new Size(42, 15);
            LbllSalario.TabIndex = 4;
            LbllSalario.Text = "Salário";
            // 
            // LblEstadoCivil
            // 
            LblEstadoCivil.AutoSize = true;
            LblEstadoCivil.Location = new Point(3, 284);
            LblEstadoCivil.Name = "LblEstadoCivil";
            LblEstadoCivil.Size = new Size(66, 15);
            LblEstadoCivil.TabIndex = 5;
            LblEstadoCivil.Text = "Estado civil";
            // 
            // LblDataNascimento
            // 
            LblDataNascimento.AutoSize = true;
            LblDataNascimento.Location = new Point(3, 0);
            LblDataNascimento.Name = "LblDataNascimento";
            LblDataNascimento.Size = new Size(69, 30);
            LblDataNascimento.TabIndex = 6;
            LblDataNascimento.Text = "Data de nascimento";
            // 
            // LblGenero
            // 
            LblGenero.AutoSize = true;
            LblGenero.Location = new Point(3, 355);
            LblGenero.Name = "LblGenero";
            LblGenero.Size = new Size(45, 15);
            LblGenero.TabIndex = 7;
            LblGenero.Text = "Gênero";
            // 
            // BtnSalvar
            // 
            BtnSalvar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnSalvar.Location = new Point(3, 3);
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new Size(80, 25);
            BtnSalvar.TabIndex = 12;
            BtnSalvar.Text = "Salvar";
            BtnSalvar.UseVisualStyleBackColor = true;
            BtnSalvar.Click += Ao_Clicar_Em_Salvar;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnCancelar.Location = new Point(89, 3);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(80, 25);
            BtnCancelar.TabIndex = 13;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += Ao_Clicar_Em_Cancelar;
            // 
            // tableLayout1
            // 
            tableLayout1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayout1.ColumnCount = 2;
            tableLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayout1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 372F));
            tableLayout1.Controls.Add(TxtSalario, 1, 3);
            tableLayout1.Controls.Add(LblNome, 0, 0);
            tableLayout1.Controls.Add(LblCpf, 0, 1);
            tableLayout1.Controls.Add(LblTelefone, 0, 2);
            tableLayout1.Controls.Add(LbllSalario, 0, 3);
            tableLayout1.Controls.Add(LblEstadoCivil, 0, 4);
            tableLayout1.Controls.Add(LblGenero, 0, 5);
            tableLayout1.Controls.Add(TxtNome, 1, 0);
            tableLayout1.Controls.Add(tableLayoutEstadoCivil, 1, 4);
            tableLayout1.Controls.Add(ComboGenero, 1, 5);
            tableLayout1.Controls.Add(TxtCpf, 1, 1);
            tableLayout1.Controls.Add(TxtTelefone, 1, 2);
            tableLayout1.Location = new Point(12, 12);
            tableLayout1.Name = "tableLayout1";
            tableLayout1.RowCount = 6;
            tableLayout1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayout1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayout1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayout1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayout1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayout1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayout1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout1.Size = new Size(446, 426);
            tableLayout1.TabIndex = 1;
            // 
            // TxtSalario
            // 
            TxtSalario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtSalario.Location = new Point(77, 216);
            TxtSalario.Name = "TxtSalario";
            TxtSalario.Size = new Size(366, 23);
            TxtSalario.TabIndex = 4;
            TxtSalario.KeyPress += TxtSalario_KeyPress;
            // 
            // tableLayoutEstadoCivil
            // 
            tableLayoutEstadoCivil.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutEstadoCivil.ColumnCount = 2;
            tableLayoutEstadoCivil.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutEstadoCivil.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutEstadoCivil.Controls.Add(RadSolteiro, 0, 0);
            tableLayoutEstadoCivil.Controls.Add(RadCasado, 1, 0);
            tableLayoutEstadoCivil.Location = new Point(77, 287);
            tableLayoutEstadoCivil.Name = "tableLayoutEstadoCivil";
            tableLayoutEstadoCivil.RowCount = 1;
            tableLayoutEstadoCivil.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutEstadoCivil.Size = new Size(366, 65);
            tableLayoutEstadoCivil.TabIndex = 5;
            // 
            // RadSolteiro
            // 
            RadSolteiro.AutoSize = true;
            RadSolteiro.Checked = true;
            RadSolteiro.Location = new Point(3, 3);
            RadSolteiro.Name = "RadSolteiro";
            RadSolteiro.Size = new Size(79, 19);
            RadSolteiro.TabIndex = 6;
            RadSolteiro.TabStop = true;
            RadSolteiro.Text = "Solteiro(a)";
            RadSolteiro.UseVisualStyleBackColor = true;
            // 
            // RadCasado
            // 
            RadCasado.AutoSize = true;
            RadCasado.Location = new Point(186, 3);
            RadCasado.Name = "RadCasado";
            RadCasado.Size = new Size(78, 19);
            RadCasado.TabIndex = 7;
            RadCasado.Text = "Casado(a)";
            RadCasado.UseVisualStyleBackColor = true;
            // 
            // ComboGenero
            // 
            ComboGenero.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboGenero.FormattingEnabled = true;
            ComboGenero.Location = new Point(77, 358);
            ComboGenero.Name = "ComboGenero";
            ComboGenero.Size = new Size(366, 23);
            ComboGenero.TabIndex = 8;
            // 
            // TxtCpf
            // 
            TxtCpf.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtCpf.Culture = new System.Globalization.CultureInfo("en-US");
            TxtCpf.Location = new Point(77, 74);
            TxtCpf.Mask = "000.000.000-00";
            TxtCpf.Name = "TxtCpf";
            TxtCpf.Size = new Size(366, 23);
            TxtCpf.TabIndex = 2;
            // 
            // TxtTelefone
            // 
            TxtTelefone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TxtTelefone.Location = new Point(77, 145);
            TxtTelefone.Mask = "(00) 0 0000-0000";
            TxtTelefone.Name = "TxtTelefone";
            TxtTelefone.Size = new Size(366, 23);
            TxtTelefone.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(BtnCancelar, 1, 0);
            tableLayoutPanel4.Controls.Add(BtnSalvar, 0, 0);
            tableLayoutPanel4.Location = new Point(616, 407);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(172, 31);
            tableLayoutPanel4.TabIndex = 11;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.60064F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.39936F));
            tableLayoutPanel5.Controls.Add(LblDataNascimento, 0, 0);
            tableLayoutPanel5.Controls.Add(Calendario, 1, 0);
            tableLayoutPanel5.Location = new Point(464, 12);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(324, 215);
            tableLayoutPanel5.TabIndex = 9;
            // 
            // Calendario
            // 
            Calendario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Calendario.Location = new Point(88, 9);
            Calendario.Name = "Calendario";
            Calendario.TabIndex = 10;
            // 
            // CadastroFuncionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel5);
            Controls.Add(tableLayoutPanel4);
            Controls.Add(tableLayout1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CadastroFuncionario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CadastroFuncionario";
            tableLayout1.ResumeLayout(false);
            tableLayout1.PerformLayout();
            tableLayoutEstadoCivil.ResumeLayout(false);
            tableLayoutEstadoCivil.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label LblNome;
        private TextBox TxtNome;
        private Label LblCpf;
        private Label LblTelefone;
        private Label LbllSalario;
        private Label LblEstadoCivil;
        private Label LblDataNascimento;
        private Label LblGenero;
        private Button BtnSalvar;
        private Button BtnCancelar;
        private TableLayoutPanel tableLayout1;
        private TableLayoutPanel tableLayoutEstadoCivil;
        private RadioButton RadCasado;
        private RadioButton RadSolteiro;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private MonthCalendar Calendario;
        private ComboBox ComboGenero;
        private MaskedTextBox TxtCpf;
        private MaskedTextBox TxtTelefone;
        private TextBox TxtSalario;
    }
}