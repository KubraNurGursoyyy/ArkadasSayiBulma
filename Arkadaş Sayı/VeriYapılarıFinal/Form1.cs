using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriYapılarıFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        LinkedList linkedList = new LinkedList();
        private void btnListOlustur_Click(object sender, EventArgs e)
        {
            linkedList.InsertLast(Convert.ToInt32(txtSayi1.Text));
            linkedList.InsertLast(Convert.ToInt32(txtSayi2.Text));
            linkedList.InsertLast(Convert.ToInt32(txtSayi3.Text));
            linkedList.InsertLast(Convert.ToInt32(txtSayi4.Text));
            linkedList.InsertLast(Convert.ToInt32(txtSayi5.Text));
            MessageBox.Show("Liste Oluşturuldu!");
        }

        private void btnArkadasSB_Click(object sender, EventArgs e)
        {
            linkedList.ArkadasSayilarBulDeğistir(linkedList);
        }
    }
}
