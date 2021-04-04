using System;
using System.Windows.Forms;
using System.Data.SqlClient;
/// <summary>
/// Lenguaje de programacion III
/// Autor: Rene Gonzalez Rodriguez
/// Maestro: Aarón I. Salazar
/// </summary>
namespace Actividad_Integradora_6_Problema_3
{
    public partial class FrmArticulos : Form
    {
        SqlConnection conexion;
        string query = string.Empty;
        public FrmArticulos()
        {
            InitializeComponent();
            conexion = new SqlConnection("server=RENEGONZALEZ\\SQLEXPRESS ; database=MaestroArticulos ; integrated security = true");
            conexion.Open();
            lblId.Text = string.Empty;
            lblNombre.Text = string.Empty;
            lblPrecio.Text = string.Empty;
            lblStock.Text = string.Empty;
            lblFamilia.Text = string.Empty;
            lblGarantia.Text = string.Empty;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            query = string.Format("INSERT INTO articulos VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                    txtId.Text, txtNombre.Text, txtPrecio.Text, txtStock.Text, txtFamilia.Text, txtGarantia.Text);
            try
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insertado con Exito!!", "Mensaje");
            }
            catch (SqlException ex)
            {
                string dato = string.Format("Error al realizar la insercion: {0}", ex.Message);
                MessageBox.Show(dato, "Error");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            query = string.Format("UPDATE articulos SET nombre = '{1}',precio = '{2}', stock = '{3}', " +
                "familia ='{4}', garantia = '{5}' WHERE id = {0}",
                    txtId.Text, txtNombre.Text, txtPrecio.Text, txtStock.Text, txtFamilia.Text, txtGarantia.Text);
            try
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado con Exito!!", "Mensaje");
            }
            catch (SqlException ex)
            {
                string dato = string.Format("Error al realizar la Actualizacion: {0}", ex.Message);
                MessageBox.Show(dato, "Error");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtFamilia.Text = string.Empty;
            txtGarantia.Text = string.Empty;
            lblId.Text = string.Empty;
            lblNombre.Text = string.Empty;
            lblPrecio.Text = string.Empty;
            lblStock.Text = string.Empty;
            lblFamilia.Text = string.Empty;
            lblGarantia.Text = string.Empty;
            txtId.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            query = string.Format("DELETE FROM articulos WHERE id = {0}",
                   txtId.Text);
            try
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Borrado con Exito!!", "Mensaje");
            }
            catch (SqlException ex)
            {
                string dato = string.Format("Error al realizar la Eliminacion: {0}", ex.Message);
                MessageBox.Show(dato, "Error");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            query = string.Format("select id, nombre, precio, stock, familia, garantia from articulos where id = {0};", 
                txtIdBuscar.Text);
            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblId.Text = dr["id"].ToString();
                lblNombre.Text = dr["nombre"].ToString();
                lblPrecio.Text = dr["precio"].ToString();
                lblStock.Text = dr["stock"].ToString();
                lblFamilia.Text = dr["familia"].ToString();
                lblGarantia.Text = dr["garantia"].ToString();
            }
            dr.Close();
        }
    }
}
