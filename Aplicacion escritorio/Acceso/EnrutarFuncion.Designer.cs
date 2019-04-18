namespace FrbaCrucero.Acceso
{
    partial class EnrutarFuncion
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
            this.cbbSeleccion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbbSeleccion
            // 
            this.cbbSeleccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSeleccion.FormattingEnabled = true;
            this.cbbSeleccion.Location = new System.Drawing.Point(12, 23);
            this.cbbSeleccion.Name = "cbbSeleccion";
            this.cbbSeleccion.Size = new System.Drawing.Size(228, 21);
            this.cbbSeleccion.TabIndex = 0;
            this.cbbSeleccion.SelectedIndexChanged += new System.EventHandler(this.cbbSeleccion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione Funcion";
            // 
            // EnrutarFuncion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 56);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbSeleccion);
            this.Name = "EnrutarFuncion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnrutarFuncion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnrutarFuncion_FormClosing);
            this.Load += new System.EventHandler(this.EnrutarFuncion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbSeleccion;
        private System.Windows.Forms.Label label1;
    }
}