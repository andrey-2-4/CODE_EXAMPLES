using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_
{
    /// <summary>
    /// Главная форма программы.
    /// </summary>
    public partial class Form1 : Form
    {
        public static string[] info = { "0", "classic", "cringe.txt" };

        /// <summary>
        /// Конструктор главного окна.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            RestoreSettings();
        }

        // Тут чуть больше 40 строк из-за if и try, разбивать на блоки не имеет смысла, методы были бы одноразовыми.
        /// <summary>
        /// Восстановление настроек.
        /// </summary>
        public void RestoreSettings()
        {
            try
            {
                // Программа пытается восстановить настройки, которые были заданы в прошлый раз.
                string savedSettings = File.ReadAllText("programMemory.txt");
                info = savedSettings.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (info.Length != 3)
                    throw new Exception("Файл с настройками некорректен, возможно в пути есть пробелы");
                textBoxGetPath.Text = info[2];
                if (info[2].EndsWith(".txt"))
                {
                    richTextBox.Text = File.ReadAllText(info[2]);
                }
                else
                {
                    StreamReader streamReader;
                    string fileName = info[2];
                    textBoxGetPath.Text = fileName;
                    streamReader = File.OpenText(fileName);
                    richTextBox.Rtf = streamReader.ReadToEnd();
                }
                if (info[1] == "dark")
                { 
                    richTextBox.BackColor = Color.Black;
                    if (info[2].EndsWith(".txt"))
                        richTextBox.ForeColor = Color.White;
                }
                else
                { 
                    richTextBox.BackColor = Color.White;
                    if (info[2].EndsWith(".txt"))
                        richTextBox.ForeColor = Color.Black;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                info = new string[] { "0", "classic", "cringe.txt" };
            }
        }

        /// <summary>
        /// Метод открывает TXT файл.
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления.</param>
        /// <param name="e"> Данные о событии.</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new();
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxGetPath.Text = openFileDialog.FileName;
                    info[2] = textBoxGetPath.Text;
                    richTextBox.Text = File.ReadAllText(info[2]);
                    if (richTextBox.BackColor == Color.Black)
                        richTextBox.ForeColor = Color.White;
                    else
                        richTextBox.ForeColor = Color.Black;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Метод при сохранении файла.
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления.</param>
        /// <param name="e"> Данные о событии.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(Path.GetExtension(saveFileDialog.FileName) == ".txt")
                    {
                        richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }
                    else
                    {
                        if(Path.GetExtension(saveFileDialog.FileName) == ".rtf")
                        {
                            richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        }
                        else
                        {
                            throw new Exception("Что-то пошло не так во время сохранения");
                        }
                    }
                    info[2] = saveFileDialog.FileName;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Метод открывает RTF файл.
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления.</param>
        /// <param name="e"> Данные о событии.</param>
        private void openRTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new();
                openFileDialog.Filter = "rtf files (*.rtf)|*.rtf";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader streamReader;
                    string fileName = openFileDialog.FileName;
                    textBoxGetPath.Text = fileName;
                    streamReader = File.OpenText(fileName);
                    richTextBox.Rtf = streamReader.ReadToEnd();
                    info[2] = fileName;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Форматирование фрагмента.
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления.</param>
        /// <param name="e"> Данные о событии.</param>
        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
            richTextBox.SelectionFont = fontDialog.Font;
            colorDialog.ShowDialog();
            richTextBox.SelectionColor = colorDialog.Color;
        }

        /// <summary>
        /// Смена на обычную тему.
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления.</param>
        /// <param name="e"> Данные о событии.</param>
        private void classicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.BackColor = Color.White;
            if (textBoxGetPath.Text.EndsWith(".txt"))
                richTextBox.ForeColor = Color.Black;
            info[1] = "classic";
        }

        /// <summary>
        /// Смена на темную тему.
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления.</param>
        /// <param name="e"> Данные о событии.</param>
        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.BackColor = Color.Black;
            if (textBoxGetPath.Text.EndsWith(".txt"))
                richTextBox.ForeColor = Color.White;
            info[1] = "dark";
        }

        /// <summary>
        /// Обработка при закрытии.
        /// </summary>
        /// <param name="sender"> Ссылка на элемент управления.</param>
        /// <param name="e"> Данные о событии.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Следующий вопрос будет про сохранение", "Вы хотите закрыть программу?",  MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show($"Дальше программа закроется, {Environment.NewLine}Нажмите кнопочку 'Сохранить', {Environment.NewLine}иначе этого не произойдет", "Сохранить файл?", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                string settings = String.Join(' ', info);
                try
                {
                    File.WriteAllText("programMemory.txt", settings);
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось записать настройки.");
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
