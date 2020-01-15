using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Laba1
{
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();            
        }

        private void Button2_Click(object sender, EventArgs e) //1 текст Открыть
        {
            openFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var SR = new StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = SR.ReadToEnd();
            }
        }

        private void Button3_Click(object sender, EventArgs e) //2 текст Открыть
        {
            openFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var SR = new StreamReader(openFileDialog1.FileName);
                richTextBox2.Text = SR.ReadToEnd();
            }
        }

        private void Button4_Click(object sender, EventArgs e) //1 текст Сохранить
        {
            saveFileDialog1.Filter = "Текстовые файлы (*.txt) | *.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(saveFileDialog1.FileName);
        }

        private void Button7_Click(object sender, EventArgs e) //2 текст Сохранить
        {
            saveFileDialog1.Filter = "Текстовые файлы (*.txt) | *.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                richTextBox2.SaveFile(saveFileDialog1.FileName);
        }

        private void Button5_Click(object sender, EventArgs e) //1 текст Очистить
        {
            richTextBox1.Clear();
        }

        private void Button6_Click(object sender, EventArgs e) //2 текст Очистить
        {
            richTextBox2.Clear();
        }

        string[] text1, text2;
        string rtb1, rtb2, RES, FirstText, SecondText;

        private void Button8_Click(object sender, EventArgs e)
        {
            Form form4lab = new Form4lab();
            form4lab.Show();
        }

        int i;
        List<string[]> result = new List<string[]>();
        List<string[]> resForRTB = new List<string[]>();
        private void Button1_Click(object sender, EventArgs e) //Сравнить тексты
        {
            RES = "";
            FirstText = "";
            SecondText = "";
            rtb1 = richTextBox1.Text;
            rtb2 = richTextBox2.Text;
            resForRTB = IsEqualsTexts(rtb1, rtb2); 
            for (i = 0; i < resForRTB.Count; i++)
            {
                richTextBox1.SelectionStart = richTextBox1.Text.IndexOf(resForRTB[i][0], 0);
                richTextBox1.SelectionLength = resForRTB[i][0].Length;
                richTextBox1.SelectionBackColor = Color.Green;
                richTextBox2.SelectionStart = richTextBox2.Text.IndexOf(resForRTB[i][1], 0);
                richTextBox2.SelectionLength = resForRTB[i][1].Length;
                richTextBox2.SelectionBackColor = Color.Green;
                RES += string.Join(" ", resForRTB[i][0]) + "\t" + string.Join(" ", resForRTB[i][1]) + "\n";
                FirstText += string.Join(" ", resForRTB[i][0]) + " | ";
                SecondText += string.Join(" ", resForRTB[i][1]) + " | ";
            }
            File.WriteAllText(Application.StartupPath + "/result.rtf", RES, Encoding.Default);
            DB.UpdateRes(FirstText, SecondText);
        }

        public List<string[]> IsEqualsTexts(string rtb1, string rtb2)
        {
            i = 0;
            text1 = rtb1.Split('\n');
            text2 = rtb2.Split('\n');
            while (i < text1.Length && i < text2.Length)
            {
                if (text1[i] != text2[i])
                {
                    result.Add(new string[] { text1[i], text2[i] });
                }
                i++;
            }
            if (text1.Length < text2.Length)
                for (; i < text2.Length; i++)
                {
                    result.Add(new string[] { "", text2[i] });
                }
            else
                for (; i < text1.Length; i++)
                {
                    result.Add(new string[] { text1[i], "" });
                }
            return result;
        }
    }
}
