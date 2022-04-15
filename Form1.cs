using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooSimulator
{
    public partial class Form1 : Form
    {
        // Делаем симулятор зоопарка. Разные животные - это разные Классы (ООП)
        // у них есть свои свойства разные (ХП,Голод,ЖАЖДА,количество лап,..)
        // есть кнопки управления - вызов событий и делегатов, функций Классов 
        // и Сохранения и Загрузки прогресса - работа с файлами
        // плюс Сохранение в "базу" - работа с SQL
        // используем Winwdows Forms для отображения результатов (текст и Изображения)
        // Животные как классы - сделаем и работу с наследованием и работу с Интерфейсами
        // при вызове событий - работа с разными массивами чтоб посмотреть их отличия
        //
//        1. Преобразования типов.Явные, неявные.Универсальный класс Object.
        //Сериализация в XML.
        //
//2. Работа с Гитхаб и ее важность. Заливка предыдущих написанных программ на гитхаб. Мердж, пулл, пуш реквесты. Как это все делать без консоли встроенными средствами Вижуал Студии.
//
//3. Типы значений и ссылочные (Value Reference). Boxing-unboxing. Null тип. Примеры.
//
//4. Методы: функции и процедуры. Массивы. Передача в функцию и получение данных из нее.
//
//5. Классы C#. Конструкторы. Роль понятий this, static. Примеры с зоопарком.
//
//6. ООП.Инкапсуляция, наследование, полиморфизм.Введение.
//
//7. Наследование.Protected, virtual, override. Роль интерфейсов.Примеры с зоопарком.
//
//8. Обработка исключений. Отслеживание StackTrace. Роль понятия finally.
//
//9. Работа с интерфейсами.Понятия as, is. Стандартный IEnumarable для циклов. Примеры с зоопарком.
//
//10. Коллекции.List, Dictionary, stack, очередь.Понятия FIFO, LIFO.
//
//11. Делегаты и их использование. Абстрактный реализатор функций.
//
//12. События и их использование. Подписки на события и их инициация.
//
//13. LINQ запросы. SQL запросы. Примеры с зоопарком.
//
//14. Время существования объектов.Сборка мусора. Сколько программа занимает в памяти?
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            class1.main();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string f = textBox1.Text;
            //преобразование строки в текст - парсинг
            //дробное число - по умолчанию через , а не через .
            float md = float.Parse(f);
            //второй способ это конвертация
            double dd = Convert.ToDouble(f);
            Class1 class1 = new Class1();
            //присваиваем полю класса переменную
            class1.myDouble = dd;
            //вызываем функцию у класса - тоже через . и функция должна быть public
            double res = class1.x2();
            MessageBox.Show(res.ToString());
            //ДЗ : сохранить класс class1 в файл используя XML Writer 
            //15.04 ДЗ остается. как делать: https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/serialization/how-to-write-object-data-to-an-xml-file
            //

            
        }
        /// <summary>
        /// У функции есть название (имя фукнции) - AddStringAndnumber
        /// есть тип результата который она вернет - string
        /// и в скобках есть параметры с которыми она работает, строка и число
        /// </summary>
        /// <param name="instring">строка</param>
        /// <param name="innumber">чиcло</param>
        /// <returns>строка пробел число</returns>
        public string AddStringAndnumber(string instring, int innumber)
        {
            string result = instring + " " + innumber.ToString();
            return result;
        }
        public string i(string name, string surname, int chis)
        {
            string resalt = name + " " + surname + " " + chis.ToString() + " ";
            return resalt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //массивы. процедуры и функции.
            // выозвы Convert.ToDouble и прочие MessageBox.Show это функции встроенные в сам язык
            // мы сделаем фукнции по работе с массивами
            // сделаем функцию строки и числа
            string name = "matvei";
            string surname = "familia";
            int chis = 987;
            //MessageBox.Show(AddStringAndnumber(name, chis));
            MessageBox.Show(i(name, surname, chis));
            //про массивы - набор одинаковых по типу элементов
            //у С# много встроенных в язык возможнестей по работе с массивами - сортировка, длина
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i * 2;
            }
            //встроенная сортировка
            arr.OrderBy(x => x);

            Class1[] arrclass = new Class1[5];
            for (int i = 0; i < arrclass.Length; i++)
            {
                arrclass[i] = new Class1();
                arrclass[i].myDouble = i * 3.3;
             }
            //список где может быть сколько угодно элементов
            List<int> lst = new List<int>();
            for (int i = 0; i < 7; i++)
            {
                lst.Add(i * 2);
            }
            lst.Sort();
            //фукнция по работе с массивом
            var res = listx5(lst);
            for (int i = 0; i < res.Count; i++)
            {
                MessageBox.Show( res[i].ToString() );
            }
        }
        //функция по рботе со списком List<int> lst, умножает на 5 
        public List<int> listx5(List<int> lst)
        {
            //второй список куда мы складываем результат, с таким же размером как lst
            List<int> vs = new List<int>(lst.Count);

            for(int sc = 0;sc < lst.Count; sc++)
            {
                vs.Add(  lst[sc] * 5);
            }
            return vs;
        }
    }
}
