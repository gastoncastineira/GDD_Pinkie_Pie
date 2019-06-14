namespace FrbaCrucero.CompraReservaPasaje
{
    partial class SeleccionarViaje
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtViajes = new System.Windows.Forms.DataGridView();
            this.btnPrimerPagina = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnUltimaPagina = new System.Windows.Forms.Button();
            this.txtCantidadPasajes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtCabinasDisponibles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTramos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.lblMostrar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtViajes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCabinasDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Seleccione un viaje:";
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(12, 645);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 8;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.BtnAtras_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(907, 645);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // dtViajes
            // 
            this.dtViajes.AllowUserToAddRows = false;
            this.dtViajes.AllowUserToDeleteRows = false;
            this.dtViajes.AllowUserToResizeColumns = false;
            this.dtViajes.AllowUserToResizeRows = false;
            this.dtViajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtViajes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtViajes.Location = new System.Drawing.Point(12, 114);
            this.dtViajes.MultiSelect = false;
            this.dtViajes.Name = "dtViajes";
            this.dtViajes.ReadOnly = true;
            this.dtViajes.RowHeadersVisible = false;
            this.dtViajes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dtViajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtViajes.Size = new System.Drawing.Size(970, 240);
            this.dtViajes.TabIndex = 0;
            this.dtViajes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtViajes_CellClick);
            // 
            // btnPrimerPagina
            // 
            this.btnPrimerPagina.Location = new System.Drawing.Point(186, 360);
            this.btnPrimerPagina.Name = "btnPrimerPagina";
            this.btnPrimerPagina.Size = new System.Drawing.Size(116, 23);
            this.btnPrimerPagina.TabIndex = 1;
            this.btnPrimerPagina.Text = "Primer pagina";
            this.btnPrimerPagina.UseVisualStyleBackColor = true;
            this.btnPrimerPagina.Click += new System.EventHandler(this.BtnPrimerPagina_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(361, 360);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(116, 23);
            this.btnAnterior.TabIndex = 2;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.BtnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(522, 360);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(116, 23);
            this.btnSiguiente.TabIndex = 3;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            // 
            // btnUltimaPagina
            // 
            this.btnUltimaPagina.Location = new System.Drawing.Point(695, 360);
            this.btnUltimaPagina.Name = "btnUltimaPagina";
            this.btnUltimaPagina.Size = new System.Drawing.Size(116, 23);
            this.btnUltimaPagina.TabIndex = 4;
            this.btnUltimaPagina.Text = "Última página";
            this.btnUltimaPagina.UseVisualStyleBackColor = true;
            this.btnUltimaPagina.Click += new System.EventHandler(this.BtnUltimaPagina_Click);
            // 
            // txtCantidadPasajes
            // 
            this.txtCantidadPasajes.Location = new System.Drawing.Point(171, 572);
            this.txtCantidadPasajes.Name = "txtCantidadPasajes";
            this.txtCantidadPasajes.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadPasajes.TabIndex = 6;
            this.txtCantidadPasajes.TextChanged += new System.EventHandler(this.TxtCantidadPasajes_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 575);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Cantidad de pasajes a comprar";
            // 
            // dtCabinasDisponibles
            // 
            this.dtCabinasDisponibles.AllowUserToAddRows = false;
            this.dtCabinasDisponibles.AllowUserToDeleteRows = false;
            this.dtCabinasDisponibles.AllowUserToResizeColumns = false;
            this.dtCabinasDisponibles.AllowUserToResizeRows = false;
            this.dtCabinasDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtCabinasDisponibles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtCabinasDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCabinasDisponibles.Location = new System.Drawing.Point(15, 420);
            this.dtCabinasDisponibles.MultiSelect = false;
            this.dtCabinasDisponibles.Name = "dtCabinasDisponibles";
            this.dtCabinasDisponibles.ReadOnly = true;
            this.dtCabinasDisponibles.RowHeadersVisible = false;
            this.dtCabinasDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtCabinasDisponibles.Size = new System.Drawing.Size(287, 132);
            this.dtCabinasDisponibles.TabIndex = 5;
            this.dtCabinasDisponibles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtCabinasDisponibles_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Seleccione un tipo de cabina:";
            // 
            // dtTramos
            // 
            this.dtTramos.AllowUserToAddRows = false;
            this.dtTramos.AllowUserToDeleteRows = false;
            this.dtTramos.AllowUserToResizeColumns = false;
            this.dtTramos.AllowUserToResizeRows = false;
            this.dtTramos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtTramos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtTramos.Enabled = false;
            this.dtTramos.Location = new System.Drawing.Point(695, 420);
            this.dtTramos.MultiSelect = false;
            this.dtTramos.Name = "dtTramos";
            this.dtTramos.ReadOnly = true;
            this.dtTramos.RowHeadersVisible = false;
            this.dtTramos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtTramos.Size = new System.Drawing.Size(287, 132);
            this.dtTramos.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(692, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Tramos del viaje seleccionado";
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Location = new System.Drawing.Point(12, 613);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(66, 13);
            this.lblPrecioTotal.TabIndex = 25;
            this.lblPrecioTotal.Text = "Precio total: ";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.cmbFiltro.Location = new System.Drawing.Point(12, 60);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltro.TabIndex = 26;
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.CmbFiltro_SelectedIndexChanged);
            // 
            // lblMostrar
            // 
            this.lblMostrar.AutoSize = true;
            this.lblMostrar.Location = new System.Drawing.Point(12, 44);
            this.lblMostrar.Name = "lblMostrar";
            this.lblMostrar.Size = new System.Drawing.Size(201, 13);
            this.lblMostrar.TabIndex = 27;
            this.lblMostrar.Text = "Mostrar viajes donde el viaje destino sea ";
            // 
            // SeleccionarViaje
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 681);
            this.Controls.Add(this.lblMostrar);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtTramos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtCabinasDisponibles);
            this.Controls.Add(this.txtCantidadPasajes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnUltimaPagina);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnPrimerPagina);
            this.Controls.Add(this.dtViajes);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.label3);
            this.Name = "SeleccionarViaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar viaje";
            this.Load += new System.EventHandler(this.SeleccionarViaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtViajes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCabinasDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridView dtViajes;
        private System.Windows.Forms.Button btnPrimerPagina;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnUltimaPagina;
        private System.Windows.Forms.TextBox txtCantidadPasajes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dtCabinasDisponibles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtTramos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label lblMostrar;
    }
}