using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Local_Money.modelos
{
    class Pedidos
    {
        private int IdProduto, Mesa, Quantidade, IdPedido;
        private Conexao con = new Conexao();

        public Pedidos(int idProduto, int mesa, int quantidade, int idPedido)
        {
            IdProduto = idProduto;
            Mesa = mesa;
            Quantidade = quantidade;
            IdPedido = idPedido;
        }

        
        public void Guardar()
        {
            con.abrir();

            try
            {
                SqlCommand com = new SqlCommand
                {
                    CommandText = "INSERT INTO tb_mesa (id_mesa,estado,id_pedido,quantidade,id_produto) VALUES (" + Mesa + " , Em preparo , " + IdPedido + " , " + Quantidade + " , " + IdProduto + ")",
                    Connection = con.SaberConexao(),
                };
                com.ExecuteNonQuery();
            }
            catch(Exception er)
            {
                MessageBox.Show("ERROOOO!!!! " + er);
            }
            con.fechar();
        }

        public void Apagar(int mesa)
        {
            con.abrir();

            try
            {
                SqlCommand com = new SqlCommand
                {
                    CommandText = "DELETE FROM tb_mesa WHERE id_mesa = " + mesa + "",
                    Connection = con.SaberConexao(),
                };
                com.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROOOO!!!! " + er);
            }
            con.fechar();
        }

        public void BuscarTodos()
        {
            con.abrir();

            try
            {
                SqlCommand com = new SqlCommand
                {
                    CommandText = "SELECT * FROM tb_mesa ORDER BY id_mesa",
                    Connection = con.SaberConexao(),
                };
                
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROOOO!!!! " + er);
            }
            con.fechar();
        }

        public void BuscarPorMesa(int mesa)
        {
            con.abrir();

            try
            {
                SqlCommand com = new SqlCommand
                {
                    CommandText = "SELECT * FROM tb_mesa WHERE id_mesa = " + mesa + "",
                    Connection = con.SaberConexao(),
                };
                com.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                MessageBox.Show("ERROOOO!!!! " + er);
            }
            con.fechar();
        }

        
    }
}
