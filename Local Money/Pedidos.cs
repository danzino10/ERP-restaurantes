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

namespace Local_Money
{
    public partial class Pedidos : Form
    {
        Conexao con = new Conexao();

        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            CarregarPedidos();
        }


        private void CarregarPedidos()
        {
            con.abrir();

            SqlCommand com = new SqlCommand
            {
                Connection = con.SaberConexao(),
                CommandText = "SELECT * FROM tb_mesa",
            };

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                Button btn_mesa = new Button
                {
                    Width = 150,
                    Height = 75,
                };
                int mesa = reader.GetInt32(0);
                if (reader.GetString(1) == "livre")
                {
                    flp_view.Controls.Add(btn_mesa);
                    btn_mesa.Text = "Mesa - " + mesa;
                    btn_mesa.BackColor = Color.Green;
                    btn_mesa.Tag = mesa;
                    btn_mesa.Click += (s, e) =>
                    {
                        Home home = (Home)Application.OpenForms[1];
                        home.lbl_mesa.Text = "Pedido da Mesa " + mesa;
                        home.lbl_mesa.Tag = 1;
                        home.p_view.Controls.Clear();
                        //home.BotaoMenu();
                    };
                } 
                else
                {
                    flp_view.Controls.Add(btn_mesa);
                    btn_mesa.Text = "Mesa - " + reader.GetInt32(0);
                    btn_mesa.BackColor = Color.Brown;
                    btn_mesa.Enabled = false;
                }

            }

            flp_view.Controls.Add(new Button { 
                Text = "Take Away", 
                Width = 150, 
                Height = 75, 
                BackColor = Color.Teal
            });

            con.fechar();
        }

        private void btn_mesas_Click(object sender, EventArgs e)
        {

        }

        private void flp_view_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
