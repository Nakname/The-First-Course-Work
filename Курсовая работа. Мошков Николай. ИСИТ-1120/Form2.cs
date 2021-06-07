using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_работа.Мошков_Николай.ИСИТ_1120
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

            int N = 0;
        public void button1_Click(object sender, EventArgs e) 
        {
            Form2 form2 = new Form2();
            Form1 main = this.Owner as Form1;

            int[] numbers = new int[N];
            var textBox = new TextBox();
            var label = new Label();
            var btn = new Button();

            try
            {
                if (int.Parse(textBox1.Text) > 0)
                {
                    N = int.Parse(textBox1.Text);
                    int[] array = new int[N];
                }
                else
                {
                    MessageBox.Show("Введите положительное цисло");
                }

                this.Controls.Remove(label1);
                this.Controls.Remove(textBox1);
                this.Controls.Remove(button1);

                this.Size = new Size(600, 600);
                this.MinimumSize = new Size(200, 200);

                for (int i = 0; i < N; i++)
                {
                    this.Controls.Add(label = new Label() { Text = $"[{i + 1}] = ", Location = new Point(form2.Location.X + 10, form2.Location.Y + 27 * i) });
                    this.Controls.Add(textBox = new TextBox() { AutoSize = true, Location = new Point(form2.Location.X + 110, form2.Location.Y + 27 * i) });

                }

                btn.Text = "Добавить";
                btn.Font = new Font(label1.Font.Name, 10);
                btn.Size = new Size(100, 50);
                btn.Location = new Point(form2.Location.X + 250, form2.Location.Y + 15);
                this.Controls.Add(btn);

                btn.Click += new EventHandler();


            }
            catch (Exception)
            {
                MessageBox.Show("Вводите целые числа");
            }
            
        }
    }
}
