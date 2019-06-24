namespace FrbaCrucero.AbmRecorrido
{
    partial class ListaDeRecorridos
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
            this.dataGridViewRecorridos = new System.Windows.Forms.DataGridView();
            this.labelNombreGrid = new System.Windows.Forms.Label();
            this.buttonCrear = new System.Windows.Forms.Button();
            this.dataGridViewTramos = new System.Windows.Forms.DataGridView();
            this.labelTramo = new System.Windows.Forms.Label();
            this.ButtomDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonHabilitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ButtomEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ButtonVer = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecorridos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRecorridos
            // 
            this.dataGridViewRecorridos.AllowUserToAddRows = false;
            this.dataGridViewRecorridos.AllowUserToDeleteRows = false;
            this.dataGridViewRecorridos.AllowUserToResizeColumns = false;
            this.dataGridViewRecorridos.AllowUserToResizeRows = false;
            this.dataGridViewRecorridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecorridos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ButtomDelete,
            this.buttonHabilitar,
            this.ButtomEdit,
            this.ButtonVer});
            this.dataGridViewRecorridos.Location = new System.Drawing.Point(12, 54);
            this.dataGridViewRecorridos.Name = "dataGridViewRecorridos";
            this.dataGridViewRecorridos.ReadOnly = true;
            this.dataGridViewRecorridos.RowHeadersVisible = false;
            this.dataGridViewRecorridos.Size = new System.Drawing.Size(782, 189);
            this.dataGridViewRecorridos.TabIndex = 0;
            this.dataGridViewRecorridos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRecorridos_CellContentClick);
            // 
            // labelNombreGrid
            // 
            this.labelNombreGrid.AutoSize = true;
            this.labelNombreGrid.Location = new System.Drawing.Point(13, 35);
            this.labelNombreGrid.Name = "labelNombreGrid";
            this.labelNombreGrid.Size = new System.Drawing.Size(64, 13);
            this.labelNombreGrid.TabIndex = 1;
            this.labelNombreGrid.Text = "Recorridos: ";
            // 
            // buttonCrear
            // 
            this.buttonCrear.Location = new System.Drawing.Point(12, 249);
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(135, 23);
            this.buttonCrear.TabIndex = 2;
            this.buttonCrear.Text = "Crear nuevo recorrido";
            this.buttonCrear.UseVisualStyleBackColor = true;
            this.buttonCrear.Click += new System.EventHandler(this.ButtonCrear_Click);
            // 
            // dataGridViewTramos
            // 
            this.dataGridViewTramos.AllowUserToAddRows = false;
            this.dataGridViewTramos.AllowUserToDeleteRows = false;
            this.dataGridViewTramos.AllowUserToResizeColumns = false;
            this.dataGridViewTramos.AllowUserToResizeRows = false;
            this.dataGridViewTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTramos.Location = new System.Drawing.Point(12, 295);
            this.dataGridViewTramos.MultiSelect = false;
            this.dataGridViewTramos.Name = "dataGridViewTramos";
            this.dataGridViewTramos.ReadOnly = true;
            this.dataGridViewTramos.Size = new System.Drawing.Size(782, 137);
            this.dataGridViewTramos.TabIndex = 3;
            // 
            // labelTramo
            // 
            this.labelTramo.AutoSize = true;
            this.labelTramo.Location = new System.Drawing.Point(12, 279);
            this.labelTramo.Name = "labelTramo";
            this.labelTramo.Size = new System.Drawing.Size(103, 13);
            this.labelTramo.TabIndex = 4;
            this.labelTramo.Text = "Tramos del recorido:";
            // 
            // ButtomDelete
            // 
            this.ButtomDelete.HeaderText = "Dar de baja";
            this.ButtomDelete.Name = "ButtomDelete";
            this.ButtomDelete.ReadOnly = true;
            // 
            // buttonHabilitar
            // 
            this.buttonHabilitar.HeaderText = "Dar de alta";
            this.buttonHabilitar.Name = "buttonHabilitar";
            this.buttonHabilitar.ReadOnly = true;
            // 
            // ButtomEdit
            // 
            this.ButtomEdit.HeaderText = "Modificar";
            this.ButtomEdit.Name = "ButtomEdit";
            this.ButtomEdit.ReadOnly = true;
            // 
            // ButtonVer
            // 
            this.ButtonVer.HeaderText = "Ver detalle";
            this.ButtonVer.Name = "ButtonVer";
            this.ButtonVer.ReadOnly = true;
            // 
            // ListaDeRecorridos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 445);
            this.Controls.Add(this.labelTramo);
            this.Controls.Add(this.dataGridViewTramos);
            this.Controls.Add(this.buttonCrear);
            this.Controls.Add(this.labelNombreGrid);
            this.Controls.Add(this.dataGridViewRecorridos);
            this.Name = "ListaDeRecorridos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Recorridos";
            this.Load += new System.EventHandler(this.ListaDeRecorridos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecorridos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRecorridos;
        public System.Windows.Forms.Label labelNombreGrid;
        private System.Windows.Forms.Button buttonCrear;
        private System.Windows.Forms.DataGridView dataGridViewTramos;
        private System.Windows.Forms.Label labelTramo;
        private System.Windows.Forms.DataGridViewButtonColumn ButtomDelete;
        private System.Windows.Forms.DataGridViewButtonColumn buttonHabilitar;
        private System.Windows.Forms.DataGridViewButtonColumn ButtomEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonVer;
    }
}