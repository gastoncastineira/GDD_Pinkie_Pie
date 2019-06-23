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
            this.lblNumeros = new System.Windows.Forms.Label();
            this.lblCantidadDePasajeros = new System.Windows.Forms.Label();
            this.lblFechaDeInicio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblIdeCrucero = new System.Windows.Forms.Label();
            this.lblTipoDeCabina = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtTramos = new System.Windows.Forms.DataGridView();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblModeloCrucero = new System.Windows.Forms.Label();
            this.lblPuertoOrigen = new System.Windows.Forms.Label();
            this.lblPuertoDestino = new System.Windows.Forms.Label();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.lblFechaDeConcepcion = new System.Windows.Forms.Label();
            this.dtNumerosOperacion = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtTramos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNumerosOperacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumeros
            // 
            this.lblNumeros.AutoSize = true;
            this.lblNumeros.Location = new System.Drawing.Point(32, 134);
            this.lblNumeros.Name = "lblNumeros";
            this.lblNumeros.Size = new System.Drawing.Size(67, 13);
            this.lblNumeros.TabIndex = 0;
            this.lblNumeros.Text = "Números de ";
            // 
            // lblCantidadDePasajeros
            // 
            this.lblCantidadDePasajeros.AutoSize = true;
            this.lblCantidadDePasajeros.Location = new System.Drawing.Point(32, 26);
            this.lblCantidadDePasajeros.Name = "lblCantidadDePasajeros";
            this.lblCantidadDePasajeros.Size = new System.Drawing.Size(118, 13);
            this.lblCantidadDePasajeros.TabIndex = 1;
            this.lblCantidadDePasajeros.Text = "Cantidad de pasajeros: ";
            // 
            // lblFechaDeInicio
            // 
            this.lblFechaDeInicio.AutoSize = true;
            this.lblFechaDeInicio.Location = new System.Drawing.Point(32, 55);
            this.lblFechaDeInicio.Name = "lblFechaDeInicio";
            this.lblFechaDeInicio.Size = new System.Drawing.Size(127, 13);
            this.lblFechaDeInicio.TabIndex = 2;
            this.lblFechaDeInicio.Text = "Fecha de inicio del viaje: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tramos del viaje";
            // 
            // lblIdeCrucero
            // 
            this.lblIdeCrucero.AutoSize = true;
            this.lblIdeCrucero.Location = new System.Drawing.Point(37, 477);
            this.lblIdeCrucero.Name = "lblIdeCrucero";
            this.lblIdeCrucero.Size = new System.Drawing.Size(127, 13);
            this.lblIdeCrucero.TabIndex = 5;
            this.lblIdeCrucero.Text = "Identificador del crucero: ";
            // 
            // lblTipoDeCabina
            // 
            this.lblTipoDeCabina.AutoSize = true;
            this.lblTipoDeCabina.Location = new System.Drawing.Point(37, 542);
            this.lblTipoDeCabina.Name = "lblTipoDeCabina";
            this.lblTipoDeCabina.Size = new System.Drawing.Size(84, 13);
            this.lblTipoDeCabina.TabIndex = 6;
            this.lblTipoDeCabina.Text = "Tipo de cabina: ";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(35, 612);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 1;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.BtnAtras_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(435, 612);
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
            this.dtTramos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtTramos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtTramos.Enabled = false;
            this.dtTramos.Location = new System.Drawing.Point(35, 301);
            this.dtTramos.Name = "dtTramos";
            this.dtTramos.ReadOnly = true;
            this.dtTramos.RowHeadersVisible = false;
            this.dtTramos.Size = new System.Drawing.Size(240, 150);
            this.dtTramos.TabIndex = 7;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(293, 55);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(155, 13);
            this.lblFechaFin.TabIndex = 3;
            this.lblFechaFin.Text = "Fecha de finalización del viaje: ";
            // 
            // lblModeloCrucero
            // 
            this.lblModeloCrucero.AutoSize = true;
            this.lblModeloCrucero.Location = new System.Drawing.Point(37, 511);
            this.lblModeloCrucero.Name = "lblModeloCrucero";
            this.lblModeloCrucero.Size = new System.Drawing.Size(104, 13);
            this.lblModeloCrucero.TabIndex = 10;
            this.lblModeloCrucero.Text = "Modelo del crucero: ";
            // 
            // lblPuertoOrigen
            // 
            this.lblPuertoOrigen.AutoSize = true;
            this.lblPuertoOrigen.Location = new System.Drawing.Point(32, 86);
            this.lblPuertoOrigen.Name = "lblPuertoOrigen";
            this.lblPuertoOrigen.Size = new System.Drawing.Size(76, 13);
            this.lblPuertoOrigen.TabIndex = 11;
            this.lblPuertoOrigen.Text = "Puerto origen: ";
            // 
            // lblPuertoDestino
            // 
            this.lblPuertoDestino.AutoSize = true;
            this.lblPuertoDestino.Location = new System.Drawing.Point(293, 86);
            this.lblPuertoDestino.Name = "lblPuertoDestino";
            this.lblPuertoDestino.Size = new System.Drawing.Size(81, 13);
            this.lblPuertoDestino.TabIndex = 12;
            this.lblPuertoDestino.Text = "Puerto destino: ";
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.Location = new System.Drawing.Point(37, 570);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(214, 18);
            this.lblPrecioTotal.TabIndex = 13;
            this.lblPrecioTotal.Text = "PRECIO TOTAL A PAGAR: ";
            // 
            // lblFechaDeConcepcion
            // 
            this.lblFechaDeConcepcion.AutoSize = true;
            this.lblFechaDeConcepcion.Location = new System.Drawing.Point(293, 26);
            this.lblFechaDeConcepcion.Name = "lblFechaDeConcepcion";
            this.lblFechaDeConcepcion.Size = new System.Drawing.Size(117, 13);
            this.lblFechaDeConcepcion.TabIndex = 14;
            this.lblFechaDeConcepcion.Text = "Fecha de concepción: ";
            // 
            // dtNumerosOperacion
            // 
            this.dtNumerosOperacion.AllowUserToAddRows = false;
            this.dtNumerosOperacion.AllowUserToDeleteRows = false;
            this.dtNumerosOperacion.AllowUserToResizeColumns = false;
            this.dtNumerosOperacion.AllowUserToResizeRows = false;
            this.dtNumerosOperacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtNumerosOperacion.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtNumerosOperacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtNumerosOperacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Precio});
            this.dtNumerosOperacion.Location = new System.Drawing.Point(35, 150);
            this.dtNumerosOperacion.Name = "dtNumerosOperacion";
            this.dtNumerosOperacion.ReadOnly = true;
            this.dtNumerosOperacion.RowHeadersVisible = false;
            this.dtNumerosOperacion.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dtNumerosOperacion.Size = new System.Drawing.Size(240, 132);
            this.dtNumerosOperacion.TabIndex = 15;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Confirmacion
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 654);
            this.Controls.Add(this.dtNumerosOperacion);
            this.Controls.Add(this.lblFechaDeConcepcion);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.lblPuertoDestino);
            this.Controls.Add(this.lblPuertoOrigen);
            this.Controls.Add(this.lblModeloCrucero);
            this.Controls.Add(this.dtTramos);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblTipoDeCabina);
            this.Controls.Add(this.lblIdeCrucero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaDeInicio);
            this.Controls.Add(this.lblCantidadDePasajeros);
            this.Controls.Add(this.lblNumeros);
            this.Name = "Confirmacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmación";
            this.Load += new System.EventHandler(this.Confirmacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtTramos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNumerosOperacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumeros;
        private System.Windows.Forms.Label lblCantidadDePasajeros;
        private System.Windows.Forms.Label lblFechaDeInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIdeCrucero;
        private System.Windows.Forms.Label lblTipoDeCabina;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridView dtTramos;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblModeloCrucero;
        private System.Windows.Forms.Label lblPuertoOrigen;
        private System.Windows.Forms.Label lblPuertoDestino;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.Label lblFechaDeConcepcion;
        private System.Windows.Forms.DataGridView dtNumerosOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
    }
}