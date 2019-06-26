namespace FrbaCrucero.GeneracionViaje
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
            this.btnConsultarCruceros = new System.Windows.Forms.Button();
            this.btnConsultarRecorridos = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRecorrido = new System.Windows.Forms.TextBox();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dtHoraFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
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
            // btnConsultarCruceros
            // 
            this.btnConsultarCruceros.Location = new System.Drawing.Point(217, 183);
            this.btnConsultarCruceros.Name = "btnConsultarCruceros";
            this.btnConsultarCruceros.Size = new System.Drawing.Size(121, 23);
            this.btnConsultarCruceros.TabIndex = 5;
            this.btnConsultarCruceros.Text = "Consultar Cruceros";
            this.btnConsultarCruceros.UseVisualStyleBackColor = true;
            this.btnConsultarCruceros.Click += new System.EventHandler(this.BtnConsultarCruceros_Click);
            // 
            // btnConsultarRecorridos
            // 
            this.btnConsultarRecorridos.Location = new System.Drawing.Point(217, 222);
            this.btnConsultarRecorridos.Name = "btnConsultarRecorridos";
            this.btnConsultarRecorridos.Size = new System.Drawing.Size(121, 23);
            this.btnConsultarRecorridos.TabIndex = 7;
            this.btnConsultarRecorridos.Text = "Consultar Recorridos";
            this.btnConsultarRecorridos.UseVisualStyleBackColor = true;
            this.btnConsultarRecorridos.Click += new System.EventHandler(this.BtnConsultarRecorridos_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(497, 278);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
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
            this.txtRecorrido.TabIndex = 6;
            this.txtRecorrido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.Location = new System.Drawing.Point(182, 64);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtFechaInicio.TabIndex = 0;
            // 
            // dtHoraInicio
            // 
            this.dtHoraInicio.CustomFormat = "hh:mm:ss";
            this.dtHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoraInicio.Location = new System.Drawing.Point(497, 63);
            this.dtHoraInicio.Name = "dtHoraInicio";
            this.dtHoraInicio.ShowUpDown = true;
            this.dtHoraInicio.Size = new System.Drawing.Size(70, 20);
            this.dtHoraInicio.TabIndex = 1;
            this.dtHoraInicio.Value = new System.DateTime(2019, 5, 12, 16, 30, 0, 0);
            // 
            // dtHoraFin
            // 
            this.dtHoraFin.CustomFormat = "hh:mm:ss";
            this.dtHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoraFin.Location = new System.Drawing.Point(497, 101);
            this.dtHoraFin.Name = "dtHoraFin";
            this.dtHoraFin.ShowUpDown = true;
            this.dtHoraFin.Size = new System.Drawing.Size(70, 20);
            this.dtHoraFin.TabIndex = 3;
            this.dtHoraFin.Value = new System.DateTime(2019, 5, 12, 16, 30, 0, 0);
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Location = new System.Drawing.Point(182, 100);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtFechaFin.TabIndex = 2;
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
            this.txtCrucero.TabIndex = 4;
            this.txtCrucero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GenerarViaje
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 318);
            this.Controls.Add(this.txtCrucero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFechaFin);
            this.Controls.Add(this.dtHoraFin);
            this.Controls.Add(this.dtHoraInicio);
            this.Controls.Add(this.dtFechaInicio);
            this.Controls.Add(this.txtRecorrido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnConsultarRecorridos);
            this.Controls.Add(this.btnConsultarCruceros);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerarViaje";
            this.Text = "Generar un viaje";
            this.Load += new System.EventHandler(this.GenerarViaje_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnConsultarCruceros, 0);
            this.Controls.SetChildIndex(this.btnConsultarRecorridos, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRecorrido, 0);
            this.Controls.SetChildIndex(this.dtFechaInicio, 0);
            this.Controls.SetChildIndex(this.dtHoraInicio, 0);
            this.Controls.SetChildIndex(this.dtHoraFin, 0);
            this.Controls.SetChildIndex(this.dtFechaFin, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtCrucero, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultarCruceros;
        private System.Windows.Forms.Button btnConsultarRecorridos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRecorrido;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.DateTimePicker dtHoraInicio;
        private System.Windows.Forms.DateTimePicker dtHoraFin;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCrucero;
    }
}