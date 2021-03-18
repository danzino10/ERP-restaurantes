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
        Button btn;
        Conexao con = new Conexao();
        public BotaoMenu(int i, string nome, FlowLayoutPanel flp_view)
        {
            string[] nn = nome.Split('-');
            Button btn = new Button
            {
                Width = 105,
                Height = 68,
                Text = nome,

            };
            btn.MouseClick += (s, e) => {
                flp_view.Controls.Clear();
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
                    //flp_view.Controls.Add(CartaoProduto(reader.GetInt32(0).ToString() + " - " + reader.GetString(3), reader.GetInt32(0), imagem));
                }
                reader.Close();
                con.fechar();
            };
        }

        

       
    }
}
