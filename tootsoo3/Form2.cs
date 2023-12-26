using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tootsoo3
{
    public partial class Form2 : Form
    {
     
        public string ao3 { get; set; }
        public string ao4 { get; set; }
        public string ao5 { get; set; }

        public string ao1 { get; set; }
        public string bo1 { get; set; }
        public string ao7 { get; set; }
        public string bo7 { get; set; }
        public string ao2 { get; set; }
        public string bo2 { get; set; }
        public string ao8 { get; set; }
        public string bo8 { get; set; }
        public string ao9 { get; set; }
        public string bo9 { get; set; }
        public string ao10 { get; set; }
        public string bo10 { get; set; }
        public string ao11 { get; set; }
        public string bo11 { get; set; }
        public string ao12 { get; set; }
        public string bo12 { get; set; }
        public string ao13 { get; set; }
        public string bo13 { get; set; }
        public string ao14 { get; set; }
        public string bo14 { get; set; }
        public string sons2 { get; set; }
        public string tungaah { get; set; }
        public string ao1d { get; set; }
        public string ao2d { get; set; }
        public string ao3d { get; set; }
        public string ao4d { get; set; }
        public string ao5d { get; set; }
        public string ao6d { get; set; }
        public string niitd { get; set; }
        public string niitu { get; set; }
        public string sons1 { get; set; }
        public string t11 { get; set; }
        public string yach31 { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text  = "1РО АО : " + ao1 + "кВт";
            label2.Text  = "1РО БО : " + bo1 + "кВт";
            label3.Text  = "7Р АО  : " + ao7 + "кВт";
            label4.Text  = "7Р БО  : " + bo7 + "кВт";
            label5.Text  = "2РО АО : " + ao2 + "кВт";
            label6.Text  = "2РО БО : " + bo2 + "кВт";
            label7.Text  = "8Р АО  : " + ao8 + "кВт";
            label8.Text  = "8Р БО  : " + bo8 + "кВт";
            label9.Text  = "9Р АО  : " + ao9 + "кВт";
            label10.Text = "9Р БО  : " + bo9 + "кВт";
            label11.Text = "10Р АО : " + ao10 + "кВт";
            label12.Text = "10Р БО : " + bo10 + "кВт";
            label13.Text = "11Р АО : " + ao11 + "кВт";
            label14.Text = "11Р БО : " + bo11 + "кВт";
            label15.Text = "12Р АО : " + ao12 + "кВт";
            label16.Text = "12Р БО : " + bo12 + "кВт";
            label17.Text = "13Р АО : " + ao13 + "кВт";
            label18.Text = "13Р БО : " + bo13 + "кВт";
            label19.Text = "14Р АО : " + ao14 + "кВт";
            label20.Text = "14Р БО : " + bo14 + "кВт";
            label21.Text = "СОНС-2 : " + sons2 + "кВт";
            label22.Text = "Тунгаах : " + tungaah + "кВт";

            label23.Text = "1P AО : " + ao1d + "кВт";
            label24.Text = "2P AО : " + ao2d + "кВт";
            label25.Text = "3P AО : " + ao3d + "кВт";
            label26.Text = "4P AО : " + ao4d + "кВт";
            label27.Text = "5P AО : " + ao5d + "кВт";
            label28.Text = "6P AО : " + ao6d + "кВт";
            label29.Text = "СОНС-1 : " + sons1 + "кВт";
            label30.Text = "11Т : " + t11 + "кВт";
            label31.Text = "Яч-31 : " + yach31 + "кВт";

            label32.Text = "ӨДХ дотоод хэрэгцээ нийт  : " + niitu + "MВт";
            label33.Text = "ДДХ дотоод хэрэгцээ нийт : " + niitd + "MВт";

            //   Form1 frma = new Form1();
            //            label1.Text = 
            //this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
