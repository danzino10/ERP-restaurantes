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

namespace Local_Money
{
    public partial class PagamentoDinheiro : Form
    {
        public PagamentoDinheiro()
        {
            InitializeComponent();
        }

        private void txt_montante_KeyPress(object sender, KeyPressEventArgs e)
        {
            foreach(char letra in txt_montante.Text)
            {
                if(letra is ',' || letra is '.')
                {
                    txt_montante.Text = txt_montante.Text - ",";
                }
            }
        }

        
    }
}
