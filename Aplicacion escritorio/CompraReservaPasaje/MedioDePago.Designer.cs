namespace FrbaCrucero.CompraReservaPasaje
{
    partial class MedioDePago
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
            this.lblMetodoDePago = new System.Windows.Forms.Label();
            this.cmbMetodoDePago = new System.Windows.Forms.ComboBox();
            this.cmbCantidadDeCuotas = new System.Windows.Forms.ComboBox();
            this.lblCantidadDeCuotas = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblNumeroDeTarjeta = new System.Windows.Forms.Label();
            this.txtNumeroDeTarjerta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMetodoDePago
            // 
            this.lblMetodoDePago.AutoSize = true;
            this.lblMetodoDePago.Location = new System.Drawing.Point(15, 94);
            this.lblMetodoDePago.Name = "lblMetodoDePago";
            this.lblMetodoDePago.Size = new System.Drawing.Size(155, 13);
            this.lblMetodoDePago.TabIndex = 0;
            this.lblMetodoDePago.Text = "Seleccione un método de pago";
            // 
            // cmbMetodoDePago
            // 
            this.cmbMetodoDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoDePago.Items.AddRange(new object[] {
            "EFECTIVO",
            "CREDITO",
            "DEBITO"});
            this.cmbMetodoDePago.Location = new System.Drawing.Point(176, 91);
            this.cmbMetodoDePago.Name = "cmbMetodoDePago";
            this.cmbMetodoDePago.Size = new System.Drawing.Size(121, 21);
            this.cmbMetodoDePago.TabIndex = 0;
            this.cmbMetodoDePago.SelectedIndexChanged += new System.EventHandler(this.CmbMetodoDePago_SelectedIndexChanged);
            // 
            // cmbCantidadDeCuotas
            // 
            this.cmbCantidadDeCuotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCantidadDeCuotas.FormattingEnabled = true;
            this.cmbCantidadDeCuotas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbCantidadDeCuotas.Location = new System.Drawing.Point(176, 181);
            this.cmbCantidadDeCuotas.Name = "cmbCantidadDeCuotas";
            this.cmbCantidadDeCuotas.Size = new System.Drawing.Size(121, 21);
            this.cmbCantidadDeCuotas.TabIndex = 2;
            // 
            // lblCantidadDeCuotas
            // 
            this.lblCantidadDeCuotas.AutoSize = true;
            this.lblCantidadDeCuotas.Location = new System.Drawing.Point(15, 184);
            this.lblCantidadDeCuotas.Name = "lblCantidadDeCuotas";
            this.lblCantidadDeCuotas.Size = new System.Drawing.Size(99, 13);
            this.lblCantidadDeCuotas.TabIndex = 3;
            this.lblCantidadDeCuotas.Text = "Cantidad de cuotas";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(31, 272);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.BtnAtras_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(423, 272);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            // 
            // lblNumeroDeTarjeta
            // 
            this.lblNumeroDeTarjeta.AutoSize = true;
            this.lblNumeroDeTarjeta.Location = new System.Drawing.Point(15, 143);
            this.lblNumeroDeTarjeta.Name = "lblNumeroDeTarjeta";
            this.lblNumeroDeTarjeta.Size = new System.Drawing.Size(91, 13);
            this.lblNumeroDeTarjeta.TabIndex = 6;
            this.lblNumeroDeTarjeta.Text = "Numero de tarjeta";
            // 
            // txtNumeroDeTarjerta
            // 
            this.txtNumeroDeTarjerta.Location = new System.Drawing.Point(176, 140);
            this.txtNumeroDeTarjerta.Name = "txtNumeroDeTarjerta";
            this.txtNumeroDeTarjerta.Size = new System.Drawing.Size(121, 20);
            this.txtNumeroDeTarjerta.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Deseo realizar ";
            // 
            // cmbTipoOperacion
            // 
            this.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoOperacion.FormattingEnabled = true;
            this.cmbTipoOperacion.Items.AddRange(new object[] {
            "COMPRA",
            "RESERVA"});
            this.cmbTipoOperacion.Location = new System.Drawing.Point(176, 42);
            this.cmbTipoOperacion.Name = "cmbTipoOperacion";
            this.cmbTipoOperacion.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoOperacion.TabIndex = 3;
            this.cmbTipoOperacion.SelectedIndexChanged += new System.EventHandler(this.CmbTipoOperacion_SelectedIndexChanged);
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Location = new System.Drawing.Point(15, 229);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(116, 13);
            this.lblPrecioTotal.TabIndex = 9;
            this.lblPrecioTotal.Text = "La cantidad a pagar es";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Una reserva tiene una validez de 3 días.";
            // 
            // MedioDePago
            // 
            this.AcceptButton = this.btnSiguiente;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 304);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.cmbTipoOperacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumeroDeTarjerta);
            this.Controls.Add(this.lblNumeroDeTarjeta);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblCantidadDeCuotas);
            this.Controls.Add(this.cmbCantidadDeCuotas);
            this.Controls.Add(this.cmbMetodoDePago);
            this.Controls.Add(this.lblMetodoDePago);
            this.Name = "MedioDePago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medio de pago";
            this.Load += new System.EventHandler(this.MedioDePago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMetodoDePago;
        private System.Windows.Forms.ComboBox cmbMetodoDePago;
        private System.Windows.Forms.ComboBox cmbCantidadDeCuotas;
        private System.Windows.Forms.Label lblCantidadDeCuotas;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblNumeroDeTarjeta;
        private System.Windows.Forms.TextBox txtNumeroDeTarjerta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoOperacion;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.Label label1;
    }
}