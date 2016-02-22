namespace ProtocoloTitulacion
{
    partial class mostrar_alumnos
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.processofTitlingDataSet = new ProtocoloTitulacion.ProcessofTitlingDataSet();
            this.processofTitlingDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processofTitlingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processofTitlingDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(594, 206);
            this.dataGridView1.TabIndex = 0;
            // 
            // processofTitlingDataSet
            // 
            this.processofTitlingDataSet.DataSetName = "ProcessofTitlingDataSet";
            this.processofTitlingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // processofTitlingDataSetBindingSource
            // 
            this.processofTitlingDataSetBindingSource.DataSource = this.processofTitlingDataSet;
            this.processofTitlingDataSetBindingSource.Position = 0;
            // 
            // mostrar_alumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 224);
            this.Controls.Add(this.dataGridView1);
            this.Name = "mostrar_alumnos";
            this.Text = "mostrar_alumnos";
            this.Load += new System.EventHandler(this.mostrar_alumnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processofTitlingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processofTitlingDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ProcessofTitlingDataSet processofTitlingDataSet;
        private System.Windows.Forms.BindingSource processofTitlingDataSetBindingSource;
    }
}