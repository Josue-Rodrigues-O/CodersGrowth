namespace ControleFuncionarios
{
    partial class TelaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            TelaListagem = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            salarioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ehCasadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataNascimentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            funcionarioBindingSource1 = new BindingSource(components);
            funcionarioBindingSource = new BindingSource(components);
            btnAdicionar = new Button();
            btnEditar = new Button();
            btnRemover = new Button();
            ((System.ComponentModel.ISupportInitialize)TelaListagem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource).BeginInit();
            SuspendLayout();
            // 
            // TelaListagem
            // 
            TelaListagem.AllowUserToAddRows = false;
            TelaListagem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TelaListagem.AutoGenerateColumns = false;
            TelaListagem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TelaListagem.BorderStyle = BorderStyle.None;
            TelaListagem.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            TelaListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            TelaListagem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TelaListagem.Columns.AddRange(new DataGridViewColumn[] { ID, nomeDataGridViewTextBoxColumn, cpfDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, salarioDataGridViewTextBoxColumn, ehCasadoDataGridViewCheckBoxColumn, dataNascimentoDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn });
            TelaListagem.DataSource = funcionarioBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            TelaListagem.DefaultCellStyle = dataGridViewCellStyle2;
            TelaListagem.Location = new Point(12, 12);
            TelaListagem.MultiSelect = false;
            TelaListagem.Name = "TelaListagem";
            TelaListagem.ReadOnly = true;
            TelaListagem.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            TelaListagem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            TelaListagem.RowHeadersWidth = 30;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TelaListagem.RowsDefaultCellStyle = dataGridViewCellStyle4;
            TelaListagem.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TelaListagem.RowTemplate.Height = 25;
            TelaListagem.RowTemplate.ReadOnly = true;
            TelaListagem.RowTemplate.Resizable = DataGridViewTriState.False;
            TelaListagem.Size = new Size(937, 349);
            TelaListagem.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "Id";
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cpfDataGridViewTextBoxColumn
            // 
            cpfDataGridViewTextBoxColumn.DataPropertyName = "Cpf";
            cpfDataGridViewTextBoxColumn.HeaderText = "CPF";
            cpfDataGridViewTextBoxColumn.Name = "cpfDataGridViewTextBoxColumn";
            cpfDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            telefoneDataGridViewTextBoxColumn.DataPropertyName = "Telefone";
            telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            telefoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salarioDataGridViewTextBoxColumn
            // 
            salarioDataGridViewTextBoxColumn.DataPropertyName = "Salario";
            salarioDataGridViewTextBoxColumn.HeaderText = "Salário";
            salarioDataGridViewTextBoxColumn.Name = "salarioDataGridViewTextBoxColumn";
            salarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ehCasadoDataGridViewCheckBoxColumn
            // 
            ehCasadoDataGridViewCheckBoxColumn.DataPropertyName = "EhCasado";
            ehCasadoDataGridViewCheckBoxColumn.HeaderText = "É Casado";
            ehCasadoDataGridViewCheckBoxColumn.Name = "ehCasadoDataGridViewCheckBoxColumn";
            ehCasadoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dataNascimentoDataGridViewTextBoxColumn
            // 
            dataNascimentoDataGridViewTextBoxColumn.DataPropertyName = "DataNascimento";
            dataNascimentoDataGridViewTextBoxColumn.HeaderText = "Data de nascimento";
            dataNascimentoDataGridViewTextBoxColumn.Name = "dataNascimentoDataGridViewTextBoxColumn";
            dataNascimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generoDataGridViewTextBoxColumn
            // 
            generoDataGridViewTextBoxColumn.DataPropertyName = "Genero";
            generoDataGridViewTextBoxColumn.HeaderText = "Gênero";
            generoDataGridViewTextBoxColumn.Name = "generoDataGridViewTextBoxColumn";
            generoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // funcionarioBindingSource1
            // 
            funcionarioBindingSource1.DataSource = typeof(Funcionario);
            // 
            // funcionarioBindingSource
            // 
            funcionarioBindingSource.DataSource = typeof(Funcionario);
            // 
            // btnAdicionar
            // 
            btnAdicionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdicionar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAdicionar.Location = new Point(649, 383);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(97, 44);
            btnAdicionar.TabIndex = 1;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += Ao_Clicar_Em_Adicionar;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditar.Location = new Point(752, 383);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(97, 44);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += Ao_Clicar_Em_Editar;
            // 
            // btnRemover
            // 
            btnRemover.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemover.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRemover.Location = new Point(855, 383);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(94, 44);
            btnRemover.TabIndex = 3;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += Ao_Clicar_Em_Remover;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 450);
            Controls.Add(btnRemover);
            Controls.Add(btnEditar);
            Controls.Add(btnAdicionar);
            Controls.Add(TelaListagem);
            Name = "TelaPrincipal";
            Text = "Tela Principal";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)TelaListagem).EndInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAdicionar;
        private Button btnEditar;
        private Button btnRemover;
        private BindingSource funcionarioBindingSource;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn salarioDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn ehCasadoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataNascimentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private BindingSource funcionarioBindingSource1;
        private static DataGridView TelaListagem;
    }
}