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
using Local_Money.modelos;

namespace Local_Money
{
    public partial class GuardarPedido : Form
    {
        private Conexao con = new Conexao();
        public int Selec=0;
        public int Mesa;
        private PedidoNovo pn = (PedidoNovo)Application.OpenForms[2];

        public GuardarPedido()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if(flp_mesas.Controls.Count == 0)
                {
                    con.abrir();

                    lbl_confirmar.Text = "Indique a mesa correspondente ao pedido";
                    SqlCommand com = new SqlCommand
                    {
                        CommandText = "SELECT * FROM tb_mesa",
                        Connection = con.SaberConexao(),
                    };

                    SqlDataReader reader2 = com.ExecuteReader();
                    while (reader2.Read())
                    {
                        
                        BotaoMesa btn_mesa = new BotaoMesa(reader2.GetInt32(0));
                        if (reader2.GetString(1) == "ocupado")
                            btn_mesa.OcupadoNovo();
                        flp_mesas.Controls.Add(btn_mesa.Criar());
                        
                    }
                    con.fechar();

                }  
                else
                {
                    if (Selec > 1)
                    MessageBox.Show("Só é possível selecionar uma das mesas! \nPorfavor, cancele e volte a guardar o pedido");
                    else if(Selec == 1)
                    {
                        pn.AddNomes();
                        pn.AddQuantidade();
                        pn.AddSubtotal();
                        pn.AddTotal();

                        con.abrir();
                        SqlCommand com = new SqlCommand
                        {
                            CommandText = "UPDATE tb_mesa SET estado = 'ocupado', id_pedido = '" + Selec.ToString() + "' WHERE id_mesa = '" + Mesa + "'",
                            Connection = con.SaberConexao(),
                        };
                        com.ExecuteNonQuery();

                        SqlCommand com3 = new SqlCommand
                        {
                            CommandText = "DELETE FROM tb_pedido_currente WHERE id_mesa = '" + Mesa + "'",
                            Connection = con.SaberConexao(),
                        };
                        com3.ExecuteNonQuery();

                        int i= 0; 
                        foreach(Control pl in pn.p_lista_produtos.Controls)
                        {
                            SqlCommand com2 = new SqlCommand
                            {
                                CommandText = "INSERT INTO tb_pedido_currente (id_mesa,id_produto,estado,quantidade,id_pedido,nome) VALUES ('" + Mesa + "', '" + pn.produtos[i] + "', 'Em preparo', '" + pn.quantidades[i] + "', '" + Selec.ToString() + "','" + pn.nomes[i] + "')",
                                Connection = con.SaberConexao(),
                            };
                            com2.ExecuteNonQuery();
                            i++;
                        }
                        con.fechar();
                        MessageBox.Show("Pedido Salvo com sucesso! \n\nEm preparação");
                        pn.Close();
                        this.Close();
                    }
                }
            }
            catch(Exception er)
            {
                MessageBox.Show("ERRRROOOOO!!!! " + er);
            }
            
        }

        private void GuardarPedido_Load(object sender, EventArgs e)
        {

        }
    }
}
