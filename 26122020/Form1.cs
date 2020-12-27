using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _26122020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            //if (colorDialog1.ShowDialog() == DialogResult.OK)
            //    BackColor = colorDialog1.Color;

            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                BackColor = colorDialog.Color;

        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
        }
        private void buttonFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Font = fontDialog1.Font;
                label1.ForeColor = fontDialog1.Color;
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox2.Text = openFileDialog1.FileName;
                textBox2.Text = File.ReadAllText(openFileDialog1.FileName);

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Текстові файли|*.txt|Sharp|*.cs|all files|*.*";
                dialog.FilterIndex = 1;
                dialog.DefaultExt = "cs";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // textBox2.Text = openFileDialog1.FileName;
                    File.WriteAllText(dialog.FileName, textBox2.Text);
                }
            }


        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printText = textBox2.Text;
                printDocument1.Print();
            }
        }
        string printText;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.MarginBounds);
            e.Graphics.MeasureString(
              printText,
              textBox2.Font,
              e.MarginBounds.Size,
              StringFormat.GenericTypographic,
              out int charOnPage,
              out int lineOnPage
              );
            e.Graphics.DrawString(
                printText,
                textBox2.Font,
                Brushes.Red,
                e.MarginBounds,
                StringFormat.GenericTypographic
                );

            printText = printText.Substring(charOnPage);

            e.HasMorePages = printText.Length > 0;

            if (printText.Length == 0)
                printText = textBox2.Text;
        }

        private void buttonPageSetup_Click(object sender, EventArgs e)
        {
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            printText = textBox2.Text;
            printPreviewDialog1.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
           // this.tabPage4.Location = new System.Drawing.Point(4, 22);
          // this.tabPage4.Name = "tabPa";
            tab.Padding = new System.Windows.Forms.Padding(3);
            tab.Size = new System.Drawing.Size(513, 310);
            tab.TabIndex = 3;
            tab.Text = "New Tab";
            tab.UseVisualStyleBackColor = true;

            tabControl1.TabPages.Add(tab);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //  tabControl1.TabPages.Remove(tabControl1.TabPages[0]);
            if (tabControl1.SelectedTab!=null) {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Blue;
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Red;
        }
    }
}
