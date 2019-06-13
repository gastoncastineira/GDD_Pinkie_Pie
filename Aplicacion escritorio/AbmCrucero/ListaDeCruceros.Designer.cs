namespace FrbaCrucero.AbmCrucero
{
    partial class ListaDeCruceros
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
            this.labelTramo = new System.Windows.Forms.Label();
            this.dataGridViewCabinas = new System.Windows.Forms.DataGridView();
            this.buttonCrear = new System.Windows.Forms.Button();
            this.labelNombreGrid = new System.Windows.Forms.Label();
            this.dataGridViewCruceros = new System.Windows.Forms.DataGridView();
            this.ButtomDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ButtomEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ButtonVer = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCabinas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCruceros)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTramo
            // 
            this.labelTramo.AutoSize = true;
            this.labelTramo.Location = new System.Drawing.Point(9, 283);
            this.labelTramo.Name = "labelTramo";
            this.labelTramo.Size = new System.Drawing.Size(94, 13);
            this.labelTramo.TabIndex = 10;
            this.labelTramo.Text = "Datos del crucero:";
            // 
            // dataGridViewCabinas
            // 
            this.dataGridViewCabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCabinas.Location = new System.Drawing.Point(9, 299);
            this.dataGridViewCabinas.MultiSelect = false;
            this.dataGridViewCabinas.Name = "dataGridViewCabinas";
            this.dataGridViewCabinas.ReadOnly = true;
            this.dataGridViewCabinas.Size = new System.Drawing.Size(782, 137);
            this.dataGridViewCabinas.TabIndex = 9;
            // 
            // buttonCrear
            // 
            this.buttonCrear.Location = new System.Drawing.Point(9, 253);
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(135, 23);
            this.buttonCrear.TabIndex = 8;
            this.buttonCrear.Text = "Crear nuevo crucero";
            this.buttonCrear.UseVisualStyleBackColor = true;
            this.buttonCrear.Click += new System.EventHandler(this.buttonCrear_Click_1);
            // 
            // labelNombreGrid
            // 
            this.labelNombreGrid.AutoSize = true;
            this.labelNombreGrid.Location = new System.Drawing.Point(10, 39);
            this.labelNombreGrid.Name = "labelNombreGrid";
            this.labelNombreGrid.Size = new System.Drawing.Size(55, 13);
            this.labelNombreGrid.TabIndex = 7;
            this.labelNombreGrid.Text = "Cruceros: ";
            // 
            // dataGridViewCruceros
            // 
            this.dataGridViewCruceros.AllowUserToAddRows = false;
            this.dataGridViewCruceros.AllowUserToDeleteRows = false;
            this.dataGridViewCruceros.AllowUserToResizeColumns = false;
            this.dataGridViewCruceros.AllowUserToResizeRows = false;
            this.dataGridViewCruceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCruceros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ButtomDelete,
            this.ButtomEdit,
            this.ButtonVer});
            this.dataGridViewCruceros.Location = new System.Drawing.Point(9, 58);
            this.dataGridViewCruceros.MultiSelect = false;
            this.dataGridViewCruceros.Name = "dataGridViewCruceros";
            this.dataGridViewCruceros.ReadOnly = true;
            this.dataGridViewCruceros.Size = new System.Drawing.Size(782, 189);
            this.dataGridViewCruceros.TabIndex = 6;
            this.dataGridViewCruceros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCruceros_CellContentClick);
            // 
            // ButtomDelete
            // 
            this.ButtomDelete.HeaderText = "Dar de baja";
            this.ButtomDelete.Name = "ButtomDelete";
            this.ButtomDelete.ReadOnly = true;
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
            // ListaDeCruceros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTramo);
            this.Controls.Add(this.dataGridViewCabinas);
            this.Controls.Add(this.buttonCrear);
            this.Controls.Add(this.labelNombreGrid);
            this.Controls.Add(this.dataGridViewCruceros);
            this.Name = "ListaDeCruceros";
            this.Text = "ListaDeCruceros";
            this.Load += new System.EventHandler(this.ListaDeCruceros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCabinas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCruceros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTramo;
        private System.Windows.Forms.DataGridView dataGridViewCabinas;
        private System.Windows.Forms.Button buttonCrear;
        public System.Windows.Forms.Label labelNombreGrid;
        private System.Windows.Forms.DataGridView dataGridViewCruceros;
        private System.Windows.Forms.DataGridViewButtonColumn ButtomDelete;
        private System.Windows.Forms.DataGridViewButtonColumn ButtomEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonVer;
    }
}