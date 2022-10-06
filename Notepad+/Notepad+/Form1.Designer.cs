
namespace Notepad_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meaninglessText1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meaninglessText2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meaninglessText3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meaninglessText4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meaninglessText5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meaninglessText6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.темаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGetPath = new System.Windows.Forms.TextBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTXTToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openRTFToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openTXTToolStripMenuItem
            // 
            this.openTXTToolStripMenuItem.Name = "openTXTToolStripMenuItem";
            this.openTXTToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openTXTToolStripMenuItem.Text = "Открыть TXT файл";
            this.openTXTToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openRTFToolStripMenuItem
            // 
            this.openRTFToolStripMenuItem.Name = "openRTFToolStripMenuItem";
            this.openRTFToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openRTFToolStripMenuItem.Text = "Открыть RTF файл";
            this.openRTFToolStripMenuItem.Click += new System.EventHandler(this.openRTFToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meaninglessText1ToolStripMenuItem,
            this.meaninglessText2ToolStripMenuItem,
            this.meaninglessText3ToolStripMenuItem,
            this.meaninglessText4ToolStripMenuItem,
            this.meaninglessText5ToolStripMenuItem,
            this.meaninglessText6ToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.editToolStripMenuItem.Text = "(С)правка";
            // 
            // meaninglessText1ToolStripMenuItem
            // 
            this.meaninglessText1ToolStripMenuItem.Name = "meaninglessText1ToolStripMenuItem";
            this.meaninglessText1ToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.meaninglessText1ToolStripMenuItem.Text = "слишком сложно придумать,";
            // 
            // meaninglessText2ToolStripMenuItem
            // 
            this.meaninglessText2ToolStripMenuItem.Name = "meaninglessText2ToolStripMenuItem";
            this.meaninglessText2ToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.meaninglessText2ToolStripMenuItem.Text = "что сюда засунуть,";
            // 
            // meaninglessText3ToolStripMenuItem
            // 
            this.meaninglessText3ToolStripMenuItem.Name = "meaninglessText3ToolStripMenuItem";
            this.meaninglessText3ToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.meaninglessText3ToolStripMenuItem.Text = "чтобы не было повторений,";
            // 
            // meaninglessText4ToolStripMenuItem
            // 
            this.meaninglessText4ToolStripMenuItem.Name = "meaninglessText4ToolStripMenuItem";
            this.meaninglessText4ToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.meaninglessText4ToolStripMenuItem.Text = "поэтому вот";
            // 
            // meaninglessText5ToolStripMenuItem
            // 
            this.meaninglessText5ToolStripMenuItem.Name = "meaninglessText5ToolStripMenuItem";
            this.meaninglessText5ToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.meaninglessText5ToolStripMenuItem.Text = "бессмысленный пункт меню,";
            // 
            // meaninglessText6ToolStripMenuItem
            // 
            this.meaninglessText6ToolStripMenuItem.Name = "meaninglessText6ToolStripMenuItem";
            this.meaninglessText6ToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.meaninglessText6ToolStripMenuItem.Text = "но по ТЗ оно есть";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.formatToolStripMenuItem.Text = "Формат";
            this.formatToolStripMenuItem.Click += new System.EventHandler(this.formatToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.темаToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.settingsToolStripMenuItem.Text = "Настройки";
            // 
            // темаToolStripMenuItem
            // 
            this.темаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classicToolStripMenuItem,
            this.darkToolStripMenuItem});
            this.темаToolStripMenuItem.Name = "темаToolStripMenuItem";
            this.темаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.темаToolStripMenuItem.Text = "Тема";
            // 
            // classicToolStripMenuItem
            // 
            this.classicToolStripMenuItem.Name = "classicToolStripMenuItem";
            this.classicToolStripMenuItem.Size = new System.Drawing.Size(388, 26);
            this.classicToolStripMenuItem.Text = "Нормальная";
            this.classicToolStripMenuItem.Click += new System.EventHandler(this.classicToolStripMenuItem_Click);
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(388, 26);
            this.darkToolStripMenuItem.Text = "Наверно нормальная, но чуть-чуть другая";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Полный путь к файлу:";
            // 
            // textBoxGetPath
            // 
            this.textBoxGetPath.Location = new System.Drawing.Point(166, 32);
            this.textBoxGetPath.Name = "textBoxGetPath";
            this.textBoxGetPath.ReadOnly = true;
            this.textBoxGetPath.Size = new System.Drawing.Size(1016, 27);
            this.textBoxGetPath.TabIndex = 2;
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(0, 56);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(1182, 885);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.textBoxGetPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notepad+";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meaninglessText1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meaninglessText2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meaninglessText3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meaninglessText4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meaninglessText5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meaninglessText6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem темаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGetPath;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ToolStripMenuItem openRTFToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

