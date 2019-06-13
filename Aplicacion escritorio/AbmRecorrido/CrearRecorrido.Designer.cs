namespace FrbaCrucero.AbmRecorrido
{
    partial class CrearRecorrido
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
            this.checkedListBoxTramos = new System.Windows.Forms.CheckedListBox();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.dataGridViewRecorrido = new System.Windows.Forms.DataGridView();
            this.buttonQuitar = new System.Windows.Forms.Button();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecorrido)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBoxTramos
            // 
            this.checkedListBoxTramos.FormattingEnabled = true;
            this.checkedListBoxTramos.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxTramos.Name = "checkedListBoxTramos";
            this.checkedListBoxTramos.Size = new System.Drawing.Size(284, 424);
            this.checkedListBoxTramos.TabIndex = 0;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(317, 230);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(174, 38);
            this.buttonAgregar.TabIndex = 1;
            this.buttonAgregar.Text = "Agregar tramo";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.ButtonAgregar_Click);
            // 
            // dataGridViewRecorrido
            // 
            this.dataGridViewRecorrido.AllowUserToAddRows = false;
            this.dataGridViewRecorrido.AllowUserToDeleteRows = false;
            this.dataGridViewRecorrido.AllowUserToResizeColumns = false;
            this.dataGridViewRecorrido.AllowUserToResizeRows = false;
            this.dataGridViewRecorrido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecorrido.Location = new System.Drawing.Point(302, 12);
            this.dataGridViewRecorrido.MultiSelect = false;
            this.dataGridViewRecorrido.Name = "dataGridViewRecorrido";
            this.dataGridViewRecorrido.ReadOnly = true;
            this.dataGridViewRecorrido.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewRecorrido.Size = new System.Drawing.Size(629, 212);
            this.dataGridViewRecorrido.StandardTab = true;
            this.dataGridViewRecorrido.TabIndex = 2;
            // 
            // buttonQuitar
            // 
            this.buttonQuitar.Location = new System.Drawing.Point(534, 230);
            this.buttonQuitar.Name = "buttonQuitar";
            this.buttonQuitar.Size = new System.Drawing.Size(174, 38);
            this.buttonQuitar.TabIndex = 3;
            this.buttonQuitar.Text = "Quitar ultimo tramo";
            this.buttonQuitar.UseVisualStyleBackColor = true;
            this.buttonQuitar.Click += new System.EventHandler(this.ButtonQuitar_Click);
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(751, 230);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(174, 38);
            this.buttonConfirmar.TabIndex = 4;
            this.buttonConfirmar.Text = "Confirmar recorrido";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.ButtonConfirmar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(801, 399);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(130, 37);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.ButtonCancelar_Click);
            // 
            // CrearRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonConfirmar);
            this.Controls.Add(this.buttonQuitar);
            this.Controls.Add(this.dataGridViewRecorrido);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.checkedListBoxTramos);
            this.Name = "CrearRecorrido";
            this.Text = "Generar Recorrido";
            this.Load += new System.EventHandler(this.CrearRecorrido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecorrido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxTramos;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.DataGridView dataGridViewRecorrido;
        private System.Windows.Forms.Button buttonQuitar;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}