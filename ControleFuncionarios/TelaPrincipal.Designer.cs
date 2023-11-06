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
            TelaListagem = new DataGridView();
            btnAdicionar = new Button();
            btnEditar = new Button();
            btnRemover = new Button();
            ((System.ComponentModel.ISupportInitialize)TelaListagem).BeginInit();
            SuspendLayout();
            // 
            // TelaListagem
            // 
            TelaListagem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TelaListagem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TelaListagem.Location = new Point(12, 12);
            TelaListagem.Name = "TelaListagem";
            TelaListagem.ReadOnly = true;
            TelaListagem.RowTemplate.Height = 25;
            TelaListagem.Size = new Size(776, 349);
            TelaListagem.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(551, 404);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(75, 23);
            btnAdicionar.TabIndex = 1;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(632, 404);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(713, 404);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(75, 23);
            btnRemover.TabIndex = 3;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemover);
            Controls.Add(btnEditar);
            Controls.Add(btnAdicionar);
            Controls.Add(TelaListagem);
            Name = "TelaPrincipal";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)TelaListagem).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAdicionar;
        private Button btnEditar;
        private Button btnRemover;
        private static DataGridView TelaListagem;
    }
}