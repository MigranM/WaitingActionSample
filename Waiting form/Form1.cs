using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Waiting_form
{
    public partial class Form1 : Form
    {
        //задача заключалась в том, чтобы показать пользователю, что загрузка его данных все еще выполняется, но при этом не создавать ложное впечатление, что форма не отвечает, и не давать ему возможность выполнять некоторые действия
        //например запретить ему запустить еще одну загрузку данных, но при этом оставить возможность пользоваться другими элементами управления (в действительности управление параметрами поиска и прочее)
        public Form1()
        {
            InitializeComponent();
            label2.Hide();
                
        }
        private async void button1_Click(object sender, EventArgs e) //ставим метод в async чтобы иметь доступ к await
        {
            button1.Enabled = false; //делаем необходимые действия к контролам
            label2.Show(); //отображение того, что идет выполнение некоторых действий
            await Task.Run(() => //запуск неких тяжелых действий с ключевым словом await
            {
                for (int i = 0; i < 10000; i++)
                {
                    for (int j = 0; j < 100000; j++)
                    {
                        double c = Math.Sqrt(i * j); //"тяжелые" действия (в действительности загрузка данных из базы в dataGridView)
                    }
                }
            });
            label2.Hide(); //убираем отображение
            button1.Enabled = true;
        }
        
    }
}
