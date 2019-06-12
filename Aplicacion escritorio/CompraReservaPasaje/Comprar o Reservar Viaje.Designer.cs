namespace FrbaCrucero.CompraPasaje
{
    partial class ComprarReservarViaje
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
            this.dtFechaDeViaje = new System.Windows.Forms.DateTimePicker();
            this.lblFechaViaje = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarViajes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtFechaDeViaje
            // 
            this.dtFechaDeViaje.Location = new System.Drawing.Point(30, 57);
            this.dtFechaDeViaje.Name = "dtFechaDeViaje";
            this.dtFechaDeViaje.Size = new System.Drawing.Size(200, 20);
            this.dtFechaDeViaje.TabIndex = 0;
            // 
            // lblFechaViaje
            // 
            this.lblFechaViaje.AutoSize = true;
            this.lblFechaViaje.Location = new System.Drawing.Point(27, 24);
            this.lblFechaViaje.Name = "lblFechaViaje";
            this.lblFechaViaje.Size = new System.Drawing.Size(77, 13);
            this.lblFechaViaje.TabIndex = 1;
            this.lblFechaViaje.Text = "Fecha de viaje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puerto origen";
            // 
            // txtOrigen
            // 
            this.txtOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtOrigen.Location = new System.Drawing.Point(30, 139);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(149, 20);
            this.txtOrigen.TabIndex = 1;
            // 
            // txtDestino
            // 
            this.txtDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDestino.Location = new System.Drawing.Point(319, 139);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(149, 20);
            this.txtDestino.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Puerto destino";
            // 
            // btnBuscarViajes
            // 
            this.btnBuscarViajes.Location = new System.Drawing.Point(358, 201);
            this.btnBuscarViajes.Name = "btnBuscarViajes";
            this.btnBuscarViajes.Size = new System.Drawing.Size(110, 23);
            this.btnBuscarViajes.TabIndex = 4;
            this.btnBuscarViajes.Text = "Buscar viajes";
            this.btnBuscarViajes.UseVisualStyleBackColor = true;
            this.btnBuscarViajes.Click += new System.EventHandler(this.BtnBuscarViajes_Click);
            // 
            // ComprarReservarViaje
            // 
            this.AcceptButton = this.btnBuscarViajes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(538, 264);
            this.Controls.Add(this.btnBuscarViajes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFechaViaje);
            this.Controls.Add(this.dtFechaDeViaje);
            this.Name = "ComprarReservarViaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprar o reservar viaje";
            this.Load += new System.EventHandler(this.ComprarReservarViaje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFechaDeViaje;
        private System.Windows.Forms.Label lblFechaViaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarViajes;
    }
}