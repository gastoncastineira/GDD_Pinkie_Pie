﻿namespace FrbaCrucero.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.cbbSemestre = new System.Windows.Forms.ComboBox();
            this.cbbAño = new System.Windows.Forms.ComboBox();
            this.lblAño = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRecorrido = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResultados.Location = new System.Drawing.Point(-1, 190);
            this.dgvResultados.MultiSelect = false;
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.Size = new System.Drawing.Size(554, 153);
            this.dgvResultados.TabIndex = 0;
            // 
            // cbbSemestre
            // 
            this.cbbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSemestre.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbbSemestre.Location = new System.Drawing.Point(249, 96);
            this.cbbSemestre.Name = "cbbSemestre";
            this.cbbSemestre.Size = new System.Drawing.Size(121, 21);
            this.cbbSemestre.TabIndex = 1;
            // 
            // cbbAño
            // 
            this.cbbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAño.Location = new System.Drawing.Point(249, 47);
            this.cbbAño.Name = "cbbAño";
            this.cbbAño.Size = new System.Drawing.Size(121, 21);
            this.cbbAño.TabIndex = 2;
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Location = new System.Drawing.Point(156, 50);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(26, 13);
            this.lblAño.TabIndex = 3;
            this.lblAño.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Semestre";
            // 
            // btnRecorrido
            // 
            this.btnRecorrido.Location = new System.Drawing.Point(68, 148);
            this.btnRecorrido.Name = "btnRecorrido";
            this.btnRecorrido.Size = new System.Drawing.Size(130, 36);
            this.btnRecorrido.TabIndex = 6;
            this.btnRecorrido.Text = "Recorrido con mas pasajes";
            this.btnRecorrido.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(215, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 36);
            this.button3.TabIndex = 7;
            this.button3.Text = "Mayores viajes libres ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(357, 148);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 36);
            this.button4.TabIndex = 8;
            this.button4.Text = "Cruceros Fuera de Servicio";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 340);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnRecorrido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAño);
            this.Controls.Add(this.cbbAño);
            this.Controls.Add(this.cbbSemestre);
            this.Controls.Add(this.dgvResultados);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadístico";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.ComboBox cbbSemestre;
        private System.Windows.Forms.ComboBox cbbAño;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRecorrido;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}