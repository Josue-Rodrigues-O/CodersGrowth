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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            monthCalendar1 = new MonthCalendar();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(137, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(651, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 2;
            label2.Text = "CPF";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 104);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 3;
            label3.Text = "Telefone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 155);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 4;
            label4.Text = "Salário";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 208);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 5;
            label5.Text = "Estado civil";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(436, 208);
            label6.Name = "label6";
            label6.Size = new Size(112, 15);
            label6.TabIndex = 6;
            label6.Text = "Data de nascimento";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 258);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 7;
            label7.Text = "Gênero";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(137, 50);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(651, 23);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(137, 101);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(651, 23);
            textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(137, 152);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(651, 23);
            textBox4.TabIndex = 10;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(137, 206);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(64, 19);
            radioButton1.TabIndex = 11;
            radioButton1.TabStop = true;
            radioButton1.Text = "Casado";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(218, 206);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(65, 19);
            radioButton2.TabIndex = 12;
            radioButton2.TabStop = true;
            radioButton2.Text = "Solteiro";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(561, 208);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 13;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Masculino", "Feminino" });
            comboBox1.Location = new Point(137, 255);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(146, 23);
            comboBox1.TabIndex = 16;
            // 
            // button1
            // 
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 17;
            button1.Text = "Adicionar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(137, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 18;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // CadastroFuncionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(monthCalendar1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "CadastroFuncionario";
            Text = "CadastroFuncionario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private MonthCalendar monthCalendar1;
        private CheckedListBox checkedListBox1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
    }
}