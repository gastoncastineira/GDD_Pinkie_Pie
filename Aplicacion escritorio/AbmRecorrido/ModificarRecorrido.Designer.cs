namespace FrbaCrucero.AbmRecorrido
{
    partial class ModificarRecorrido
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
            this.dataGridViewTramos = new System.Windows.Forms.DataGridView();
            this.ButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.labelTramos = new System.Windows.Forms.Label();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.checkedListBoxTramos = new System.Windows.Forms.CheckedListBox();
            this.ButtonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTramos
            // 
            this.dataGridViewTramos.AllowUserToAddRows = false;
            this.dataGridViewTramos.AllowUserToDeleteRows = false;
            this.dataGridViewTramos.AllowUserToResizeColumns = false;
            this.dataGridViewTramos.AllowUserToResizeRows = false;
            this.dataGridViewTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTramos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ButtonDelete});
            this.dataGridViewTramos.Location = new System.Drawing.Point(12, 29);
            this.dataGridViewTramos.MultiSelect = false;
            this.dataGridViewTramos.Name = "dataGridViewTramos";
            this.dataGridViewTramos.ReadOnly = true;
            this.dataGridViewTramos.Size = new System.Drawing.Size(593, 150);
            this.dataGridViewTramos.TabIndex = 0;
            this.dataGridViewTramos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewTramos_CellContentClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.HeaderText = "Eliminar Tramo";
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.ReadOnly = true;
            // 
            // labelTramos
            // 
            this.labelTramos.AutoSize = true;
            this.labelTramos.Location = new System.Drawing.Point(13, 13);
            this.labelTramos.Name = "labelTramos";
            this.labelTramos.Size = new System.Drawing.Size(45, 13);
            this.labelTramos.TabIndex = 1;
            this.labelTramos.Text = "Tramos:";
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(12, 285);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregar.TabIndex = 2;
            this.buttonAgregar.Text = "Agregar Tramo";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.ButtonAgregar_Click);
            // 
            // checkedListBoxTramos
            // 
            this.checkedListBoxTramos.FormattingEnabled = true;
            this.checkedListBoxTramos.Location = new System.Drawing.Point(12, 185);
            this.checkedListBoxTramos.Name = "checkedListBoxTramos";
            this.checkedListBoxTramos.Size = new System.Drawing.Size(593, 94);
            this.checkedListBoxTramos.TabIndex = 7;
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(261, 332);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(75, 23);
            this.ButtonExit.TabIndex = 8;
            this.ButtonExit.Text = "Terminar";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ModificarRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 367);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.checkedListBoxTramos);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.labelTramos);
            this.Controls.Add(this.dataGridViewTramos);
            this.Name = "ModificarRecorrido";
            this.Text = "Modificar Recorrido";
            this.Load += new System.EventHandler(this.ModificarRecorrido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTramos;
        private System.Windows.Forms.Label labelTramos;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonDelete;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.CheckedListBox checkedListBoxTramos;
        private System.Windows.Forms.Button ButtonExit;
    }
}