﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Umover_queue;





namespace stek_queue
{
    public partial class LIFOFIFO : Form
    {
        int t = 50;
        int s = 12;
        // Bitmap bmp = null;
        // PictureBox pic1 = null;
        Stek Stek = new Stek();
        Queue Queue = new Queue();
        Deque Deque = new Deque();
        Color Color;


        public LIFOFIFO()
        {
            InitializeComponent();
            KeyPreview = true;
            helpProvider.HelpNamespace = "helper.chm";
            ((Stek.t, Stek.s), (Queue.t, Queue.s), (Deque.t, Deque.s)) = ((t, s), (t, s), (t, s));
            var inputToolTip = new ToolTip();
            inputToolTip.SetToolTip(CreateStek, "Создает новый стек, ниже можно указать начальные значения (данные вводятся через пробел),\nпри наличии рабочего стека удаляет его и создает новый.");
            inputToolTip.SetToolTip(AddToStek, "Добавляет данные в созданный стек (данные вводятся через пробел),\nпри отсутствии стека его сперва необходимо создать, нажав на соответствующую кнопку.");
            inputToolTip.SetToolTip(DeleteEL, "Удаляет данные из стека, количество удаляемых данных можно написать ниже,\nпри отсутствии значений удаляет 1 элемент.");
            inputToolTip.SetToolTip(ClearStekCplusplus, "После определения неиспользуемых данных их следует удалить из Стека." +
                "\nЭто можно сделать с помощью инструкции «pop» или других аналогичных команд, в зависимости от используемого языка программирования.");
            inputToolTip.SetToolTip(ClearStekCshrp, "Если объект класса перестает использоваться, то при очистке стека ссылка на участок памяти также очищается," +
                "\nоднако это не приводит к немедленной очистке самого участка памяти в куче. Впоследствии сборщик мусора увидит,\n" +
                "что на данный участок памяти больше нет ссылок, и очистит его.");
            inputToolTip.SetToolTip(CreateNewQueue, "Создает новую очередь, ниже можно указать начальные значения (данные вводятся через пробел),\nпри наличии рабочего стека удаляет его и создает новый.");
            inputToolTip.SetToolTip(QueueAdd, "Добавляет данные в созданную очередь (данные вводятся через пробел),\nпри отсутствии стека его сперва необходимо создать, нажав на соответствующую кнопку.");
            inputToolTip.SetToolTip(DeleteFromQueue, "Удаляет данные из очереди, количество удаляемых данных можно написать ниже,\nпри отсутствии значений удаляет 1 элемент.");
            inputToolTip.SetToolTip(ClearQueueCplusplus, "После определения неиспользуемых данных их следует удалить из Очереди." +
                "\nЭто можно сделать с помощью инструкции «pop» или других аналогичных команд, в зависимости от используемого языка программирования.");
            inputToolTip.SetToolTip(ClearQueueCSharp, "Если объект класса перестает использоваться, то при очистке очереди ссылка на участок памяти также очищается," +
                "\nоднако это не приводит к немедленной очистке самого участка памяти в куче. Впоследствии сборщик мусора увидит,\n" +
                "что на данный участок памяти больше нет ссылок, и очистит его.");
            //comboBox1.SelectedIndex = 0;
            Color = this.BackColor;

            settings.Reader(this);
            ColorChanger(this.BackColor);

        }


        List<Button> stek = new List<Button>();
        List<string> stek_string = new List<string>();
        List<bool> stek_done = new List<bool>();
        List<Button> queue = new List<Button>();
        List<string> queue_string = new List<string>();
        List<bool> queue_done = new List<bool>();
        List<Button> deque = new List<Button>();
        List<string> deque_string = new List<string>();
        List<bool> deque_done = new List<bool>();


        private void ColorChanger(Color color)
        {
            this.BackColor = color;
            tabPage1.BackColor = color;
            tabPage2.BackColor = color;
            tabPage3.BackColor = color;
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider.HelpNamespace);
        }

