using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TextChange
{
    public class TextChangeForm : System.Windows.Forms.Form
    {
        private void MenuFileOpen()
        {
           
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TextChangeForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "TextChangeForm";
            this.Load += new System.EventHandler(this.TextChangeForm_Load);
            this.ResumeLayout(false);

        }

        private void TextChangeForm_Load(object sender, EventArgs e)
        {

        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TextChange());
        }
    }
}
