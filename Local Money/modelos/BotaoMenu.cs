using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Local_Money
{
    class BotaoMenu
    {
        Button btn = new Button
        {
            Width = 105,
            Height = 68,

        };
        Conexao con = new Conexao();
        public BotaoMenu(int i, string nome, FlowLayoutPanel flp_cardapio)
        {
            string[] nn = nome.Split('-');
            btn.Text = nome;
            btn.MouseClick += (s, e) => {
                
                con.abrir();
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "SELECT * FROM tb_produto WHERE id_categoria = @categoria",
                };
                SqlParameter categoria = new SqlParameter("@categoria", SqlDbType.Int);
                categoria.Value = int.Parse(nn[0]);
                com.Parameters.Add(categoria);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string nomeProduto = reader.GetString(3);
                    int id = reader.GetInt32(0);
                    byte[] foto = (byte[])(reader[5]);
                    Image imagem;
                    if (foto == null)
                    {
                        imagem = null;
                    }
                    else
                    {
                        MemoryStream memory = new MemoryStream(foto);
                        imagem = Image.FromStream(memory);
                    }
                    Home home = (Home)Application.OpenForms[1];
                    CartaoProduto cartPro = new CartaoProduto(nomeProduto, id, imagem, home.lbl_mesa, home.lbl_total, home.lbl_subtot, home.tlp_pedido);
                    flp_cardapio.Controls.Add(cartPro.CriarCartao());
                }
                reader.Close();
                con.fechar();
            };
        }
        
        public Button CriarBotao ()
        {
            return btn;
        }
        

       
    }
}