        private void получитьИнToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            var r = Stek.check(stek_done);
            if (r)
                return;
            Stek.ClearStek(panelStek, StekCurInfo, stek, stek_string, stek_done);
            StekCurInfo.Text = "Стек создан";
            if (StartStekStore.Text.Replace("  ", " ").Split(' ').ToArray().Length > 10)
            {
                MessageBox.Show("Слишком большое количество элементов максимум - 10");
                return;
            }
            if (StartStekStore.Text.Length > 0)
                Stek.creator(StartStekStore.Text.Replace("  ", " ").Split(' ').ToArray(), panelStek, stek, stek_string, stek_done);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var r = Stek.check(stek_done);
            if (r)
                return;
            if (StekCurInfo.Text == "Стек не создан")
            {

                MessageBox.Show("Создайте новый стек");
                return;
            }
            if (stek.Count + AddToStekStore.Text.Replace("  ", " ").Split(' ').ToArray().Length > 10)
            {
                MessageBox.Show("Слишком большое количество элементов максимум - 10");
                return;
            }
            Stek.creator(AddToStekStore.Text.Replace("  ", " ").Split(' ').ToArray(), panelStek, stek, stek_string, stek_done);

        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var r = Stek.check(stek_done);
            if (r)
                return;
            if (StekCurInfo.Text == "Стек не создан")
                return;
            Int32.TryParse(DeleteNumber.Text, out int a);
            if (a == 0)
                a = 1;
            if (a > stek.Count)
            {
                MessageBox.Show("Невозможно удалить такое количество элементов");
                return;
            }
            var c = stek.Count;
            for (int i = 1; i <= a; i++)
            {
                await Task.Delay(1000);
                stek[c - i].BackColor = Color.Red;
                Stek.moveDown(stek[c - i].PointToScreen(Point.Empty), new Point(stek[c - i].Location.X,
                 panelStek.Size.Height + stek[c - i].Size.Height + 1), stek[c - i], c - i, a, panelStek, stek, stek_string, stek_done);
            }
            await Stek.rdAn(a, panelStek, stek, stek_string, stek_done, this);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var r = Stek.check(stek_done);
            if (r)
                return;
            StekCurInfo.Text = "Стек не создан";
            var a = stek.Count;
            var c = stek.Count;
            for (int i = 1; i <= a; i++)
            {
                stek[c - i].BackColor = Color.Red;
                Stek.moveDown(stek[c - i].PointToScreen(Point.Empty), new Point(stek[c - i].Location.X, panelStek.Size.Height
                 + stek[c - i].Size.Height * 2), stek[c - i], c - i, a, panelStek, stek, stek_string, stek_done);
            }
            await Stek.rdAn(stek.Count, panelStek, stek, stek_string, stek_done, this);

        }

        private async void button4_Click_1(object sender, EventArgs e)
        {
            var r = Stek.check(stek_done);
            if (r)
                return;
            StekCurInfo.Text = "Стек не создан";
            var a = stek.Count;
            var c = stek.Count;
            for (int i = 1; i <= a; i++)
            {
                stek[c - i].BackColor = Color.Red;
                await Task.Delay(1000);
                Stek.moveDown(stek[c - i].PointToScreen(Point.Empty), new Point(stek[c - i].Location.X,
                    panelStek.Size.Height + stek[c - i].Size.Height + 1), stek[c - i], c - i, a, panelStek, stek, stek_string, stek_done);
            }
            await Stek.rdAn(a, panelStek, stek, stek_string, stek_done, this);
        }

        private void получитьСправочнуюИнформациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Стек — это одна из структур данных. Структура данных — это то, как хранятся данные: например, связанные списки, деревья, очереди, множества, хеш-таблицы, карты и даже кучи (heap). Как устроен стек\r\nСтек хранит последовательность данных. Связаны данные так: каждый элемент указывает на тот, который нужно использовать следующим. Это линейная связь — данные идут друг за другом и нужно брать их по очереди. Из середины стека брать нельзя.\r\n\r\n👉 Главный принцип работы стека — данные, которые попали в стек недавно, используются первыми. Чем раньше попал — тем позже используется. После использования элемент стека исчезает, и верхним становится следующий элемент.");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{stek.Count}");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ChangeSize();
        }

        void ChangeSize()
        {
            var r = Stek.check(stek_done) || Queue.check(queue_done);
            if (r)
                return;
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
            Stek.Pos(panelStek, stek);
            Queue.Pos(panelQueue, queue);
            s = panelStek.Size.Width * panelStek.Size.Height / 20000;
            Stek.s = s;
            Queue.s = s;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var r = Queue.check(queue_done);
            if (r)
                return;
            Queue.ClearQueue(panelQueue, label4, queue, queue_string, queue_done);
            label4.Text = "Очередь создана";
            if (StartStekStore.Text.Replace("  ", " ").Split(' ').ToArray().Length > 10)
            {
                MessageBox.Show("Слишком большое количество элементов максимум - 10");
                return;
            }
            if (QueueNewStore.Text.Length > 0)
                Queue.creator(QueueNewStore.Text.Replace("  ", " ").Split(' ').ToArray(), panelQueue, queue, queue_string, queue_done);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var r = Queue.check(queue_done);
            if (r)
                return;
            if (label4.Text == "Очередь не создана")
            {

                MessageBox.Show("Создайте новую очередь");
                return;
            }
            if (queue.Count + QueueAddStore.Text.Replace("  ", " ").Split(' ').ToArray().Length > 10)
            {
                MessageBox.Show("Слишком большое количество элементов максимум - 10");
                return;
            }
            Queue.creator(QueueAddStore.Text.Replace("  ", " ").Split(' ').ToArray(), panelQueue, queue, queue_string, queue_done);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button9_ClickAsync(object sender, EventArgs e)
        {
            var r = Queue.check(queue_done);
            if (r)
                return;
            if (StekCurInfo.Text == "Очередь не создана")
                return;
            Int32.TryParse(DeleneFromQueueCount.Text, out int a);
            if (a == 0)
                a = 1;
            if (a > queue.Count)
            {
                MessageBox.Show("Невозможно удалить такое количество элементов");
                return;
            }
            var c = queue.Count;
            for (int i = 0; i < a; i++)
            {
                await Task.Delay(1000);
                queue[i].BackColor = Color.Red;

                Queue.moveDown(queue[i].PointToScreen(Point.Empty), new Point(queue[i].Location.X, panelQueue.Size.Height + queue[i].Size.Height + 1), queue[i], i, a, panelQueue, queue, queue_string, queue_done);
            }
            await Queue.rdAn(a, panelQueue, queue, queue_string, queue_done, this);
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            var r = Queue.check(queue_done);
            if (r)
                return;
            if (StekCurInfo.Text == "Очередь не создана")
                return;
            label4.Text = "Очередь не создана";
            var c = queue.Count;
            for (int i = 0; i < c; i++)
            {
                await Task.Delay(1000);
                queue[i].BackColor = Color.Red;

                Queue.moveDown(queue[i].PointToScreen(Point.Empty), new Point(queue[i].Location.X, panelQueue.Size.Height + queue[i].Size.Height + 1), queue[i], i, c, panelQueue, queue, queue_string, queue_done);
            }
            await Queue.rdAn(c, panelQueue, queue, queue_string, queue_done, this);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private async void button11_Click(object sender, EventArgs e)
        {
            var r = Queue.check(queue_done);
            if (r)
                return;
            if (label4.Text == "Очередь не создана")
                return;
            label4.Text = "Очередь не создана";
            var c = queue.Count;
            for (int i = 0; i < c; i++)
            {
                queue[i].BackColor = Color.Red;
                Queue.moveDown(queue[i].PointToScreen(Point.Empty), new Point(queue[i].Location.X, panelQueue.Size.Height + queue[i].Size.Height + 1), queue[i], i, c, panelQueue, queue, queue_string, queue_done);
            }
            await Queue.rdAn(c, panelQueue, queue, queue_string, queue_done, this);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            var r = Stek.check(stek_done) || Queue.check(queue_done) || Deque.check(deque_done);
            if (r)
                return;
            Stek.Pos(panelStek, stek);
            Queue.Pos(panelQueue, queue);
            Deque.Pos(panelDeque, deque);
            s = panelStek.Size.Width * panelStek.Size.Height / 20000;
            Stek.s = s;
            Queue.s = s;
            Deque.s = s;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ChangeSize();
        }

        private void очиститьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void получитьИнформациюОТипеДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Очередь (англ. queue)  — это структура данных, добавление и удаление элементов в которой происходит путём операций push\r\n и pop\r\n соответственно. Притом первым из очереди удаляется элемент, который был помещен туда первым, то есть в очереди реализуется принцип «первым вошел — первым вышел» (англ. first-in, first-out — FIFO). У очереди имеется голова (англ. head) и хвост (англ. tail). Когда элемент ставится в очередь, он занимает место в её хвосте. Из очереди всегда выводится элемент, который находится в ее голове. ");
        }

        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider.HelpNamespace);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stek = "stek:";
            stek += String.Join(" ", stek_string) + ";";
            var save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Test files|*.txt";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK && save.FileName.Length > 0)
            {
                File.Delete(save.FileName);
                using (var sw = new StreamWriter(save.FileName, true))
                {

                    sw.WriteLine(stek);
                    sw.Close();
                    MessageBox.Show("Файл успешно сохранен.");
                }
            }

        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var name = openFileDialog1.FileName;
                var text = File.ReadAllText(name);
                if (text.Substring(0, 5) == "stek:")
                {
                    if (text.Split(' ').Count() > 10)
                    {
                        MessageBox.Show("Слишком большое количество элементов");
                        return;
                    }
                    text = text.Substring(5);
                    text = text.Substring(0, text.Length - 3);
                    //MessageBox.Show(text);
                    Stek.ClearStek(panelStek, StekCurInfo, stek, stek_string, stek_done);
                    Stek.loader(text.Split(' '), panelStek, stek, stek_string, stek_done);
                    StekCurInfo.Text = "Стек создан";
                    MessageBox.Show("Файл успешно загружен");
                }
                else
                {
                    MessageBox.Show("Неподдерживаемый формат");
                    return;
                }
            }

        }

        private void сохранитьКакToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var queue = "queue:";
            queue += String.Join(" ", queue_string) + ";";
            var save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Test files|*.txt";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK && save.FileName.Length > 0)
            {
                File.Delete(save.FileName);
                using (var sw = new StreamWriter(save.FileName, true))
                {

                    sw.WriteLine(queue);
                    sw.Close();
                    MessageBox.Show("Файл успешно сохранен.");
                }
            }

        }

        private void загрузитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var name = openFileDialog1.FileName;
                var text = File.ReadAllText(name);
                if (text.Substring(0, 6) == "queue:")
                {
                    if (text.Split(' ').Count() > 10)
                    {
                        MessageBox.Show("Слишком большое количество элементов");
                        return;
                    }
                    text = text.Substring(6);
                    text = text.Substring(0, text.Length - 3);
                    //MessageBox.Show(text);
                    Queue.ClearQueue(panelQueue, label4, queue, queue_string, queue_done);
                    Queue.loader(text.Split(' '), panelQueue, queue, queue_string, queue_done);
                    label4.Text = "Очередь создана";
                    MessageBox.Show("Файл успешно загружен");
                }
                else
                {
                    MessageBox.Show("Неподдерживаемый формат");
                    return;
                }
            }
        }

        private void LIFOFIFO_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, helpProvider.HelpNamespace);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider.HelpNamespace);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ChangeSize();
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            var r = Deque.check(deque_done);
            if (r)
                return;
            Deque.ClearDeque(panelDeque, label2, deque, deque_string, deque_done);
            label2.Text = "Дек создан";
            if (textBox3.Text.Replace("  ", " ").Split(' ').ToArray().Length > 10)
            {
                MessageBox.Show("Слишком большое количество элементов, максимум - 10");
                return;
            }
            if (textBox3.Text.Length > 0)
                Deque.creator(textBox3.Text.Replace("  ", " ").Split(' ').ToArray(), panelDeque, deque, deque_string, deque_done);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var r = Deque.check(deque_done);
            if (r)
                return;
            if (label2.Text == "Дек не создан")
            {

                MessageBox.Show("Создайте новый дек");
                return;
            }
            if (deque.Count + textBox2.Text.Replace("  ", " ").Split(' ').ToArray().Length > 10)
            {
                MessageBox.Show("Слишком большое количество элементов, максимум - 10");
                return;
            }
            Deque.creator(textBox2.Text.Replace("  ", " ").Split(' ').ToArray(), panelDeque, deque, deque_string, deque_done, false);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            var r = Deque.check(deque_done);
            if (r)
                return;
            if (label2.Text == "Дек не создан")
            {

                MessageBox.Show("Создайте новый дек");
                return;
            }
            if (deque.Count + textBox2.Text.Replace("  ", " ").Split(' ').ToArray().Length > 10)
            {
                MessageBox.Show("Слишком большое количество элементов, максимум - 10");
                return;
            }
            Deque.creator(textBox4.Text.Replace("  ", " ").Split(' ').ToArray(), panelDeque, deque, deque_string, deque_done);

        }

        private async void button8_Click_1(object sender, EventArgs e)
        {
            var r = Deque.check(queue_done);
            if (r)
                return;
            if (StekCurInfo.Text == "Дек не создан")
                return;
            Int32.TryParse(textBox5.Text, out int a);
            if (a == 0)
                a = 1;
            if (a > deque.Count)
            {
                MessageBox.Show("Невозможно удалить такое количество элементов");
                return;
            }
            var c = deque.Count;
            for (int i = 0; i < a; i++)
            {
                await Task.Delay(1000);
                deque[i].BackColor = Color.Red;

                Queue.moveDown(deque[i].PointToScreen(Point.Empty), new Point(deque[i].Location.X, panelDeque.Size.Height + deque[i].Size.Height + 1), deque[i], i, a, panelDeque, deque, deque_string, deque_done);
            }
            await Queue.rdAn(a, panelDeque, deque, deque_string, deque_done, this);
        }

        private async void button4_Click_2(object sender, EventArgs e)
        {
            var r = Deque.check(queue_done);
            if (r)
                return;
            if (StekCurInfo.Text == "Дек не создан")
                return;
            Int32.TryParse(textBox1.Text, out int a);
            if (a == 0)
                a = 1;
            if (a > deque.Count)
            {
                MessageBox.Show("Невозможно удалить такое количество элементов");
                return;
            }
            var c = deque.Count;
            for (int i = 1; i <= a; i++)
            {
                await Task.Delay(1000);
                deque[c - i].BackColor = Color.Red;

                Deque.moveDown(deque[c - i].PointToScreen(Point.Empty), new Point(deque[c - i].Location.X, panelDeque.Size.Height + deque[c - i].Size.Height + 1), deque[c - i], c - i, a, panelDeque, deque, deque_string, deque_done);
            }
            await Stek.rdAn(a, panelDeque, deque, deque_string, deque_done, this);
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            var r = Deque.check(stek_done);
            if (r)
                return;
            label2.Text = "Дек не создан";
            var a = deque.Count;
            var c = deque.Count;
            for (int i = 1; i <= a; i++)
            {
                deque[c - i].BackColor = Color.Red;
                Deque.moveDown(deque[c - i].PointToScreen(Point.Empty), new Point(deque[c - i].Location.X, panelDeque.Size.Height
                 + deque[c - i].Size.Height * 2), deque[c - i], c - i, a, panelDeque, deque, deque_string, deque_done);
            }
            await Deque.rdAn(deque.Count, panelDeque, deque, deque_string, deque_done, this);
        }


        private async void button3_Click_1(object sender, EventArgs e)
        {
            var r = Deque.check(stek_done);
            if (r)
                return;
            label2.Text = "Дек не создан";
            var a = deque.Count;
            var c = deque.Count;
            for (int i = 1; i <= a; i++)
            {
                deque[c - i].BackColor = Color.Red;
                Deque.moveDown(deque[c - i].PointToScreen(Point.Empty), new Point(deque[c - i].Location.X, panelDeque.Size.Height
                 + deque[c - i].Size.Height * 2), deque[c - i], c - i, a, panelDeque, deque, deque_string, deque_done);
                await Task.Delay(1000);
            }
            await Deque.rdAn(deque.Count, panelDeque, deque, deque_string, deque_done, this);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var queue = "deque:";
            queue += String.Join(" ", deque_string) + ";";
            var save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Test files|*.txt";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK && save.FileName.Length > 0)
            {
                File.Delete(save.FileName);
                using (var sw = new StreamWriter(save.FileName, true))
                {

                    sw.WriteLine(queue);
                    sw.Close();
                    MessageBox.Show("Файл успешно сохранен.");
                }
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var name = openFileDialog1.FileName;
                var text = File.ReadAllText(name);
                if (text.Substring(0, 6) == "deque:")
                {
                    if (text.Split(' ').Count() > 10)
                    {
                        MessageBox.Show("Слишком большое количество элементов");
                        return;
                    }
                    text = text.Substring(6);
                    text = text.Substring(0, text.Length - 3);
                    //MessageBox.Show(text);
                    Queue.ClearQueue(panelDeque, label2, deque, deque_string, deque_done);
                    Queue.loader(text.Split(' '), panelDeque, deque, deque_string, deque_done);
                    label4.Text = "Очередь создана";
                    MessageBox.Show("Файл успешно загружен");
                }
                else
                {
                    MessageBox.Show("Неподдерживаемый формат");
                    return;
                }
            }
        }



        void OpenSetting()
        {

            backgroundColorDialog = new ColorDialog();
            backgroundColorDialog.ShowDialog();
            if (backgroundColorDialog.Color != this.Color)
                this.Color = backgroundColorDialog.Color;
            ColorChanger(this.Color);

        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSetting();
        }

        private void настройкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenSetting();
        }

        private void настройкиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenSetting();
        }

        private void LIFOFIFO_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Writer(this);
        }

        private void сбросПараметровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete($"settings.dck");
            settings.WriterDefault(this);
            settings.Reader(this);
            ColorChanger(settings.backColor);
        }

        private void сбросПараметровToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            сбросПараметровToolStripMenuItem_Click(sender, e);
        }

        private void сбросПараметровToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            сбросПараметровToolStripMenuItem_Click(sender, e);
        }
    }
}

