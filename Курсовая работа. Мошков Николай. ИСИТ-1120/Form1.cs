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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* 
            Добавить фичи:
                1. Ручной ввод данных массива: нужно определить как будет происходить ввод,
                   как будет приминматься, расширить функционал методов для этой фичи
                2. Выгрузка вычисленных показателей в файл/созданную директиву/готовую дире-
                   ктику Data в виде файла/текстового файла; Сделать оповедение об этом;
                   Сделать условие, проверяющие успешность сохранине файла (если понадобиться)
                3. Импорт базы данных/массива чисел из файла/таблицы и т.д.; Выбрать типы файлов
                   для загрузки, добавить об этом в подсказку
             (?)4. Изменить подсказку(возможное, вероятные, на выбор): добавить название для окна;
                   сделать окно формой с создаваемыми элементами; изменить надпись кнопки, вызывающей её
                5. Изменить структуру запуска программы: при запуске будет появлятьяс форма, что содержит
                   кнопки, лейблы, будет дан выбор - ручной ввод, импорт, случайный генератор массива чисел
        */
        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            listBox1.Items.Clear(); // 525; 364

            int N = rand.Next(3, 50); 
            int[] data = new int[N],
                  modas_data = new int[N]; 

            RandomFull_ListBox(data);

            // Среднее арефметическое значение - сумма чисел поделеная на их количество\\
            label2.Text = $"Среднее арифметическое массива: {Average(data)}";
            // Мода - наиболее часто встречающиеся число \\\
            if (Mode(data) != 0)
                label3.Text = $"Мода массива: {Mode(data)} ";
            else
                label3.Text = "Моды нет";
            // Медиана - число, находящиеся на одинаковом от конца расстоянии \\
            if (N % 2 == 0)
                label4.Text = $"Медиана массива: {Convert.ToDouble((data[N / 2] + data[(N / 2) - 1]) / 2)}";
            else
                label4.Text = $"Медиана массива: {data[N / 2]}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Задача программы - нахождение средних статических показателей среди случайных чисел: Среднего значения, моды, медианы\n" +
                "\n Среднее значение - сумма всех чисел массива поделенная на их общее количество" +
                "\n Мода - наиболее часто встречающееся число в массиве" +
                "\n Медиана - число, находящиея на одинаковом расстоянии в массиве от его начала и конца");
        }

        // Заполненить массив случайными числами
        void RandomFull_ListBox(int[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-20, 20);
                listBox1.Items.Add(array[i]);
            }
        }

        // Нахождение среднего арифметическоого значения
        static double Average(int[] array)
        {
            double sum = 0;
            foreach (int elem in array)
                sum += elem;
            return Math.Round(sum /= array.Length, 2);
        }

        // Нахождение моды - число, что чаще всего встречается в массиве
        static int Mode(int[] array)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int elem in array)
            {
                if (dict.ContainsKey(elem))
                    dict[elem]++;
                else
                    dict[elem] = 0;           
            }

            int maxCount = 0;
            int mode = 0;
            foreach (int elem in dict.Keys)
            {
                if (dict[elem] > maxCount)
                {
                    maxCount = dict[elem];
                    mode = elem;
                }
            }

            int c = 0;
            foreach (int elem in dict.Values)
            {
                if (elem != 1)
                    c++;
            }

            if (c != 0)
                return mode;
            else
                return 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.Owner = this;
            form2.ShowDialog();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
