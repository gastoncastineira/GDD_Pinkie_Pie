namespace FrbaCrucero.GeneracionViaje
{
    partial class Recorridos
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
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridRecorridos = new System.Windows.Forms.DataGridView();
            this.btlBuscar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecorridos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(156, 63);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(278, 20);
            this.txtBuscar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre recorrido:";
            // 
            // dataGridRecorridos
            // 
            this.dataGridRecorridos.AllowUserToAddRows = false;
            this.dataGridRecorridos.AllowUserToDeleteRows = false;
            this.dataGridRecorridos.AllowUserToResizeColumns = false;
            this.dataGridRecorridos.AllowUserToResizeRows = false;
            this.dataGridRecorridos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridRecorridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRecorridos.Location = new System.Drawing.Point(55, 137);
            this.dataGridRecorridos.Name = "dataGridRecorridos";
            this.dataGridRecorridos.ReadOnly = true;
            this.dataGridRecorridos.RowHeadersVisible = false;
            this.dataGridRecorridos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRecorridos.Size = new System.Drawing.Size(489, 215);
            this.dataGridRecorridos.TabIndex = 2;
            // 
            // btlBuscar
            // 
            this.btlBuscar.Location = new System.Drawing.Point(459, 61);
            this.btlBuscar.Name = "btlBuscar";
            this.btlBuscar.Size = new System.Drawing.Size(75, 23);
            this.btlBuscar.TabIndex = 1;
            this.btlBuscar.Text = "Buscar";
            this.btlBuscar.UseVisualStyleBackColor = true;
            this.btlBuscar.Click += new System.EventHandler(this.BtlBuscar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(359, 380);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(118, 23);
            this.btnSeleccionar.TabIndex = 4;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(89, 380);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(118, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // Recorridos
            // 
            this.AcceptButton = this.btnSeleccionar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btlBuscar);
            this.Controls.Add(this.dataGridRecorridos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Name = "Recorridos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recorridos";
            this.Load += new System.EventHandler(this.Recorridos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecorridos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.DataGridView dataGridRecorridos;
        public System.Windows.Forms.TextBox txtBuscar;
        public System.Windows.Forms.Button btlBuscar;
        public System.Windows.Forms.Button btnSeleccionar;
    }
}