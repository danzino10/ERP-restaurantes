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
        PedidoNovo pn = (PedidoNovo)Application.OpenForms[2];
        int altura;
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

        private void btn_confirmar_Click(object sender, EventArgs e)
        {

            pn.AddNomes();
            pn.AddQuantidade();
            pn.AddSubtotal();
            pn.AddTotal();
            
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Fatura", 500, altura);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            printDocument1.Print();


            // Ethernet or WiFi
            //var printer = new NetworkPrinter(ipAddress: "192.168.1.50", port: 9000, reconnectOnTimeout: true);

            // USB, Bluetooth, or Serial
            var printer = new SerialPrinter(portName: "COM5", baudRate: 115200);
            // Linux output to USB / Serial file
            //var printer = new FilePrinter(filePath: "/dev/usb/lp0");

            //byte[] m_Bytes = StreamHelper.ReadToEnd(mystream);
            var esc = new EPSON();
            printer.Write(
              ByteSplicer.Combine(
                esc.CenterAlign(),
                esc.PrintImage(ImageToByteArray(Properties.Resources._004_chef), true),
                esc.PrintLine(""),
                esc.SetBarcodeHeightInDots(360),
                esc.SetBarWidth(BarWidth.Default),
                esc.SetBarLabelPosition(BarLabelPrintPosition.None),
                esc.PrintBarcode(BarcodeType.ITF, "0123456789"),
                esc.PrintLine(""),
                esc.PrintLine("FOODGEST, REESTAURANTE & BAR"),
                esc.PrintLine("RUA SAMUEL BERNARDO N18,  1-C"),
                esc.PrintLine("(244) 936530760"),
                esc.PrintLine(""),
                esc.PrintLine("BAIRRO DAS INGOMBOTAS, LUANDA"),
                esc.PrintLine("CONTRIBUINTE Nº "),
                esc.PrintLine(""),
                esc.SetStyles(PrintStyle.Underline),
                esc.PrintLine("www.bhphotovideo.com"),
                esc.SetStyles(PrintStyle.None),
                esc.PrintLine(""),
                esc.PrintLine("----------------------------------------------------------------"),
                esc.LeftAlign(),
                esc.PrintLine("Pedido: 123456789        Data:" + DateTime.Now.ToString()),
                esc.PrintLine(""),
                esc.PrintLine(""),
                esc.SetStyles(PrintStyle.Bold)
              )
            );

            foreach (var c in from Control c in pn.p_lista_produtos.Controls
                              where c is Panel
                              select c)
            {
                foreach (Control co in c.Controls)
                {
                    int qtd = 0;
                    double val = 0, tot = 0;
                    string nome = "";

                    if (co is Label)
                    {

                        if (co.Tag == "0")
                            qtd = int.Parse(co.Text);
                        if (co.Tag == "1")
                            val = int.Parse(co.Text);
                        if (co.Tag == "2")
                            tot = int.Parse(co.Text);
                        if (co.Tag == "3")
                            nome = co.Text;
                        printer.Write(
                            ByteSplicer.Combine(
                                esc.PrintLine("" + qtd + "       " + val + "      " + tot),
                                esc.PrintLine("     " + nome),
                                esc.PrintLine("")
                                )
                            );
                    }
                }
            }

            printer.Write(
                ByteSplicer.Combine(
                    esc.RightAlign(),
                    esc.PrintLine("SUBTOTAL         " + Subtotal + " Kz"),
                    esc.PrintLine("IMPOSTO (IVA 14%)         " + Impostos + " Kz"),
                    esc.PrintLine("TOTAL:         " + Total + " Kz"),
                    esc.PrintLine(""),
                    esc.PrintLine("Valor Entregue:         " + Entregue + " Kz"),
                    esc.PrintLine("Troco:        " + Troco + " Kz"),
                    esc.LeftAlign(),
                    esc.SetStyles(PrintStyle.Bold | PrintStyle.FontB),
                    esc.PrintLine("CLIENTE:                   "),
                    esc.PrintLine(" ________________________________    "),
                    esc.PrintLine("         Obrigado e volte sempre ")
                )
            );

            
            
            


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
