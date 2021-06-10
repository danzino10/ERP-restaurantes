using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Local_Money.modelos
{
    class BotaoMesa
    {
        
        

        private int Mesa;

        public BotaoMesa (int mesa)
        {
            Mesa = mesa;
            PainelBotao.Controls.Add(PainelCima);
            PainelBotao.Controls.Add(PainelBaixo);
            PainelBotao.Controls.Add(PainelDireita);
            PainelBotao.Controls.Add(PainelEsquerda);
            
            if(mesa > 9)
            {
                DoisDigitos.Text = mesa.ToString();
                PainelBotao.Controls.Add(DoisDigitos);
            }
            else
            {
                UmDigito.Text = mesa.ToString();
                PainelBotao.Controls.Add(UmDigito);
            }

            PainelBotao.Click += (sender2, e2) => BotaoMesa_Click(sender2, e2);

        }



        Panel PainelBotao = new Panel
        {
            Width = 70,
            Height = 70,
            Cursor = Cursors.Hand,
        };

        Panel PainelCima = new Panel
        {
            Height = 5,
            Dock = DockStyle.Top,
            BackColor = Color.DarkSlateGray,
        };

        Panel PainelBaixo = new Panel
        {
            Height = 5,
            Dock = DockStyle.Bottom,
            BackColor = Color.DarkSlateGray,
        };

        Panel PainelEsquerda = new Panel
        {
            Width = 5,
            Dock = DockStyle.Left,
            BackColor = Color.DarkSlateGray,
        };

        Panel PainelDireita = new Panel
        {
            Width = 5,
            Dock = DockStyle.Right,
            BackColor = Color.DarkSlateGray,
        };

        Label UmDigito = new Label
        {
            Location = new Point(18, 14),
            Font = new Font("Roboto", 26.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            ForeColor = Color.DarkSlateGray,
        };

        Label DoisDigitos = new Label
        {
            Location = new Point(8, 14),
            Font = new Font("Roboto", 26.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
            ForeColor = Color.DarkSlateGray,
        };

        public void Ocupado()
        {
            PainelBotao.Enabled = false;
            PainelBaixo.BackColor = Color.Brown;
            PainelCima.BackColor = Color.Brown;
            PainelDireita.BackColor = Color.Brown;
            PainelEsquerda.BackColor = Color.Brown;
            UmDigito.ForeColor = Color.Brown;
            DoisDigitos.ForeColor = Color.Brown;
        }

        public void Selecionado()
        {
            PainelBotao.Enabled = false;
            PainelBaixo.BackColor = SystemColors.MenuHighlight;
            PainelCima.BackColor = SystemColors.MenuHighlight;
            PainelDireita.BackColor = SystemColors.MenuHighlight;
            PainelEsquerda.BackColor = SystemColors.MenuHighlight;
            UmDigito.ForeColor = SystemColors.MenuHighlight;
            DoisDigitos.ForeColor = SystemColors.MenuHighlight;
            
           
        }

        public void Desselecionar()
        {
            PainelBotao.Enabled = true;
            PainelBaixo.BackColor = Color.DarkSlateGray;
            PainelCima.BackColor = Color.DarkSlateGray;
            PainelDireita.BackColor = Color.DarkSlateGray;
            PainelEsquerda.BackColor = Color.DarkSlateGray;
            UmDigito.ForeColor = Color.DarkSlateGray;
            DoisDigitos.ForeColor = Color.DarkSlateGray;
        }

        public Panel Criar()
        {
            return PainelBotao;
        }

       


        private void BotaoMesa_Click(Object sender, EventArgs e)
        {
            
            

            Selecionado();
            if (Application.OpenForms.Count > 3)
            {
                GuardarPedido gp = (GuardarPedido)Application.OpenForms[3];

                if (Application.OpenForms[3] == gp)
                {
                    gp.Selec++;
                    gp.Mesa = Mesa;
                    
                }
            }
            else
            {
                PedidoAlterar pa = (PedidoAlterar)Application.OpenForms[2];

                if (Application.OpenForms[2] == pa)
                {
                    pa.Selec++;
                    pa.Mesa = Mesa;
                    pa.txt_pesquisar.Text = Mesa.ToString();
                    
                    foreach(Control bm in pa.flp_mesas.Controls)
                    {
                        if(bm is Panel)
                        {
                            
                        }
                    }
                }
            }
            
            
        }
    }
}
