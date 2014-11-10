namespace Software___Auditoria
{
    partial class calificacion
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.barra1 = new Navegador.Barra();
            this.button1 = new System.Windows.Forms.Button();
            this.Ingreso = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.auditor_combo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.autor_combo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.objetivo_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgw_calificacion = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.empresa_combo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Ingreso.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_calificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // barra1
            // 
            this.barra1.BackColor = System.Drawing.Color.Transparent;
            this.barra1.Location = new System.Drawing.Point(92, 40);
            this.barra1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barra1.Name = "barra1";
            this.barra1.Size = new System.Drawing.Size(268, 42);
            this.barra1.TabIndex = 2;
            this.barra1.click_guardar_button += new Navegador.Barra.delegadoButton(this.barra1_click_guardar_button);
            this.barra1.click_editar_button += new Navegador.Barra.delegadoButton(this.barra1_click_editar_button);
            this.barra1.click_buscar_button += new Navegador.Barra.delegadoButton(this.barra1_click_buscar_button);
            this.barra1.Load += new System.EventHandler(this.barra1_Load);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Software___Auditoria.Properties.Resources.logo_pequeño_ADST;
            this.button1.Location = new System.Drawing.Point(617, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 70);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Ingreso
            // 
            this.Ingreso.Controls.Add(this.tabPage1);
            this.Ingreso.Controls.Add(this.tabPage2);
            this.Ingreso.Location = new System.Drawing.Point(92, 104);
            this.Ingreso.Name = "Ingreso";
            this.Ingreso.SelectedIndex = 0;
            this.Ingreso.Size = new System.Drawing.Size(727, 354);
            this.Ingreso.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.empresa_combo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.auditor_combo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.autor_combo);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.objetivo_combo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(719, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingreso";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(106, 172);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha";
            // 
            // auditor_combo
            // 
            this.auditor_combo.FormattingEnabled = true;
            this.auditor_combo.Location = new System.Drawing.Point(466, 81);
            this.auditor_combo.Name = "auditor_combo";
            this.auditor_combo.Size = new System.Drawing.Size(112, 21);
            this.auditor_combo.TabIndex = 8;
            this.auditor_combo.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Auditor";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // autor_combo
            // 
            this.autor_combo.FormattingEnabled = true;
            this.autor_combo.Location = new System.Drawing.Point(275, 78);
            this.autor_combo.Name = "autor_combo";
            this.autor_combo.Size = new System.Drawing.Size(121, 21);
            this.autor_combo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Autor";
            // 
            // objetivo_combo
            // 
            this.objetivo_combo.FormattingEnabled = true;
            this.objetivo_combo.Location = new System.Drawing.Point(106, 78);
            this.objetivo_combo.Name = "objetivo_combo";
            this.objetivo_combo.Size = new System.Drawing.Size(125, 21);
            this.objetivo_combo.TabIndex = 2;
            this.objetivo_combo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Objetivo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgw_calificacion);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(719, 328);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consulta";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // dgw_calificacion
            // 
            this.dgw_calificacion.AllowUserToAddRows = false;
            this.dgw_calificacion.AllowUserToDeleteRows = false;
            this.dgw_calificacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgw_calificacion.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgw_calificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_calificacion.Location = new System.Drawing.Point(34, 27);
            this.dgw_calificacion.Margin = new System.Windows.Forms.Padding(2);
            this.dgw_calificacion.Name = "dgw_calificacion";
            this.dgw_calificacion.ReadOnly = true;
            this.dgw_calificacion.RowTemplate.Height = 24;
            this.dgw_calificacion.Size = new System.Drawing.Size(610, 260);
            this.dgw_calificacion.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Estado";
            // 
            // empresa_combo
            // 
            this.empresa_combo.FormattingEnabled = true;
            this.empresa_combo.Location = new System.Drawing.Point(108, 40);
            this.empresa_combo.Name = "empresa_combo";
            this.empresa_combo.Size = new System.Drawing.Size(125, 21);
            this.empresa_combo.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Empresa";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(402, 179);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 20);
            this.textBox1.TabIndex = 14;
            // 
            // calificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Software___Auditoria.Properties.Resources.Fondo___ADST;
            this.ClientSize = new System.Drawing.Size(857, 499);
            this.Controls.Add(this.Ingreso);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.barra1);
            this.Name = "calificacion";
            this.Text = "calificacion";
            this.Load += new System.EventHandler(this.calificacion_Load);
            this.Ingreso.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_calificacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Navegador.Barra barra1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl Ingreso;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox objetivo_combo;
        private System.Windows.Forms.ComboBox auditor_combo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox autor_combo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgw_calificacion;
        private System.Windows.Forms.ComboBox empresa_combo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
    }
}