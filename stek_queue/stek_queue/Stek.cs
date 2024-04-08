using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*namespace stek_queue
{
    public class Stek
    {
        
        public int timeDelay = 0;
        public int speed = 0;

        
        public bool check(List<bool> _done) //проверка на наличие незаконченных асинхронных методов
        {
            if (_done.Contains(false))
            {
                MessageBox.Show("Подождите завершения задачи.");
                return true;
            }
            return false;
        }
        public void ClearStek(Panel panel, System.Windows.Forms.Label label, List<Button> stek, List<string> stek_string, List<bool> stek_done) //очистка стека с полным удалением всей информации
        {

            panel.Controls.Clear();
            stek.Clear();
            stek_string.Clear();
            stek_done.Clear();
            label.Text = "Стек не создан";
        }

        public async void creator(string[] str, Panel panel, List<Button> stek, List<string> stek_string, List<bool> stek_done) //создание элемента и расположение на элементе panel
        {
            for (int i = 0; i < str.Length; i++)
            {
                stek_string.Add(str[i]);
                stek_done.Add(false);
                stek.Add(new Button
                {
                    Location = new Point(1, 100),
                    Text = str[i],
                    Size = new Size(panel.Size.Width / 14, panel.Size.Height / 10),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Font = new Font("Microsoft Sans Serif", panel.Size.Height / 22),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Black,
                    ForeColor = Color.White,


                }
                    );
                panel.Controls.Add(stek[stek.Count - 1]);
            }
            animations(panel, stek, stek_string, stek_done);
        }

        public async void loader(string[] str, Panel panel, List<Button> stek, List<string> stek_string, List<bool> stek_done) //создание элемента и расположение на элементе panel
        {
            for (int i = 0; i < str.Length; i++)
            {
                stek_string.Add(str[i]);
                stek_done.Add(true);
                stek.Add(new Button
                {
                    Location = new Point(1, 100),
                    Text = str[i],
                    Size = new Size(panel.Size.Width / 14, panel.Size.Height / 10),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Font = new Font("Microsoft Sans Serif", panel.Size.Height / 22),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Black,
                    ForeColor = Color.White,


                }
                    );
                panel.Controls.Add(stek[stek.Count - 1]);
            }
           Pos(panel, stek);
        }
        public async void animations(Panel panel, List<Button> stek, List<string> stek_string, List<bool> stek_done) //задание конечных значений для элементов
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = stek.Count;
            for (var i = 0; i < stek.Count; i++)
            {

                move(stek[i].PointToScreen(Point.Empty), new Point((int)(x - (x / (count + 1) * (i + 1))), (int)(y / 2)), stek[i], i, panel,
                    stek, stek_string, stek_done);
                await Task.Delay(800);

            }
        }


        public async void move(Point from, Point to, Button button, int i, Panel panel, List<Button> stek,  
            List<string> stek_string, List<bool> stek_done) //движение элементов к конечным значениеям
        {
            stek_done[i] = false;
            while (Math.Abs(button.Location.Y - to.Y) > panel.Size.Height / 10)
            {
                if (button.Location.Y < to.Y)

                    await Task.Delay(timeDelay);

                button.Location = new Point(button.Location.X, button.Location.Y + (button.Location.Y < to.Y ? +speed : -speed));

            }
            while (Math.Abs(button.Location.X - to.X) > panel.Size.Width / 15)
            {
                await Task.Delay(timeDelay);
                button.Location = new Point(button.Location.X + (button.Location.X < to.X ? +speed : -speed), button.Location.Y);

            }
            stek_done[i] = true;


        }

        public void Pos(Panel panel, List<Button> stek) //изменения положения элементов при изменении размера окна
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = stek.Count;
            for (var i = stek.Count - 1; i >= 0; i--)
            {
                stek[i].Size = new Size(panel.Size.Width / 14, panel.Size.Height / 10);
                stek[i].Location = new Point((int)(x - (x / (count + 1) * (i + 1))) - stek[i].Size.Width, (int)(y / 2) - stek[i].Size.Height);
                stek[i].Font = new Font("Microsoft Sans Serif", panel.Size.Height / 22);
            }
        }

        public async Task rdAn(int a, Panel panel, List<Button> stek, List<string> stek_string, List<bool> stek_done, Form form) //удаление элементов и стека
        {


            await Task.Delay(1);
            {

                while (stek_done.Contains(false))
                {

                    await Task.Delay(1);
                }
                for (int i = 0; i < a; i++)
                {
                    panel.Controls.Remove(stek[stek.Count - 1]);
                    stek.RemoveAt(stek.Count - 1);
                    stek_done.RemoveAt(stek_done.Count - 1);
                    stek_string.RemoveAt(stek_string.Count - 1);

                }

                animationsD(panel, stek, stek_string, stek_done);
            }
        }
        public void animationsD(Panel panel, List<Button> stek, List<string> stek_string, List<bool> stek_done) //анимации для движения созданных элементов (которые до нажатия кнопки создания уже существовали)
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = stek.Count;
            for (var i = stek.Count - 1; i >= 0; i--)
                move(stek[i].PointToScreen(Point.Empty), new Point((int)(x - (x / (count + 1) * (i + 1))) - stek[i].Size.Width, 
                    (int)(y / 2) - stek[i].Size.Height), stek[i], i, panel, stek, stek_string, stek_done);
        }
        public async void moveDown(Point from, Point to, Button button, int i, int eof, Panel panel, 
            List<Button> stek, List<string> stek_string, List<bool> stek_done) // анимации удаления элементов
        {
            stek_done[i] = false;


            while (Math.Abs(button.Location.Y - to.Y) > panel.Size.Height / 10)
            {
                if (button.Location.Y < to.Y)

                    await Task.Delay(timeDelay);

                button.Location = new Point(button.Location.X, button.Location.Y + (button.Location.Y < to.Y ? +speed : -speed));

            }

            while (Math.Abs(button.Location.X - to.X) > panel.Size.Width / 15)
            {
                await Task.Delay(timeDelay);
                button.Location = new Point(button.Location.X + (button.Location.X < to.X ? +speed : -speed), button.Location.Y);

            }

            stek_done[i] = true;

        }
    }
}*/
