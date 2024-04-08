using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
namespace stek_Deque
{
    internal class Deque
    {
        public int t = 0;
        public int s = 0;
        public void ClearDeque(Panel panel, System.Windows.Forms.Label label, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done)
        {

            panel.Controls.Clear();
            Deque.Clear();
            Deque_string.Clear();
            Deque_done.Clear();
            label.Text = "Дек не создан";
        }
        public bool check(List<bool> _done)
        {
            if (_done.Contains(false))
            {
                MessageBox.Show("Подождите завершения задачи.");
                return true;
            }
            return false;
        }
        public async void creator(string[] str, Panel panel, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Deque_string.Add(str[i]);
                Deque_done.Add(false);
                Deque.Add(new Button
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
                panel.Controls.Add(Deque[Deque.Count - 1]);
            }
            animations(panel, Deque, Deque_string, Deque_done);
        }
        public async void creator(string[] str, Panel panel, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done, bool a)
        {
            for (int i = 0 ; i < str.Length; i++)
            {
                Deque_string.Insert(0,str[i]);
                Deque_done.Insert(0,false);
                Deque.Insert(0,new Button
                {
                    Location = new Point(panel.Width - 15,  100),
                    Text = str[i],
                    Size = new Size(panel.Size.Width / 14, panel.Size.Height / 10),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left,
                    Font = new Font("Microsoft Sans Serif", panel.Size.Height / 22),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Black,
                    ForeColor = Color.White,


                }
                    );
                panel.Controls.Add(Deque[0]);
            }
            animations(panel, Deque, Deque_string, Deque_done, false);
        }
        public async void animations(Panel panel, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done, bool a)
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = Deque.Count;
            for (var i = Deque.Count -1; i >=0  ; i--)
            {

                move(Deque[i].PointToScreen(Point.Empty), new Point((int)(x - (x / (count ) * (i + 1))), (int)(y / 2)), Deque[i], i, panel, Deque, Deque_string, Deque_done);
                await Task.Delay(800);

            }
        }

        public async void Loader(string[] str, Panel panel, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Deque_string.Add(str[i]);
                Deque_done.Add(true);
                Deque.Add(new Button
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
                panel.Controls.Add(Deque[Deque.Count - 1]);
            }
            Pos(panel, Deque);
        }
        public async void animations(Panel panel, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done)
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = Deque.Count;
            for (var i = 0; i < Deque.Count; i++)
            {

                move(Deque[i].PointToScreen(Point.Empty), new Point((int)(x - (x / (count + 1) * (i + 1))), (int)(y / 2)), Deque[i], i, panel, Deque, Deque_string, Deque_done);
                await Task.Delay(800);

            }
        }


        public async void move(Point from, Point to, Button button, int i, Panel panel, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done)
        {
            Deque_done[i] = false;
            while (Math.Abs(button.Location.Y - to.Y) > panel.Size.Height / 10)
            {
                if (button.Location.Y < to.Y)
                    await Task.Delay(t);

                button.Location = new Point(button.Location.X, button.Location.Y + (button.Location.Y < to.Y ? +s : -s));

            }
            while (Math.Abs(button.Location.X - to.X) > panel.Size.Width / 15)
            {
                await Task.Delay(t);
                button.Location = new Point(button.Location.X + (button.Location.X < to.X ? +s : -s), button.Location.Y);

            }
            Deque_done[i] = true;


        }

        public void Pos(Panel panel, List<Button> Deque)
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = Deque.Count;
            for (var i = Deque.Count - 1; i >= 0; i--)
            {
                Deque[i].Size = new Size(panel.Size.Width / 14, panel.Size.Height / 10);
                Deque[i].Location = new Point((int)(x - (x / (count) * (i + 1))) - Deque[i].Size.Width, (int)(y / 2) - Deque[i].Size.Height);
                Deque[i].Font = new Font("Microsoft Sans Serif", panel.Size.Height / 22);
            }
        }

        public async Task rdAn(int a, Panel panel, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done, Form form)
        {


            await Task.Delay(1);
            {

                while (Deque_done.Contains(false))
                {

                    await Task.Delay(1);
                }
                for (int i = 0; i < a; i++)
                {
                    panel.Controls.Remove(Deque[0]);
                    Deque.RemoveAt(0);
                    Deque_done.RemoveAt(0);
                    Deque_string.RemoveAt(0);

                }

                animationsD(panel, Deque, Deque_string, Deque_done);
            }
        }
        public void animationsD(Panel panel, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done)
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = Deque.Count;
            for (var i = Deque.Count - 1; i >= 0; i--)
                move(Deque[i].PointToScreen(Point.Empty), new Point((int)(x - (x / (count) * (i + 1))) - Deque[i].Size.Width, (int)(y / 2) - Deque[i].Size.Height), Deque[i], i, panel, Deque, Deque_string, Deque_done);
        }
        public async void moveDown(Point from, Point to, Button button, int i, int eof, Panel panel, List<Button> Deque, List<string> Deque_string, List<bool> Deque_done)
        {
            Deque_done[i] = false;


            while (Math.Abs(button.Location.Y - to.Y) > panel.Size.Height / 10)
            {
                if (button.Location.Y < to.Y)

                    await Task.Delay(t);

                button.Location = new Point(button.Location.X, button.Location.Y + (button.Location.Y < to.Y ? +s : -s));

            }

            while (Math.Abs(button.Location.X - to.X) > panel.Size.Width / 15)
            {
                await Task.Delay(t);
                button.Location = new Point(button.Location.X + (button.Location.X < to.X ? +s : -s), button.Location.Y);

            }

            Deque_done[i] = true;

        }
    }
}
*/