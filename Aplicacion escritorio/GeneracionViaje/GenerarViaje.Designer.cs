﻿namespace FrbaCrucero.GeneracionViaje
{
    partial class GenerarViaje
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarCruceros = new System.Windows.Forms.Button();
            this.btnBuscarRecorridos = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRecorrido = new System.Windows.Forms.TextBox();
            this.dateTimeFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimeHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimeHoraFin = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCrucero = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese fechas";
            // 
            // btnBuscarCruceros
            // 
            this.btnBuscarCruceros.Location = new System.Drawing.Point(217, 183);
            this.btnBuscarCruceros.Name = "btnBuscarCruceros";
            this.btnBuscarCruceros.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarCruceros.TabIndex = 2;
            this.btnBuscarCruceros.Text = "Buscar";
            this.btnBuscarCruceros.UseVisualStyleBackColor = true;
            this.btnBuscarCruceros.Click += new System.EventHandler(this.BtnCruceros_Click);
            // 
            // btnBuscarRecorridos
            // 
            this.btnBuscarRecorridos.Location = new System.Drawing.Point(217, 222);
            this.btnBuscarRecorridos.Name = "btnBuscarRecorridos";
            this.btnBuscarRecorridos.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarRecorridos.TabIndex = 4;
            this.btnBuscarRecorridos.Text = "Buscar";
            this.btnBuscarRecorridos.UseVisualStyleBackColor = true;
            this.btnBuscarRecorridos.Click += new System.EventHandler(this.BtnBuscarRecorridos_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(533, 401);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(423, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hora inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hora fin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Recorrido:";
            // 
            // txtRecorrido
            // 
            this.txtRecorrido.Location = new System.Drawing.Point(102, 224);
            this.txtRecorrido.Name = "txtRecorrido";
            this.txtRecorrido.Size = new System.Drawing.Size(100, 20);
            this.txtRecorrido.TabIndex = 15;
            this.txtRecorrido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimeFechaInicio
            // 
            this.dateTimeFechaInicio.Location = new System.Drawing.Point(182, 64);
            this.dateTimeFechaInicio.Name = "dateTimeFechaInicio";
            this.dateTimeFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFechaInicio.TabIndex = 0;
            // 
            // dateTimeHoraInicio
            // 
            this.dateTimeHoraInicio.CustomFormat = "hh:mm:ss";
            this.dateTimeHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeHoraInicio.Location = new System.Drawing.Point(497, 63);
            this.dateTimeHoraInicio.Name = "dateTimeHoraInicio";
            this.dateTimeHoraInicio.ShowUpDown = true;
            this.dateTimeHoraInicio.Size = new System.Drawing.Size(70, 20);
            this.dateTimeHoraInicio.TabIndex = 1;
            this.dateTimeHoraInicio.Value = new System.DateTime(2019, 5, 12, 16, 30, 0, 0);
            // 
            // dateTimeHoraFin
            // 
            this.dateTimeHoraFin.CustomFormat = "hh:mm:ss";
            this.dateTimeHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimeHoraFin.Location = new System.Drawing.Point(497, 101);
            this.dateTimeHoraFin.Name = "dateTimeHoraFin";
            this.dateTimeHoraFin.ShowUpDown = true;
            this.dateTimeHoraFin.Size = new System.Drawing.Size(70, 20);
            this.dateTimeHoraFin.TabIndex = 3;
            this.dateTimeHoraFin.Value = new System.DateTime(2019, 5, 12, 16, 30, 0, 0);
            // 
            // dateTimeFechaFin
            // 
            this.dateTimeFechaFin.Location = new System.Drawing.Point(182, 100);
            this.dateTimeFechaFin.Name = "dateTimeFechaFin";
            this.dateTimeFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFechaFin.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fecha de inicio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Fecha de finalización ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Crucero:";
            // 
            // txtCrucero
            // 
            this.txtCrucero.Location = new System.Drawing.Point(102, 186);
            this.txtCrucero.Name = "txtCrucero";
            this.txtCrucero.Size = new System.Drawing.Size(100, 20);
            this.txtCrucero.TabIndex = 23;
            this.txtCrucero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GenerarViaje
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 461);
            this.Controls.Add(this.txtCrucero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimeFechaFin);
            this.Controls.Add(this.dateTimeHoraFin);
            this.Controls.Add(this.dateTimeHoraInicio);
            this.Controls.Add(this.dateTimeFechaInicio);
            this.Controls.Add(this.txtRecorrido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnBuscarRecorridos);
            this.Controls.Add(this.btnBuscarCruceros);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerarViaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar un viaje";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GenerarViaje_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarCruceros;
        private System.Windows.Forms.Button btnBuscarRecorridos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRecorrido;
        private System.Windows.Forms.DateTimePicker dateTimeFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimeHoraInicio;
        private System.Windows.Forms.DateTimePicker dateTimeHoraFin;
        private System.Windows.Forms.DateTimePicker dateTimeFechaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCrucero;
    }
}