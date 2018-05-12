using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LogicaDeNegocio;

namespace colegio
{
    public partial class chkEliminar : Form
    {
        public chkEliminar()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(Txtusuario,"Usuario");
            ttMensaje.SetToolTip(Txtpassword,"Contraseña");           
        }

        LPersona p = new LPersona();
        private void Btlogin_Click(object sender, EventArgs e)
        {
            if (Txtusuario.Text == string.Empty || Txtpassword.Text == string.Empty)
            {
                MessageBox.Show("!Faltan algunos datos, estos seran remarcados¡", "Sistema Academico Gestion De Notas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorIcono.SetError(Txtusuario, "Por Favor Ingrese Usuario");
                errorIcono.SetError(Txtpassword, "Por Favor Ingrese Contraseña");
            }
            else {
                if (p.Login(Txtusuario.Text, Txtpassword.Text).Equals("Administrador"))
                {
                    MessageBox.Show("Bienvenido", "Sistema Academico Gestion De Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmAdmin admin = new FrmAdmin();
                    admin.Show();
                    this.Hide();
                }
                else if (p.Login(Txtusuario.Text, Txtpassword.Text).Equals("Estudiante"))
                {
                    MessageBox.Show("Bienvenido", "Sistema Academico Gestion De Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmEstudiante estudiante = new FrmEstudiante();
                    estudiante.Show();
                    this.Hide();
                }
                else if (p.Login(Txtusuario.Text, Txtpassword.Text).Equals("Docente"))
                {
                    MessageBox.Show("Bienvenido", "Sistema Academico Gestion De Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDocente docente = new FrmDocente();
                    docente.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Datos Erroneo, Verifique..!", "Sistema Academico Gestion Notas", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult op;
            op = MessageBox.Show("¿Realmente Desea Cancelar La Operacion?", "Sistema Academico Gestion de Notas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (op == DialogResult.OK) {
                this.Close();
            }
        }
    }

}

