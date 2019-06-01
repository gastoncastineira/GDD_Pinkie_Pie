namespace FrbaCrucero.ListadoEstadistico
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
            this.cbbAnio = new System.Windows.Forms.ComboBox();
            this.cbbAño = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClientes = new System.Windows.Forms.Button();
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
            this.dgvResultados.Location = new System.Drawing.Point(0, 159);
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
            this.cbbSemestre.Location = new System.Drawing.Point(250, 65);
            this.cbbSemestre.Name = "cbbSemestre";
            this.cbbSemestre.Size = new System.Drawing.Size(121, 21);
            this.cbbSemestre.TabIndex = 1;
            // 
            // cbbAnio
            // 
            this.cbbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAnio.Location = new System.Drawing.Point(250, 16);
            this.cbbAnio.Name = "cbbAnio";
            this.cbbAnio.Size = new System.Drawing.Size(121, 21);
            this.cbbAnio.TabIndex = 2;
            // 
            // cbbAño
            // 
            this.cbbAño.AutoSize = true;
            this.cbbAño.Location = new System.Drawing.Point(157, 19);
            this.cbbAño.Name = "cbbAño";
            this.cbbAño.Size = new System.Drawing.Size(26, 13);
            this.cbbAño.TabIndex = 3;
            this.cbbAño.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Semestre";
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(12, 117);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(113, 36);
            this.btnClientes.TabIndex = 5;
            this.btnClientes.Text = "Puntos de clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnRecorrido
            // 
            this.btnRecorrido.Location = new System.Drawing.Point(143, 117);
            this.btnRecorrido.Name = "btnRecorrido";
            this.btnRecorrido.Size = new System.Drawing.Size(130, 36);
            this.btnRecorrido.TabIndex = 6;
            this.btnRecorrido.Text = "Recorrido con mas pasajes";
            this.btnRecorrido.UseVisualStyleBackColor = true;
            this.btnRecorrido.Click += new System.EventHandler(this.btnRecorrido_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(291, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 36);
            this.button3.TabIndex = 7;
            this.button3.Text = "Mayores viajes libres ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(424, 117);
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
            this.ClientSize = new System.Drawing.Size(550, 313);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnRecorrido);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbAño);
            this.Controls.Add(this.cbbAnio);
            this.Controls.Add(this.cbbSemestre);
            this.Controls.Add(this.dgvResultados);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadístico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.ComboBox cbbSemestre;
        private System.Windows.Forms.ComboBox cbbAnio;
        private System.Windows.Forms.Label cbbAño;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnRecorrido;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}