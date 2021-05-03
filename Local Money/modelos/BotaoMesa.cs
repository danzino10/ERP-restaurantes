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
        

        public BotaoMesa (int mesa)
        {
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

            PainelBotao.Click += BotaoMesa_Click;
            
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

        private void Ocupado()
        {
            PainelBotao.Enabled = false;
            PainelBaixo.BackColor = Color.Brown;
            PainelCima.BackColor = Color.Brown;
            PainelDireita.BackColor = Color.Brown;
            PainelEsquerda.BackColor = Color.Brown;
            UmDigito.ForeColor = Color.Brown;
            DoisDigitos.ForeColor = Color.Brown;
        }

        private void Selecionado()
        {
            PainelBotao.Enabled = false;
            PainelBaixo.BackColor = SystemColors.MenuHighlight;
            PainelCima.BackColor = SystemColors.MenuHighlight;
            PainelDireita.BackColor = SystemColors.MenuHighlight;
            PainelEsquerda.BackColor = SystemColors.MenuHighlight;
            UmDigito.ForeColor = SystemColors.MenuHighlight;
            DoisDigitos.ForeColor = SystemColors.MenuHighlight;
        }

        private void Desselecionado()
        {
            PainelBotao.Enabled = true;
            PainelBaixo.BackColor = Color.DarkSlateGray;
            PainelCima.BackColor = Color.DarkSlateGray;
            PainelDireita.BackColor = Color.DarkSlateGray;
            PainelEsquerda.BackColor = Color.DarkSlateGray;
            UmDigito.ForeColor = Color.DarkSlateGray;
            DoisDigitos.ForeColor = Color.DarkSlateGray;
        }

        private void BotaoMesa_Click(Object sender, EventArgs e)
        {
            Selecionado();
        }
    }
}
