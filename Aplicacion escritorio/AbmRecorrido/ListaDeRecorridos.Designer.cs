﻿namespace FrbaCrucero.AbmRecorrido
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
            this.ButtomDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ButtomEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonCrear = new System.Windows.Forms.Button();
            this.ButtonVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTramos = new System.Windows.Forms.DataGridView();
            this.labelTramo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecorridos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRecorridos
            // 
            this.dataGridViewRecorridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecorridos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ButtomDelete,
            this.ButtomEdit,
            this.ButtonVer});
            this.dataGridViewRecorridos.Location = new System.Drawing.Point(12, 46);
            this.dataGridViewRecorridos.Name = "dataGridViewRecorridos";
            this.dataGridViewRecorridos.Size = new System.Drawing.Size(776, 189);
            this.dataGridViewRecorridos.TabIndex = 0;
            this.dataGridViewRecorridos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRecorridos_CellContentClick);
            // 
            // labelNombreGrid
            // 
            this.labelNombreGrid.AutoSize = true;
            this.labelNombreGrid.Location = new System.Drawing.Point(13, 27);
            this.labelNombreGrid.Name = "labelNombreGrid";
            this.labelNombreGrid.Size = new System.Drawing.Size(64, 13);
            this.labelNombreGrid.TabIndex = 1;
            this.labelNombreGrid.Text = "Recorridos: ";
            this.labelNombreGrid.Click += new System.EventHandler(this.LabelNombreGrid_Click);
            // 
            // ButtomDelete
            // 
            this.ButtomDelete.HeaderText = "Dar de baja";
            this.ButtomDelete.Name = "ButtomDelete";
            // 
            // ButtomEdit
            // 
            this.ButtomEdit.HeaderText = "Modificar";
            this.ButtomEdit.Name = "ButtomEdit";
            // 
            // buttonCrear
            // 
            this.buttonCrear.Location = new System.Drawing.Point(12, 241);
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(135, 23);
            this.buttonCrear.TabIndex = 2;
            this.buttonCrear.Text = "Crear nuevo recorrido";
            this.buttonCrear.UseVisualStyleBackColor = true;
            this.buttonCrear.Click += new System.EventHandler(this.ButtonCrear_Click);
            // 
            // ButtonVer
            // 
            this.ButtonVer.HeaderText = "Ver detalle";
            this.ButtonVer.Name = "ButtonVer";
            // 
            // dataGridViewTramos
            // 
            this.dataGridViewTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTramos.Location = new System.Drawing.Point(12, 287);
            this.dataGridViewTramos.Name = "dataGridViewTramos";
            this.dataGridViewTramos.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewTramos.TabIndex = 3;
            // 
            // labelTramo
            // 
            this.labelTramo.AutoSize = true;
            this.labelTramo.Location = new System.Drawing.Point(12, 271);
            this.labelTramo.Name = "labelTramo";
            this.labelTramo.Size = new System.Drawing.Size(103, 13);
            this.labelTramo.TabIndex = 4;
            this.labelTramo.Text = "Tramos del recorido:";
            // 
            // ListaDeRecorridos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.labelTramo);
            this.Controls.Add(this.dataGridViewTramos);
            this.Controls.Add(this.buttonCrear);
            this.Controls.Add(this.labelNombreGrid);
            this.Controls.Add(this.dataGridViewRecorridos);
            this.Name = "ListaDeRecorridos";
            this.Text = "Lista de Recorridos";
            this.Load += new System.EventHandler(this.ListaDeRecorridos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecorridos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRecorridos;
        private System.Windows.Forms.DataGridViewButtonColumn ButtomDelete;
        private System.Windows.Forms.DataGridViewButtonColumn ButtomEdit;
        public System.Windows.Forms.Label labelNombreGrid;
        private System.Windows.Forms.Button buttonCrear;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonVer;
        private System.Windows.Forms.DataGridView dataGridViewTramos;
        private System.Windows.Forms.Label labelTramo;
    }
}