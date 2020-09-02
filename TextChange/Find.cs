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
    public partial class Find : Form
    {
        private RichTextBox _editor;
        public Find(RichTextBox richtextbox)
        {
            
            InitializeComponent();
            _editor = richtextbox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string find = textBox1.Text;
            string text = _editor.Text;
            int a = Convert.ToInt32(text.IndexOf(find));
            for(int i=0;i<10;i++)
            {
            _editor.Select(a,find.Length);
            a=a+1;
            }
            
   
        }
    }
}
