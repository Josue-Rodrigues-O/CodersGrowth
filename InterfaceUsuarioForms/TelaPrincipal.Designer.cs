using Dominio;

namespace InterfaceUsuarioForms
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
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            funcionarioBindingSource = new BindingSource(components);
            funcionarioBindingSource1 = new BindingSource(components);
            btnAdicionar = new Button();
            btnEditar = new Button();
            btnRemover = new Button();
            ((System.ComponentModel.ISupportInitialize)TelaListagem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource1).BeginInit();
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
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            TelaListagem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            TelaListagem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TelaListagem.Columns.AddRange(new DataGridViewColumn[] { ID, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            TelaListagem.DataSource = funcionarioBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
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
            dataGridViewCellStyle3.SelectionBackColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            TelaListagem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            TelaListagem.RowHeadersWidth = 30;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionBackColor = Color.Black;
            TelaListagem.RowsDefaultCellStyle = dataGridViewCellStyle4;
            TelaListagem.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            TelaListagem.RowTemplate.Height = 25;
            TelaListagem.RowTemplate.ReadOnly = true;
            TelaListagem.RowTemplate.Resizable = DataGridViewTriState.False;
            TelaListagem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Nome";
            dataGridViewTextBoxColumn1.HeaderText = "Nome";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Cpf";
            dataGridViewTextBoxColumn2.HeaderText = "CPF";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Telefone";
            dataGridViewTextBoxColumn3.HeaderText = "Telefone";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Salario";
            dataGridViewTextBoxColumn4.HeaderText = "Salário";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "EhCasado";
            dataGridViewCheckBoxColumn1.HeaderText = "É Casado(a)?";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "DataNascimento";
            dataGridViewTextBoxColumn5.HeaderText = "Data de nascimento";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "Genero";
            dataGridViewTextBoxColumn6.HeaderText = "Gênero";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // funcionarioBindingSource
            // 
            funcionarioBindingSource.DataSource = typeof(Funcionario);
            // 
            // funcionarioBindingSource1
            // 
            funcionarioBindingSource1.DataSource = typeof(Funcionario);
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
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAdicionar;
        private Button btnEditar;
        private Button btnRemover;
        private BindingSource funcionarioBindingSource;
        private DataGridViewTextBoxColumn ID;
        private BindingSource funcionarioBindingSource1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private static DataGridView TelaListagem;
    }
}