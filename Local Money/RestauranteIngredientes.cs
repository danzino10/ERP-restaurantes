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
using Local_Money.objectos;

namespace Local_Money
{
    public partial class RestauranteIngredientes : Form
    {

        Conexao con = new Conexao();

        public RestauranteIngredientes()
        {
            InitializeComponent();
        }

        private void RestauranteIngredientes_Load(object sender, EventArgs e)
        {
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_ingrediente ORDER BY nome ASC",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                IngredienteListado il = new IngredienteListado(reader.GetInt32(0), reader.GetString(1), reader.GetString(6), reader.GetString(2), double.Parse(reader.GetValue(4).ToString()));
                flp_ingrediente_listado.Controls.Add(il.Criar());
            }
            con.fechar();
        }

        private void txt_pesquisar_TextChanged(object sender, EventArgs e)
        {
            con.abrir();

            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_ingrediente WHERE nome LIKE '" + txt_pesquisar.Text + "%'",
                };
                SqlDataReader reader = com.ExecuteReader();

                flp_ingrediente_listado.Controls.Clear();
                while (reader.Read())
                {
                    IngredienteListado il = new IngredienteListado(reader.GetInt32(0), reader.GetString(1), reader.GetString(6), reader.GetString(2), double.Parse(reader.GetValue(4).ToString()));
                    flp_ingrediente_listado.Controls.Add(il.Criar());
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro!!!!! " + er);
            }

            con.fechar();
        }

        private void txt_pesquisar_Click(object sender, EventArgs e)
        {
            txt_pesquisar.Text = "";
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            frm_dashboard d = (frm_dashboard)Application.OpenForms[1];
            d.AbrirJanela(new FormularioIngrediente());
        }
    }
}
