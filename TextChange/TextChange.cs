using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;


namespace TextChange
{
    public partial class TextChange : Form
    {
        //Флаги и переменные добавленные мной
        private StringReader m_myReader;
        private uint m_PrintPageNumber;
        private bool TextChanged = false;
        
       //private string defaultPath = "Desktop";
        private string Path = "";
        //Кнопка Зачеркнутого Шрифта Метод
        private void SetStrikeOut()
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                //  CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Strikeout == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Strikeout;
                }

                richTextBox1.SelectionFont = new Font(
                  currentFont.FontFamily, currentFont.Size, newFontStyle);

                //  CheckMenuFontCharacterStyle();
            }
        }
        //Открытие файла метод
        private void Open()
        {
        	slabel1.Text ="Открытие файла";
			if (TextChanged)
			{
				DialogResult result = MessageBox.Show("File was Changed.Do you want to save it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == DialogResult.Yes)
				{
					SaveAs();                 
				}               
			}
            
                if (openFileDialog1.ShowDialog() ==
                   System.Windows.Forms.DialogResult.OK &&
                   openFileDialog1.FileName.Length > 0)
                {
                    try
                    {
                    Path = openFileDialog1.FileName;
                        richTextBox1.LoadFile(openFileDialog1.FileName,
                           RichTextBoxStreamType.RichText);
                    }
                    catch (System.ArgumentException ex)
                    {
                        richTextBox1.LoadFile(openFileDialog1.FileName,
                           RichTextBoxStreamType.PlainText);
                    }

                    this.Text = "Файл [" + openFileDialog1.FileName + "]";
                Path = openFileDialog1.FileName;
                }
                TextChanged = false;
                slabel1.Text ="";
        }
        //Кнопка шрифта с подчеркиванием метод
        private void SetUnderline()
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
              //  CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                }

                richTextBox1.SelectionFont = new Font(
                  currentFont.FontFamily, currentFont.Size, newFontStyle);

              //  CheckMenuFontCharacterStyle();
            }
        }
        //Кнопка полужирного шрифта метод
        private void SetItalic()
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                //CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                richTextBox1.SelectionFont = new Font(
                  currentFont.FontFamily, currentFont.Size, newFontStyle);

               // CheckMenuFontCharacterStyle();
            }
        }
        //Кнопка жирного шрифта метод
        private void Bold()
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontSyle;
                if (richTextBox1.SelectionFont.Bold == true)
                {
                    newFontSyle = FontStyle.Regular;
                }
                else 
                {
                    newFontSyle = FontStyle.Bold;
                    
                }
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontSyle);
                //CheckMenuFontCharacterStyle();
                
            }
            
        }
        //Метод сохранения
        
        private void SaveAs()
        {
        	slabel1.Text ="Сохранение файла";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                this.Text = "Файл [" + saveFileDialog1.FileName + "]";
                Path=saveFileDialog1.FileName;
                TextChanged = false;
            }
            slabel1.Text ="Фаил Сохранен";

        }
        private void Save()
        {
        	slabel1.Text ="Сохранение файла";
        	 if (Path.Length != 0)
            {
                richTextBox1.SaveFile(Path);
                TextChanged = false;
            }
            else SaveAs();
            slabel1.Text ="Фаил сохранен";
        }
        public TextChange()
        {
            InitializeComponent();
        }
       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            TextChanged = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        //Печать
        private void MenuFilePrint()
        {
            m_PrintPageNumber = 1;

            string strText = this.richTextBox1.Text;
            m_myReader = new StringReader(strText);

            Margins margins = new Margins(100, 50, 50, 50);
            printDocument1.DefaultPageSettings.Margins = margins;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
            m_myReader.Close();
        }
        //Открытие Файла
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        	Open();
        
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        //Сохранение файла(Save as...)
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
        //Сохранение файла(Save)
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Path.Length != 0)
            {
                richTextBox1.SaveFile(Path);
                TextChanged = false;
            }
            else SaveAs();

        }
        //Окно Настройки
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }
        //Показ перед печатью
        private void pagePreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_PrintPageNumber = 1;

            string strText = this.richTextBox1.Text;
            m_myReader = new StringReader(strText);
            Margins margins = new Margins(100, 50, 50, 50);

            printDocument1.DefaultPageSettings.Margins = margins;
            printPreviewDialog1.ShowDialog();

            m_myReader.Close();
        }
        //Выход
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextChanged == true)
            {
                DialogResult result= MessageBox.Show("File was Changed.Do you want to save it?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveAs();
                    this.Close();
                }
               else this.Close();
            }
            this.Close();
            
        }
        //Вырезать
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        //копировать
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
        //Вставить
        private void pesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        //Отмена
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }
        //Выделить все
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuFilePrint();
        }
        //Шрифт
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }

        }
        //Цвет
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bold();
        }
        //Кнопка полужирного шрифта
        private void italcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetItalic();
        }

        private void underLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUnderline();
        }
        //Кнопка Зачеркнутого Шрифта
        private void strikeOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStrikeOut();
        }
        //Выравнивание слева
        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        //Выравнивание справа
        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        //Выравнивание по центру
        private void centreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlgAbout = new About();
            dlgAbout.ShowDialog();
        }



        //Замена в тексте
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlgSearch = new Replace(richTextBox1);
            dlgSearch.ShowDialog();
        }
        //Поиск в тексте
        private void findToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
//            Form findform = new Find(richTextBox1);
//            findform.ShowDialog();
//            string find = textBox1.Text;
//            string text = richTextBox1.Text;
//            int a = Convert.ToInt32(text.IndexOf(find));
//            for(int i=0;i<10;i++)
//            {
//            _editor.Select(a,find.Length);
//            a=a+1;
//            }
        }
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			Open();
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			Save();
		}
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			SaveAs();
		}
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			richTextBox1.Undo();
		}
		void ToolStripButton5Click(object sender, EventArgs e)
		{
			richTextBox1.Redo();
		}
		void ToolStripButton6Click(object sender, EventArgs e)
		{
			richTextBox1.Copy();
		}
		void ToolStripButton7Click(object sender, EventArgs e)
		{
			richTextBox1.Cut();
		}
		void ToolStripButton8Click(object sender, EventArgs e)
		{
			richTextBox1.Paste();
		}
		void StatusStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
	
		}
		void NextToolStripMenuItemClick(object sender, EventArgs e)
		{
	        string find = toolStrip1.Text;
            string text = richTextBox1.Text;
            int a = Convert.ToInt32(text.IndexOf(find));
            for(int i=0;i<10;i++)
            {
            richTextBox1.Select(a,find.Length);
            a=a+1;
            }
		}
    }
}
