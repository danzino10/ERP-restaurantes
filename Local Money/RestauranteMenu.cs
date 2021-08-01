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
    public partial class RestauranteMenu : Form
    {
        Conexao con = new Conexao();
        public RestauranteMenu()
        {
            InitializeComponent();
        }

        private void flp_produto_listado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RestauranteMenu_Load(object sender, EventArgs e)
        {
            con.abrir();
            SqlCommand com = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_produto ORDER BY nome ASC",
                Connection = con.SaberConexao(),
            };
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                
                ProdutoListadoThird il = new ProdutoListadoThird(reader.GetInt32(0), reader.GetString(3), Categoria(reader.GetInt32(2)), double.Parse(reader.GetValue(4).ToString()), reader.GetString(7));
                flp_produto_listado.Controls.Add(il.Criar());
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
                    CommandText = "SELECT * FROM tb_produto WHERE nome LIKE '" + txt_pesquisar.Text + "%' ORDER BY nome ASC",
                };
                SqlDataReader reader = com.ExecuteReader();

                flp_produto_listado.Controls.Clear();
                while (reader.Read())
                {
                    ProdutoListadoThird il = new ProdutoListadoThird(reader.GetInt32(0), reader.GetString(3), Categoria(reader.GetInt32(2)), double.Parse(reader.GetValue(4).ToString()), reader.GetString(7));
                    flp_produto_listado.Controls.Add(il.Criar());
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro!!!!! " + er);
            }

            con.fechar();
        }

        private String Categoria(int cat)
        {
            string categoria = "Outra";
            switch (cat)
            {
                case 1:
                    categoria = "Água";
                    break;
                case 2:
                    categoria = "Cafetaria";
                    break;
                case 3:
                    categoria = "Cervejas";
                    break;
                case 5:
                    categoria = "Espirituosas";
                    break;
                case 6:
                    categoria = "Refrigerantes";
                    break;
                case 7:
                    categoria = "Sumos";
                    break;
                case 8:
                    categoria = "Bolos";
                    break;
                case 9:
                    categoria = "Doces";
                    break;
                case 10:
                    categoria = "Salgados";
                    break;
                case 11:
                    categoria = "Sandes";
                    break;
                case 12:
                    categoria = "Carne";
                    break;
                case 13:
                    categoria = "Marisco";
                    break;
                case 14:
                    categoria = "Massas";
                    break;
                case 16:
                    categoria = "Peixe";
                    break;
                case 17:
                    categoria = "Pizza";
                    break;
                case 18:
                    categoria = "Vegetariana";
                    break;
            }
            return categoria;
        }

        private void txt_pesquisar_Click(object sender, EventArgs e)
        {
            txt_pesquisar.Text = "";
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            frm_dashboard d = (frm_dashboard)Application.OpenForms[1];
            d.AbrirJanela(new FormularioMenu());
        }
    }
}
