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
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTramos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRecorridos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(132, 34);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(399, 20);
            this.txtBuscar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 37);
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
            this.dataGridRecorridos.Location = new System.Drawing.Point(38, 73);
            this.dataGridRecorridos.MultiSelect = false;
            this.dataGridRecorridos.Name = "dataGridRecorridos";
            this.dataGridRecorridos.ReadOnly = true;
            this.dataGridRecorridos.RowHeadersVisible = false;
            this.dataGridRecorridos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRecorridos.Size = new System.Drawing.Size(588, 195);
            this.dataGridRecorridos.TabIndex = 2;
            this.dataGridRecorridos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridRecorridos_CellClick);
            // 
            // btlBuscar
            // 
            this.btlBuscar.Location = new System.Drawing.Point(551, 32);
            this.btlBuscar.Name = "btlBuscar";
            this.btlBuscar.Size = new System.Drawing.Size(75, 23);
            this.btlBuscar.TabIndex = 1;
            this.btlBuscar.Text = "Buscar";
            this.btlBuscar.UseVisualStyleBackColor = true;
            this.btlBuscar.Click += new System.EventHandler(this.BtlBuscar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(469, 471);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(118, 23);
            this.btnSeleccionar.TabIndex = 4;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(87, 471);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(118, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tramos del recorrido:";
            // 
            // dataGridViewTramos
            // 
            this.dataGridViewTramos.AllowUserToAddRows = false;
            this.dataGridViewTramos.AllowUserToDeleteRows = false;
            this.dataGridViewTramos.AllowUserToResizeColumns = false;
            this.dataGridViewTramos.AllowUserToResizeRows = false;
            this.dataGridViewTramos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTramos.Enabled = false;
            this.dataGridViewTramos.Location = new System.Drawing.Point(38, 307);
            this.dataGridViewTramos.MultiSelect = false;
            this.dataGridViewTramos.Name = "dataGridViewTramos";
            this.dataGridViewTramos.ReadOnly = true;
            this.dataGridViewTramos.RowHeadersVisible = false;
            this.dataGridViewTramos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTramos.Size = new System.Drawing.Size(588, 150);
            this.dataGridViewTramos.TabIndex = 3;
            // 
            // Recorridos
            // 
            this.AcceptButton = this.btnSeleccionar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 517);
            this.Controls.Add(this.dataGridViewTramos);
            this.Controls.Add(this.label2);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewTramos;
    }
}