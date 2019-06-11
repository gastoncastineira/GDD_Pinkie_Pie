namespace FrbaCrucero.CompraReservaPasaje
{
    partial class Confirmacion
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
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblCantidadDePasajeros = new System.Windows.Forms.Label();
            this.lblFechaDeInicio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblIdeCrucero = new System.Windows.Forms.Label();
            this.lblTipoDeCabina = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtTramos = new System.Windows.Forms.DataGridView();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFabricanteCrucero = new System.Windows.Forms.Label();
            this.lblModeloCrucero = new System.Windows.Forms.Label();
            this.lblPuertoOrigen = new System.Windows.Forms.Label();
            this.lblPuertoDestino = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(31, 22);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Número:";
            // 
            // lblCantidadDePasajeros
            // 
            this.lblCantidadDePasajeros.AutoSize = true;
            this.lblCantidadDePasajeros.Location = new System.Drawing.Point(31, 56);
            this.lblCantidadDePasajeros.Name = "lblCantidadDePasajeros";
            this.lblCantidadDePasajeros.Size = new System.Drawing.Size(115, 13);
            this.lblCantidadDePasajeros.TabIndex = 1;
            this.lblCantidadDePasajeros.Text = "Cantidad de pasajeros:";
            // 
            // lblFechaDeInicio
            // 
            this.lblFechaDeInicio.AutoSize = true;
            this.lblFechaDeInicio.Location = new System.Drawing.Point(31, 79);
            this.lblFechaDeInicio.Name = "lblFechaDeInicio";
            this.lblFechaDeInicio.Size = new System.Drawing.Size(124, 13);
            this.lblFechaDeInicio.TabIndex = 2;
            this.lblFechaDeInicio.Text = "Fecha de inicio del viaje:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tramos del viaje";
            // 
            // lblIdeCrucero
            // 
            this.lblIdeCrucero.AutoSize = true;
            this.lblIdeCrucero.Location = new System.Drawing.Point(34, 375);
            this.lblIdeCrucero.Name = "lblIdeCrucero";
            this.lblIdeCrucero.Size = new System.Drawing.Size(127, 13);
            this.lblIdeCrucero.TabIndex = 5;
            this.lblIdeCrucero.Text = "Identificador del crucero: ";
            // 
            // lblTipoDeCabina
            // 
            this.lblTipoDeCabina.AutoSize = true;
            this.lblTipoDeCabina.Location = new System.Drawing.Point(37, 471);
            this.lblTipoDeCabina.Name = "lblTipoDeCabina";
            this.lblTipoDeCabina.Size = new System.Drawing.Size(81, 13);
            this.lblTipoDeCabina.TabIndex = 6;
            this.lblTipoDeCabina.Text = "Tipo de cabina:";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(35, 503);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 1;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.BtnAtras_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(435, 503);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 0;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // dtTramos
            // 
            this.dtTramos.AllowUserToAddRows = false;
            this.dtTramos.AllowUserToDeleteRows = false;
            this.dtTramos.AllowUserToResizeColumns = false;
            this.dtTramos.AllowUserToResizeRows = false;
            this.dtTramos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtTramos.Enabled = false;
            this.dtTramos.Location = new System.Drawing.Point(37, 203);
            this.dtTramos.Name = "dtTramos";
            this.dtTramos.ReadOnly = true;
            this.dtTramos.RowHeadersVisible = false;
            this.dtTramos.Size = new System.Drawing.Size(240, 150);
            this.dtTramos.TabIndex = 7;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(31, 106);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(152, 13);
            this.lblFechaFin.TabIndex = 3;
            this.lblFechaFin.Text = "Fecha de finalización del viaje:";
            // 
            // lblFabricanteCrucero
            // 
            this.lblFabricanteCrucero.AutoSize = true;
            this.lblFabricanteCrucero.Location = new System.Drawing.Point(34, 407);
            this.lblFabricanteCrucero.Name = "lblFabricanteCrucero";
            this.lblFabricanteCrucero.Size = new System.Drawing.Size(119, 13);
            this.lblFabricanteCrucero.TabIndex = 9;
            this.lblFabricanteCrucero.Text = "Fabricante del crucero: ";
            // 
            // lblModeloCrucero
            // 
            this.lblModeloCrucero.AutoSize = true;
            this.lblModeloCrucero.Location = new System.Drawing.Point(34, 434);
            this.lblModeloCrucero.Name = "lblModeloCrucero";
            this.lblModeloCrucero.Size = new System.Drawing.Size(104, 13);
            this.lblModeloCrucero.TabIndex = 10;
            this.lblModeloCrucero.Text = "Modelo del crucero: ";
            // 
            // lblPuertoOrigen
            // 
            this.lblPuertoOrigen.AutoSize = true;
            this.lblPuertoOrigen.Location = new System.Drawing.Point(34, 134);
            this.lblPuertoOrigen.Name = "lblPuertoOrigen";
            this.lblPuertoOrigen.Size = new System.Drawing.Size(76, 13);
            this.lblPuertoOrigen.TabIndex = 11;
            this.lblPuertoOrigen.Text = "Puerto origen: ";
            // 
            // lblPuertoDestino
            // 
            this.lblPuertoDestino.AutoSize = true;
            this.lblPuertoDestino.Location = new System.Drawing.Point(34, 161);
            this.lblPuertoDestino.Name = "lblPuertoDestino";
            this.lblPuertoDestino.Size = new System.Drawing.Size(81, 13);
            this.lblPuertoDestino.TabIndex = 12;
            this.lblPuertoDestino.Text = "Puerto destino: ";
            // 
            // Confirmacion
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 540);
            this.Controls.Add(this.lblPuertoDestino);
            this.Controls.Add(this.lblPuertoOrigen);
            this.Controls.Add(this.lblModeloCrucero);
            this.Controls.Add(this.lblFabricanteCrucero);
            this.Controls.Add(this.dtTramos);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblTipoDeCabina);
            this.Controls.Add(this.lblIdeCrucero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaDeInicio);
            this.Controls.Add(this.lblCantidadDePasajeros);
            this.Controls.Add(this.lblNumero);
            this.Name = "Confirmacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmación";
            this.Load += new System.EventHandler(this.Confirmacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtTramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblCantidadDePasajeros;
        private System.Windows.Forms.Label lblFechaDeInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIdeCrucero;
        private System.Windows.Forms.Label lblTipoDeCabina;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridView dtTramos;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFabricanteCrucero;
        private System.Windows.Forms.Label lblModeloCrucero;
        private System.Windows.Forms.Label lblPuertoOrigen;
        private System.Windows.Forms.Label lblPuertoDestino;
    }
}