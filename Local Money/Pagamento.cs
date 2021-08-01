using Local_Money.modelos;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;
using System.IO;
using ESCPOS_NET.Utilities;

namespace Local_Money
{
    public partial class Pagamento : Form
    {

        public double Subtotal, Total, Impostos, Descontos, Entregue, Troco, Falta;
        public int mesa;
        PedidoNovo pn = (PedidoNovo)Application.OpenForms[2];
        frm_dashboard d = (frm_dashboard)Application.OpenForms[1];
        int altura;
        private string quantidades, produtos;
        Conexao con = new Conexao();

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 320;

            e.Graphics.DrawImage(Properties.Resources._004_chef, new Point(380, 10));
            e.Graphics.DrawString("FoodGest LDA.", new Font("Roboto", 20, FontStyle.Bold), Brushes.Black, new Point(320,90));
            e.Graphics.DrawString("NIF: 002869194OE033", new Font("Roboto", 12, FontStyle.Bold), Brushes.Black, new Point(335, 130));
            e.Graphics.DrawString("Rua Samuel Bernardo nº 18, 1º C", new Font("Roboto", 12, FontStyle.Bold), Brushes.Black, new Point(300, 150));

            e.Graphics.DrawString("_________________________________________________________________________________________________________________________________________________________________________________________", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(5, 155));

            e.Graphics.DrawString("Recibo nº: ", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(20, 180));
            e.Graphics.DrawString("Registado por:", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(20, 200));
            e.Graphics.DrawString("Cliente:", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(20, 220));
            e.Graphics.DrawString("Data: ", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(20, 240));

            e.Graphics.DrawString("00000", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(200, 180));
            e.Graphics.DrawString("Dara Carvalho", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(200, 200));
            e.Graphics.DrawString("", new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(200, 220));
            e.Graphics.DrawString(DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString(), new Font("Roboto", 10, FontStyle.Regular), Brushes.Black, new Point(200, 240));

            e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(5, 260));

            e.Graphics.DrawString("Produto", new Font("Roboto", 14, FontStyle.Bold), Brushes.Black, new Point(10, 280));
            e.Graphics.DrawString("Quantidade", new Font("Roboto", 14, FontStyle.Bold), Brushes.Black, new Point(280, 280));
            e.Graphics.DrawString("Preço un.", new Font("Roboto", 14, FontStyle.Bold), Brushes.Black, new Point(400, 280));
            e.Graphics.DrawString("Preço tot.", new Font("Roboto", 14, FontStyle.Bold), Brushes.Black, new Point(600, 280));

            
            
            
            foreach(string item in pn.nomes)
            {
                
                e.Graphics.DrawString(item, new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(10, y));
                y += 40;
            }

            y = 320;
            foreach (int item in pn.quantidades)
            {

                e.Graphics.DrawString(item.ToString(), new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(280, y));
                y += 40;

            }

            y = 320;
            foreach (double item in pn.subtotais)
            {

                e.Graphics.DrawString(item.ToString(), new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(400, y));
                y += 40;

            }

            y = 320;
            foreach (double item in pn.totais)
            {

                e.Graphics.DrawString(item.ToString(), new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(600, y));
                y += 40;

            }

            /*
            foreach (var c in from Control c in pn.p_lista_produtos.Controls
                              where c is Panel
                              select c)
            {
                foreach (var co in from Control co in c.Controls
                                   where co is Label
                                   select co)
                {
                    e.Graphics.DrawString(co.Text, new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(x, y));
                    x += 230;
                }

                y += 30;
            }
            */

            e.Graphics.DrawString("Subtotal", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(30, y + 200));
            e.Graphics.DrawString("Imposto Iva (14%)", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(30, y + 240));
            e.Graphics.DrawString("Descontos", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(30, y + 280));
            e.Graphics.DrawString("Total", new Font("Roboto", 16, FontStyle.Bold), Brushes.Black, new Point(30, y + 320));

            e.Graphics.DrawString(Subtotal + " Kz", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(300, y + 200));
            e.Graphics.DrawString(Impostos + " Kz", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(300, y + 240));
            e.Graphics.DrawString(Descontos + " Kz", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(300, y + 280));
            e.Graphics.DrawString(Total + " Kz", new Font("Roboto", 16, FontStyle.Bold), Brushes.Black, new Point(300, y + 320));

            e.Graphics.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", new Font("Roboto", 16, FontStyle.Regular), Brushes.Black, new Point(10, y + 335));

            e.Graphics.DrawString("Valor Entregue: ", new Font("Roboto", 16, FontStyle.Bold), Brushes.Black, new Point(30, y + 360));
            e.Graphics.DrawString("Troco:", new Font("Roboto", 16, FontStyle.Bold), Brushes.Black, new Point(30, y + 390));

