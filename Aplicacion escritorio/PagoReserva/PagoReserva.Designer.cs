﻿namespace FrbaCrucero.PagoReserva
{
    partial class PagoReserva
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMetodoDePago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroDeTarjerta = new System.Windows.Forms.TextBox();
            this.lblNumeroDeTarjeta = new System.Windows.Forms.Label();
            this.lblCantidadDeCuotas = new System.Windows.Forms.Label();
            this.cmbCantidadDeCuotas = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pagar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo Reserva";
            // 
            // cmbMetodoDePago
            // 
            this.cmbMetodoDePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoDePago.ItemHeight = 13;
            this.cmbMetodoDePago.Items.AddRange(new object[] {
            "EFECTIVO",
            "CREDITO",
            "DEBITO"});
            this.cmbMetodoDePago.Location = new System.Drawing.Point(122, 87);
            this.cmbMetodoDePago.Name = "cmbMetodoDePago";
            this.cmbMetodoDePago.Size = new System.Drawing.Size(121, 21);
            this.cmbMetodoDePago.TabIndex = 3;
            this.cmbMetodoDePago.SelectedIndexChanged += new System.EventHandler(this.cmbMetodoDePago_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Medio de pago";
            // 
            // txtNumeroDeTarjerta
            // 
            this.txtNumeroDeTarjerta.Location = new System.Drawing.Point(122, 130);
            this.txtNumeroDeTarjerta.Name = "txtNumeroDeTarjerta";
            this.txtNumeroDeTarjerta.Size = new System.Drawing.Size(121, 20);
            this.txtNumeroDeTarjerta.TabIndex = 2;
            this.txtNumeroDeTarjerta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDeTarjerta_KeyPress);
            // 
            // lblNumeroDeTarjeta
            // 
            this.lblNumeroDeTarjeta.AutoSize = true;
            this.lblNumeroDeTarjeta.Location = new System.Drawing.Point(11, 133);
            this.lblNumeroDeTarjeta.Name = "lblNumeroDeTarjeta";
            this.lblNumeroDeTarjeta.Size = new System.Drawing.Size(91, 13);
            this.lblNumeroDeTarjeta.TabIndex = 10;
            this.lblNumeroDeTarjeta.Text = "Numero de tarjeta";
            // 
            // lblCantidadDeCuotas
            // 
            this.lblCantidadDeCuotas.AutoSize = true;
            this.lblCantidadDeCuotas.Location = new System.Drawing.Point(12, 174);
            this.lblCantidadDeCuotas.Name = "lblCantidadDeCuotas";
            this.lblCantidadDeCuotas.Size = new System.Drawing.Size(99, 13);
            this.lblCantidadDeCuotas.TabIndex = 9;
            this.lblCantidadDeCuotas.Text = "Cantidad de cuotas";
            // 
            // cmbCantidadDeCuotas
            // 
            this.cmbCantidadDeCuotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCantidadDeCuotas.FormattingEnabled = true;
            this.cmbCantidadDeCuotas.ItemHeight = 13;
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
            this.cmbCantidadDeCuotas.Location = new System.Drawing.Point(122, 171);
            this.cmbCantidadDeCuotas.Name = "cmbCantidadDeCuotas";
            this.cmbCantidadDeCuotas.Size = new System.Drawing.Size(121, 21);
            this.cmbCantidadDeCuotas.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // PagoReserva
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 306);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtNumeroDeTarjerta);
            this.Controls.Add(this.lblNumeroDeTarjeta);
            this.Controls.Add(this.lblCantidadDeCuotas);
            this.Controls.Add(this.cmbCantidadDeCuotas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMetodoDePago);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "PagoReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago de Reserva";
            this.Load += new System.EventHandler(this.PagoReserva_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMetodoDePago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroDeTarjerta;
        private System.Windows.Forms.Label lblNumeroDeTarjeta;
        private System.Windows.Forms.Label lblCantidadDeCuotas;
        private System.Windows.Forms.ComboBox cmbCantidadDeCuotas;
        private System.Windows.Forms.TextBox textBox1;
    }
}