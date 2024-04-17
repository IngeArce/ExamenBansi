using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenBansiErick
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
      
        SqlConnection conn =  new SqlConnection("Data Source=DESKTOP-1GBNJ6E;Initial Catalog=Prueba1;Persist Security Info=True;User ID=sa;Password=#AdminArce;Encrypt=False;TrustServerCertificate=True");
       
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int idExamen = int.Parse(txtIdExamen.Text);
            string name = txtName.Text;
            string description = txtDescription.Text;
            conn.Open();
            SqlCommand c = new SqlCommand("exec spAgregar @IdExamen, @Name, @Description", conn);
            c.Parameters.AddWithValue("@IdExamen", idExamen);
            c.Parameters.AddWithValue("@Name", name);
            c.Parameters.AddWithValue("@Description", description); c.ExecuteNonQuery();
            MessageBox.Show("Se ha insertado correctamente......");
            conn.Close(); // Cerrar la conexión
            GetListExamen();

        }

        void GetListExamen()
        {
            SqlCommand c = new SqlCommand("exec spConsultar", conn);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int idExamen = int.Parse(txtIdExamen.Text);
            string name = txtName.Text;
            string description = txtDescription.Text;
            conn.Open();
            SqlCommand c = new SqlCommand("exec spActualizar @IdExamen, @Name, @Description", conn);
            c.Parameters.AddWithValue("@IdExamen", idExamen);
            c.Parameters.AddWithValue("@Name", name);
            c.Parameters.AddWithValue("@Description", description);
            c.ExecuteNonQuery();
            MessageBox.Show("Se ha actualizado correctamente......");
            conn.Close(); // Cerrar la conexión
            GetListExamen();
        }
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            GetListExamen();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro que deseas eliminar este examen?", "Eliminar Examen", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int idExamen;
                if (int.TryParse(txtIdExamen.Text, out idExamen))
                {
                    conn.Open();
                    SqlCommand c = new SqlCommand("exec spEliminar @IdExamen", conn);
                    c.Parameters.AddWithValue("@IdExamen", idExamen);
                    c.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Examen eliminado exitosamente.");
                    GetListExamen();
                }
                else
                {
                    MessageBox.Show("El ID del examen no es válido.");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
