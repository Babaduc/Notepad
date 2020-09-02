using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextChange
{
    public partial class Replace : Form
    {
        private RichTextBox _editor;
        public Replace(RichTextBox richtextbox)
        {
            InitializeComponent();
            _editor = richtextbox;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string find = textBox1.Text;
            string replace = textBox2.Text;
            string text = _editor.Text;
            text = text.Replace(find, replace);
            _editor.Text = text;
        }
    }
}