            e.Graphics.DrawString(Entregue + " Kz", new Font("Roboto", 16, FontStyle.Bold), Brushes.Black, new Point(300, y + 360));
            e.Graphics.DrawString(Troco + " Kz", new Font("Roboto", 16, FontStyle.Bold), Brushes.Black, new Point(300, y + 390));

            e.Graphics.DrawString("__________________________________________________________________________________________________", new Font("Roboto", 16, FontStyle.Bold), Brushes.Black, new Point(10, y + 400));

            e.Graphics.DrawString("\r\r\r\r\rProcessado por FoodGest Lda.\n\rSoluções tecnológicas para o seu restaurante", new Font("Roboto", 14, FontStyle.Regular), Brushes.Black, new Point(200, y + 420));
            e.Graphics.DrawString("\r\r\r\r\rDesenvolvido por Danilo Carvalho\n\rdanzino10@gmail.com - (+244) 936530760\n\rRua Samuel Bernardo nº18 1ºc", new Font("Roboto", 12, FontStyle.Regular), Brushes.Black, new Point(200, y + 480));

            altura = y + 200;
        }

        private void Pagamento_Load(object sender, EventArgs e)
        {
            DecimalFormat df = new DecimalFormat("#.##");

            lbl_subtotal.Text = "Kz " + df.Format(Subtotal);
            lbl_total.Text = "Kz " + df.Format(Total);
            lbl_impostos.Text = "Kz " + df.Format((Subtotal * 14 / 100));
            lbl_descontos.Text = "Kz " + df.Format(Descontos);
            lbl_entregue.Text = "Kz " + df.Format(0);
            lbl_troco.Text = "Kz " + df.Format(0);
            lbl_falta.Text = "Kz " + df.Format(Total);
        }
        byte[] header, footer, fatura, corpo;
        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            int tel1 = 0, tel2 = 0, tel3 = 0, tel4 = 0, iva = 0;
            string nome = "", email = "", ende1 = "", ende2 = "", nif = "";
            con.abrir();
            SqlCommand comm = new SqlCommand
            {
                CommandText = "SELECT * FROM tb_restaurante",
                Connection = con.SaberConexao(),
            };
            SqlDataReader readerr = comm.ExecuteReader();
            while (readerr.Read())
            {
                nif = readerr.GetString(0);
                nome = readerr.GetString(1);
                email = readerr.GetString(2);
                ende1 = readerr.GetString(3);
                if (readerr.GetString(3) != "")
                    ende2 = readerr.GetString(4);
                if(readerr.GetInt32(5) != 0)
                    tel1 = readerr.GetInt32(5);
                if (readerr.GetInt32(6) != 0)
                    tel2 = readerr.GetInt32(6);
                if (readerr.GetInt32(7) != 0)
                    tel3 = readerr.GetInt32(7);
                if (readerr.GetInt32(8) != 0)
                    tel4 = readerr.GetInt32(8);
                iva = readerr.GetInt32(9);

            }
            readerr.Close();
            con.fechar();
            pn.AddNomes();
            pn.AddQuantidade();
            pn.AddSubtotal();
            pn.AddTotal();
            
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Fatura", 500, altura);
            printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
            //printDocument1.Print();


            // Ethernet or WiFi
            //var printer = new NetworkPrinter(ipAddress: "192.168.1.50", port: 9000, reconnectOnTimeout: true);

            // USB, Bluetooth, or Serial
            var printer = new SerialPrinter(portName: "COM6", baudRate: 115200);
            // Linux output to USB / Serial file
            //var printer = new FilePrinter(filePath: "/dev/usb/lp0");

            //byte[] m_Bytes = StreamHelper.ReadToEnd(mystream);
            
            var esc = new EPSON();
            header = ByteSplicer.Combine(
              
              esc.CenterAlign(),
              esc.PrintLine(nome),
              esc.PrintLine(ende1),
              esc.PrintLine(tel1.ToString()),
              esc.PrintLine(tel2.ToString()),
              esc.PrintLine(ende2),
              esc.PrintLine(tel3.ToString()),
              esc.PrintLine(tel4.ToString()),
              esc.PrintLine(""),
              esc.PrintLine("NIF: " + nif),
              esc.SetStyles(PrintStyle.Underline),
              esc.PrintLine("E-mail: " + email),
              esc.SetStyles(PrintStyle.None),
              esc.PrintLine(""),
              esc.PrintLine(""),
              esc.PrintLine("----------------------------------------------------------------"),
              esc.LeftAlign(),
              esc.PrintLine("Processado por: " + d.Nome),
              esc.PrintLine("Pedido: " + pn.numero_pedido),
              esc.PrintLine("Data: " + DateTime.Now.ToString()),
              esc.PrintLine(""),
              esc.SetStyles(PrintStyle.Underline),
              esc.PrintLine(" Qtd     P.Unitaro    Subtotal"),
              esc.PrintLine("   Descricao"),
              esc.SetStyles(PrintStyle.Bold)
              );
            fatura = header;

            string[] split;
            int[] qtd = new int[pn.p_lista_produtos.Controls.Count];
            string[] nomes = new string[pn.p_lista_produtos.Controls.Count];
            double[] val = new double[pn.p_lista_produtos.Controls.Count], tot = new double[pn.p_lista_produtos.Controls.Count];
            int i = 0;

            foreach (Control c in from Control c in pn.p_lista_produtos.Controls
                                      where c is Panel
                                      select c)
            {
                foreach (Control co in c.Controls)
                {
                    if(co is Label && co.Tag == "0")
                    {
                        qtd[i] = int.Parse(co.Text);
                        quantidades = quantidades + "," + qtd[i];
                    }
                    if (co is Label && co.Tag == "1")
                    {
                        split = co.Text.Split(' ');
                        val[i] = int.Parse(split[1]);
                    }
                    if (co is Label && co.Tag == "2")
                    {
                        split = co.Text.Split(' ');
                        tot[i] = int.Parse(split[1]);
                    }
                    if (co is Label && co.Tag == "3")
                    {
                        nomes[i] = co.Text;
                    }
                }
                i++;
            }

            i = 0;
            foreach(var item in qtd)
            {
                corpo = ByteSplicer.Combine(
                            esc.PrintLine("  " + qtd[i] + "       " + val[i] + "       " + tot[i]),
                            esc.PrintLine("     " + nomes[i]),
                            esc.PrintLine("")
                            );
                fatura = fatura.Concat(corpo).ToArray();
                i++;
            }
            
            

            footer = ByteSplicer.Combine(
                                esc.PrintLine("________________________________    "),
                                esc.LeftAlign(),
                                esc.PrintLine("SUBTOTAL:            " + Subtotal + " Kz"),
                                esc.PrintLine("IMPOSTO (IVA 14%):   " + Impostos + " Kz"),
                                esc.PrintLine("TOTAL:               " + Total + " Kz"),
                                esc.PrintLine(""),
                                esc.PrintLine("Valor Entregue:    " + Entregue + " Kz"),
                                esc.PrintLine("Troco:             " + Troco + " Kz"),
                                esc.CenterAlign(),
                                esc.SetStyles(PrintStyle.Bold | PrintStyle.FontB),
                                esc.PrintLine("CLIENTE:                   "),
                                esc.PrintLine("________________________________    "),
                                esc.PrintLine("     Obrigado e volte sempre "),
                                esc.PrintLine(""),
                                esc.PrintLine(""),
                                esc.PrintLine(""),
                                esc.PrintLine(""),
                                esc.PrintLine("")
                                );

            fatura = fatura.Concat(footer).ToArray();
            var fs = new MemoryStream(fatura);
            

            for(int j = 0; j<pn.produtos.Count; j++)
            {
                produtos = produtos + "," + pn.produtos.ElementAt(j);
            }

            con.abrir();

            try
            {
                string[] agora = DateTime.Now.ToString().Split(' ');
                
                SqlCommand com = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "INSERT INTO tb_pedido_concluido (produtos,quantidades,total_geral,data,hora) VALUES ('" + produtos + "','" + quantidades + "','" + Total + "','" + agora[0] + "','" + agora[1] + "')",
                };
                com.ExecuteNonQuery();

                SqlCommand com2 = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "DELETE FROM tb_pedido_currente WHERE id_mesa = '" + mesa + "'",
                };
                com2.ExecuteNonQuery();

                SqlCommand com3 = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "UPDATE tb_mesa SET estado = 'livre', id_pedido = 'NULL' WHERE id_mesa = '" + mesa + "'",
                };
                com3.ExecuteNonQuery();


                string[] mes = agora[0].Split('/');

                SqlCommand com4 = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "UPDATE tb_receita_ano SET clientes = clientes + 1, receita = receita + '" + Total + "' WHERE id_mes = '" + int.Parse(mes[1]) + "'",
                };
                com4.ExecuteNonQuery();

                SqlCommand com5 = new SqlCommand
                {
                    Connection = con.SaberConexao(),
                    CommandText = "UPDATE tb_dia SET clientes = clientes + 1, receita = receita + '" + Total + "'",
                };
                com5.ExecuteNonQuery();
            }
            catch(Exception er)
            {
                MessageBox.Show("Erro   " + er);
            }

            con.fechar();

            printer.Write(fatura);

            d.dinheiro += Total;
            d.lbl_dinheiro.Text = d.dinheiro + "";
            d.clientes++;
            d.lbl_clientes.Text = d.clientes + "";
            this.Close();
            pn.Close();
        }

        public Pagamento()
        {
            InitializeComponent();
             
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_dinheiro_Click(object sender, EventArgs e)
        {
            PagamentoDinheiro pd = new PagamentoDinheiro();
            pd.ShowDialog();
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
