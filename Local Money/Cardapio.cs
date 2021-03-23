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
    public partial class Cardapio : Form
    {
        public int catNum;
        Conexao con = new Conexao();
        public Cardapio()
        {
            InitializeComponent();
        }

        private void Cardapio_Load(object sender, EventArgs e)
        {
            con.abrir();
            try
            {
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_categoria WHERE id_menu = '" + catNum + "'",
                };
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    string nome = reader.GetInt32(0) + " - " + reader.GetString(1);
                    int id = reader.GetInt32(0);
                    BotaoMenu btnMenu = new BotaoMenu(id, nome, flp_cardapio);
                    flp_cardapio.Controls.Add(btnMenu.CriarBotao());
                }
                reader.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Erro! " + er);
            }
            con.fechar();
        }

        
    }
}
