using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_3_HPA_P3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string Contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(Contraseña))
            {
                MessageBox.Show("Ingrese un usuario y contraseña Correctos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Conexion db = new Conexion();
            using (MySqlConnection conexion = db.ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    string qu = "select ContraUser from Usuarios where NomUser = @usuario";
                    using (MySqlCommand cmd = new MySqlCommand(qu, conexion))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            string hashGuardado = resultado.ToString();

                            bool esValido = BCrypt.Net.BCrypt.Verify(Contraseña, hashGuardado);

                            if (esValido)
                            {
                                Intento(conexion, usuario, "Exito");
                                MessageBox.Show($"¡Bienvenido, {usuario}!", "Acceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                Intento(conexion, usuario, "Algo salio mal");
                                MessageBox.Show("Contraseña incorrecta.", "Acceso negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtContraseña.Clear();
                                txtContraseña.Focus();
                            }
                        }
                        else
                        {
                            Intento(conexion, usuario, "Fallido");
                            MessageBox.Show("El usuario no existe en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtContraseña.Clear();
                            txtUsuario.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "Error ALTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Intento(MySqlConnection conx, string user, string estado)
        {
            string queryLog = "INSERT INTO Intentos (IntentUser, Estado, FechaHora) VALUES (@usuario, @estado, @fecha)";
            using (MySqlCommand cmdLog = new MySqlCommand(queryLog, conx))
            {
                cmdLog.Parameters.AddWithValue("@usuario", user);
                cmdLog.Parameters.AddWithValue("@estado", estado);
                cmdLog.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmdLog.ExecuteNonQuery();
            }
        }
    }
}