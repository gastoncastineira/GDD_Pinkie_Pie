namespace FrbaCrucero.GeneracionViaje
{
    partial class Cruceros
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
            this.txtBuscarCrucero = new System.Windows.Forms.TextBox();
            this.btnBuscarCrucero = new System.Windows.Forms.Button();
            this.dataGridCruceros = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCruceros)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre crucero:";
            // 
            // txtBuscarCrucero
            // 
            this.txtBuscarCrucero.Location = new System.Drawing.Point(156, 63);
            this.txtBuscarCrucero.Name = "txtBuscarCrucero";
            this.txtBuscarCrucero.Size = new System.Drawing.Size(278, 20);
            this.txtBuscarCrucero.TabIndex = 0;
            // 
            // btnBuscarCrucero
            // 
            this.btnBuscarCrucero.Location = new System.Drawing.Point(459, 61);
            this.btnBuscarCrucero.Name = "btnBuscarCrucero";
            this.btnBuscarCrucero.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarCrucero.TabIndex = 1;
            this.btnBuscarCrucero.Text = "Buscar";
            this.btnBuscarCrucero.UseVisualStyleBackColor = true;
            this.btnBuscarCrucero.Click += new System.EventHandler(this.BtnBuscarCrucero_Click);
            // 
            // dataGridCruceros
            // 
            this.dataGridCruceros.AllowUserToAddRows = false;
            this.dataGridCruceros.AllowUserToDeleteRows = false;
            this.dataGridCruceros.AllowUserToResizeColumns = false;
            this.dataGridCruceros.AllowUserToResizeRows = false;
            this.dataGridCruceros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCruceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCruceros.Location = new System.Drawing.Point(55, 137);
            this.dataGridCruceros.Name = "dataGridCruceros";
            this.dataGridCruceros.ReadOnly = true;
            this.dataGridCruceros.RowHeadersVisible = false;
            this.dataGridCruceros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCruceros.Size = new System.Drawing.Size(489, 215);
            this.dataGridCruceros.TabIndex = 2;
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
            // Cruceros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dataGridCruceros);
            this.Controls.Add(this.btnBuscarCrucero);
            this.Controls.Add(this.txtBuscarCrucero);
            this.Controls.Add(this.label1);
            this.Name = "Cruceros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crucero";
            this.Load += new System.EventHandler(this.Cruceros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCruceros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarCrucero;
        private System.Windows.Forms.Button btnBuscarCrucero;
        public System.Windows.Forms.DataGridView dataGridCruceros;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnSalir;
    }
}