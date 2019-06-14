﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexiones;

namespace FrbaCrucero.AbmCrucero
{
    public partial class ModificarCrucero : Form
    {
        private Conexion conexion = new Conexion();
        private ListaDeCruceros padre;
        private string ID;
        private string modelo;
        private string fabricante;
        private string identificador;
        public ModificarCrucero(string ID_, string modelo_, string fabricante_, string identificador_, ListaDeCruceros padre_)
        {
            ID = ID_;
            padre = padre_;
            modelo = modelo_;
            fabricante = fabricante_;
            identificador = identificador_;
            InitializeComponent();
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> cambios = new Dictionary<string, object>();

            if (this.camposVacios())
            {
                MessageBox.Show("Se han encontrado campos vacios. Por favor completelos e intentelo nuevamente", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.identRepetido())
            {

                MessageBox.Show("Ya existe un crucero con ese identificador", "Identificador existente", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else 
            {

                cambios.Add("modelo", textBoxModelo.Text.Trim());
                cambios.Add("fabricante", textBoxFabricante.Text.Trim());
                cambios.Add("identificador", textBoxIdentificador.Text.Trim());
                conexion.Modificar(int.Parse(ID), Tabla.Crucero, cambios);
                padre.reLoad();
                this.Close();

            }

        }

        private void ModificarCrucero_Load(object sender, EventArgs e)
        {
            textBoxModelo.Text = modelo;
            textBoxFabricante.Text = fabricante;
            textBoxIdentificador.Text = identificador;
        }

        private bool camposVacios()
        {
            return (this.stringVacio(textBoxModelo.Text) || this.stringVacio(textBoxFabricante.Text) || this.stringVacio(textBoxIdentificador.Text)) ;
        }

        private bool stringVacio(string str)
        {
            return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
        }

        private bool identRepetido() {
            Dictionary<string, List<object>> rdos = conexion.ConsultaPlana(Tabla.Crucero, new List<string> { "identificador" }, new List<Filtro> { FiltroFactory.Exacto("identificador", textBoxIdentificador.Text) });
            return rdos["identificador"].Count > 0;
        }

    }
}
