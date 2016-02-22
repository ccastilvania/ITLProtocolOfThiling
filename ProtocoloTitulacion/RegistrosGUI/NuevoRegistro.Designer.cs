namespace ProtocoloTitulacion.RegistrosGUI
{
    partial class NuevoRegistro
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cb_Alumno = new System.Windows.Forms.ComboBox();
            this.cb_Asesor = new System.Windows.Forms.ComboBox();
            this.cb_secretario = new System.Windows.Forms.ComboBox();
            this.cb_vocal = new System.Windows.Forms.ComboBox();
            this.cb_suplente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cb_Alumno
            // 
            this.cb_Alumno.FormattingEnabled = true;
            this.cb_Alumno.Location = new System.Drawing.Point(24, 33);
            this.cb_Alumno.Name = "cb_Alumno";
            this.cb_Alumno.Size = new System.Drawing.Size(121, 21);
            this.cb_Alumno.TabIndex = 3;
            this.cb_Alumno.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cb_Asesor
            // 
            this.cb_Asesor.FormattingEnabled = true;
            this.cb_Asesor.Location = new System.Drawing.Point(197, 32);
            this.cb_Asesor.Name = "cb_Asesor";
            this.cb_Asesor.Size = new System.Drawing.Size(121, 21);
            this.cb_Asesor.TabIndex = 4;
            // 
            // cb_secretario
            // 
            this.cb_secretario.FormattingEnabled = true;
            this.cb_secretario.Location = new System.Drawing.Point(24, 110);
            this.cb_secretario.Name = "cb_secretario";
            this.cb_secretario.Size = new System.Drawing.Size(121, 21);
            this.cb_secretario.TabIndex = 5;
            this.cb_secretario.SelectedIndexChanged += new System.EventHandler(this.cb_secretario_SelectedIndexChanged);
            // 
            // cb_vocal
            // 
            this.cb_vocal.FormattingEnabled = true;
            this.cb_vocal.Location = new System.Drawing.Point(197, 110);
            this.cb_vocal.Name = "cb_vocal";
            this.cb_vocal.Size = new System.Drawing.Size(121, 21);
            this.cb_vocal.TabIndex = 6;
            // 
            // cb_suplente
            // 
            this.cb_suplente.FormattingEnabled = true;
            this.cb_suplente.Location = new System.Drawing.Point(369, 110);
            this.cb_suplente.Name = "cb_suplente";
            this.cb_suplente.Size = new System.Drawing.Size(121, 21);
            this.cb_suplente.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alumno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Asesor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Secretario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "vocal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Suplente";
            // 
            // NuevoRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 212);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_suplente);
            this.Controls.Add(this.cb_vocal);
            this.Controls.Add(this.cb_secretario);
            this.Controls.Add(this.cb_Asesor);
            this.Controls.Add(this.cb_Alumno);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Name = "NuevoRegistro";
            this.Text = "NuevoRegistro";
            this.Load += new System.EventHandler(this.NuevoRegistro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cb_Alumno;
        private System.Windows.Forms.ComboBox cb_Asesor;
        private System.Windows.Forms.ComboBox cb_secretario;
        private System.Windows.Forms.ComboBox cb_vocal;
        private System.Windows.Forms.ComboBox cb_suplente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}