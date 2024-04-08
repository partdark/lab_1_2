using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
namespace stek_queue
{
    internal class Queue
    {
        public int t = 0;
        public int s = 0;
        public void ClearQueue(Panel panel, System.Windows.Forms.Label label, List<Button> queue, List<string> queue_string, List<bool> queue_done)
        {

            panel.Controls.Clear();
            queue.Clear();
            queue_string.Clear();
            queue_done.Clear();
            label.Text = "Очередь не создана";
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
        public async void creator(string[] str, Panel panel, List<Button> queue, List<string> queue_string, List<bool> queue_done)
        {
            for (int i = 0; i < str.Length; i++)
            {
                queue_string.Add(str[i]);
                queue_done.Add(false);
                queue.Add(new Button
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
                panel.Controls.Add(queue[queue.Count - 1]);
            }
            animations(panel, queue, queue_string, queue_done);
        }

        public async void Loader(string[] str, Panel panel, List<Button> queue, List<string> queue_string, List<bool> queue_done)
        {
            for (int i = 0; i < str.Length; i++)
            {
                queue_string.Add(str[i]);
                queue_done.Add(true);
                queue.Add(new Button
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
                panel.Controls.Add(queue[queue.Count - 1]);
            }
           Pos(panel, queue);
        }
        public async void animations(Panel panel, List<Button> queue, List<string> queue_string, List<bool> queue_done)
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = queue.Count;
            for (var i = 0; i < queue.Count; i++)
            {

                move(queue[i].PointToScreen(Point.Empty), new Point((int)(x - (x / (count + 1) * (i + 1))), (int)(y / 2)), queue[i], i, panel, queue, queue_string, queue_done);
                await Task.Delay(800);

            }
        }


        public async void move(Point from, Point to, Button button, int i, Panel panel, List<Button> queue, List<string> queue_string, List<bool> queue_done)
        {
            queue_done[i] = false;
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
            queue_done[i] = true;


        }

        public void Pos(Panel panel, List<Button> queue)
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = queue.Count;
            for (var i = queue.Count - 1; i >= 0; i--)
            {
                queue[i].Size = new Size(panel.Size.Width / 14, panel.Size.Height / 10);
                queue[i].Location = new Point((int)(x - (x / (count + 1) * (i + 1))) - queue[i].Size.Width, (int)(y / 2) - queue[i].Size.Height);
                queue[i].Font = new Font("Microsoft Sans Serif", panel.Size.Height / 22);
            }
        }

        public async Task rdAn(int a, Panel panel, List<Button> queue, List<string> queue_string, List<bool> queue_done, Form form)
        {


            await Task.Delay(1);
            {

                while (queue_done.Contains(false))
                {

                    await Task.Delay(1);
                }
                for (int i = 0; i < a; i++)
                {
                    panel.Controls.Remove(queue[0]);
                    queue.RemoveAt(0);
                    queue_done.RemoveAt(0);
                    queue_string.RemoveAt(0);

                }

                animationsD(panel, queue, queue_string, queue_done);
            }
        }
        public void animationsD(Panel panel, List<Button> queue, List<string> queue_string, List<bool> queue_done)
        {
            var x = panel.Size.Width;
            var y = panel.Size.Height;
            var count = queue.Count;
            for (var i = queue.Count - 1; i >= 0; i--)
                move(queue[i].PointToScreen(Point.Empty), new Point((int)(x - (x / (count + 1) * (i + 1))) - queue[i].Size.Width, (int)(y / 2) - queue[i].Size.Height), queue[i], i, panel, queue, queue_string, queue_done);
        }
        public async void moveDown(Point from, Point to, Button button, int i, int eof, Panel panel, List<Button> queue, List<string> queue_string, List<bool> queue_done)
        {
            queue_done[i] = false;


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

            queue_done[i] = true;

        }
    }
}
*/