using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ZooSimulator
{
    public partial class Form1 : Form
    {
        
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
            Class1 myclass1 = new Class1();
            //присваиваем полю класса переменную
            myclass1.myDouble = dd;
            myclass1.myString = "XML serialization";
            //вызываем функцию у класса - тоже через . и функция должна быть public
            double res = myclass1.x2();
            MessageBox.Show(res.ToString());
            //ДЗ : сохранить класс class1 в файл используя XML Writer 
            //15.04 ДЗ остается. как делать: https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/serialization/how-to-write-object-data-to-an-xml-file
            //

            //создаем штуку которая преобразует наш класс Class1 в XML и называется она XmlSerializer
            //System.Xml.Serialization.XmlSerializer writer =
            //    new System.Xml.Serialization.XmlSerializer(typeof(Class1));
            ////путь к файлу
            //var path = "F:\\SerializationOverview.xml";
            ////создаем этот файл
            //System.IO.FileStream file = System.IO.File.Create(path);
            ////используем  XmlSerializer чтоб записать myclass1 в файл   
            //writer.Serialize(file, myclass1);
            //file.Close();
            saveToXml(typeof(Class1), myclass1);
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
            //сортировка списке
            lst.Sort();
            //фукнция по работе с массивом
            var res = listx5(lst);
            //for (int i = 0; i < res.Count; i++)
            //{
            //    MessageBox.Show( res[i].ToString() );
            //}
            //список строк
            List<string> lsts = new List<string>();
            //ДЗ от 15.04: заполнить список строк 7 строками bbb fff ddd ccc eee aaa
            //именно в таком порядке
            //сортировка этого списка и вывести его в мессаджбокс
            lsts.Add("bbb");
            lsts.Add("fff");
            lsts.Add("ccc");
            lsts.Add("ddd");
            lsts.Add("eee");
            lsts.Add("aaa");
            lsts.Sort();
            string resLst = "";
            foreach (var mystring in lsts)
            {
                resLst = resLst + " "+ mystring + " ";
            }
            MessageBox.Show(resLst);
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

        private void button3_Click(object sender, EventArgs e)
        {
            testAnimal dog = new testAnimal();
            dog.name = "ZARA";
            dog.numberPaws = 4;
            dog.hasTail = true;
            dog.canFLY = false;
            //ДЗ от 17.04 - сохранить собаку в файл XML
            //  F:\\SerializationOverview.xml
            //создаем штуку которая преобразует наш класс testAnimal в XML и называется она XmlSerializer
            saveToXml(typeof(testAnimal), dog);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //список чисел
            List<int> lstInt = new List<int>();
            Random random = new Random();
            lstInt.Add(random.Next(1, 100));
            lstInt.Add(random.Next(1, 100));
            lstInt.Add(random.Next(1, 100));
            lstInt.Add(random.Next(1, 100));
            lstInt.Add(random.Next(1, 100));
            lstInt.Add(random.Next(1, 100));
            lstInt.Add(random.Next(1, 100));
            //ДЗ от 17.04: заполнить список строк 7 случайными числами от 1 до 100
            //вывести список который получится до сортировки
            //сортировка этого списка и вывести его в мессаджбокс отсортированный
            string srtoka = "";
            for(int ccc = 0;ccc < lstInt.Count; ccc++)
            {
                srtoka += lstInt[ccc].ToString() + " ";
            }
            MessageBox.Show(srtoka);
            lstInt.Sort();
            //
            srtoka = "";
            for (int ccc = 0; ccc < lstInt.Count; ccc++)
            {
                srtoka += lstInt[ccc].ToString() + " ";
            }
            MessageBox.Show("SORTED:" +srtoka);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dog zara = new Dog();
            zara.name = "zara";
            zara.numberPaws = 4;
            zara.naskolkoKrasivaya = 100;
            zara.VetPasport = "vet zara ok";
            MessageBox.Show(zara.gaf());
            //создаем штуку которая преобразует наш класс testAnimal в XML и называется она XmlSerializer
            //System.Xml.Serialization.XmlSerializer writer =
            //    new System.Xml.Serialization.XmlSerializer(typeof(Dog));
            ////путь к файлу
            //var path = "F:\\SerializationOverviewDog2.xml";
            ////создаем этот файл
            //System.IO.FileStream file = System.IO.File.Create(path);
            ////используем  XmlSerializer чтоб записать dog в файл   
            //writer.Serialize(file, zara);
            //file.Close();
            saveToXml(typeof(Dog), zara);

            //есть класс собак Dog а есть его экземпляры (объекты этого класса) sharik и zara
            //у них названия полей (признаки) одинаковые а наполнение внутри разное
            Dog sharik = new Dog();
            sharik.name = "sharik";
            sharik.numberPaws = 4;
            sharik.naskolkoKrasivaya = 90;
            sharik.VetPasport = "vet sharik ok";

            //MessageBox.Show(sharik.gaf());
            Dog sharik2 = new Dog(5, "vet ok", "sharik2", 4, true);
            
        }
        public void saveToXml(Type saved, Object zara)
        {
            //создаем штуку которая преобразует наш класс testAnimal в XML и называется она XmlSerializer
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(saved);
            //путь к файлу
            var path = "F:\\save_"+saved.ToString()+".xml";
            //создаем этот файл
            System.IO.FileStream file = System.IO.File.Create(path);
            //используем  XmlSerializer чтоб записать dog в файл   
            writer.Serialize(file, zara);
            file.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //проверить конструкторы
            //int paws = Convert.ToInt32(textBox1.Text);
            //testAnimal f = new testAnimal("test",true,true,paws);
            //Hamster
            Random rnd = new Random();
            try
            {
                bool FLY = true;
                Hamster ham = new Hamster(rnd.Next(), "HOMA", FLY);
                //сохраннение в файл - уже готовая функция! удобно
                saveToXml(typeof(Hamster), ham);
            }
            catch (Exception ex)
            {
                // ловит ошибки (БАГИ)
                // что можно сделать: записать в ЛОГИ (текст) чтоб потом занть где исправить , 
                // показать пользователю Дружелюбно
                // можно продолжить программу и создать нормального хомяка

                //ДЗ 26.04  СОЗДАТЬ текстовый фалй с информацией об ошибке (записать все поля ex)
                //(показать код по полученю курса валют из инета)

                bool FLY = false;
                Hamster ham = new Hamster(rnd.Next(), "HOMA2", FLY);
                //сохраннение в файл - уже готовая функция! удобно
                //saveToXml(typeof(Hamster), ham);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //есть значит параметры и классы в файлах XML - их можно "при старте нашей программы"
            //из файлов загружать
            //можем сохранять животных и в Базе Данных SQL - задачи сохранить и загрузить те же
            string filep = "F:\\save_ZooSimulator.Hamster.xml";
            //XmlSerializer - превращает как классы в XML так и обратно из файла в класс C#
            //а например в паскале этого нет
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Hamster));
            //чтение из нашего хмл файла лежащего по пути filep
            System.IO.StreamReader file = new System.IO.StreamReader(filep);
            //читаем и из файла создаем хомяка с помощью Deserialize
            Hamster testH = (Hamster)reader.Deserialize(file);

            file.Close();
        }
        Random mainRnd = new Random();
        List<testAnimal> zoopark = new List<testAnimal>();
        private void button8_Click(object sender, EventArgs e)
        {
            //fill
            Cat cat = new Cat();
            cat.generateName(mainRnd);
            Dog dog = new Dog(100, "ok", "", 4, false);
            dog.generateName(mainRnd);
            Hamster ham = new Hamster(100, "", false);
            ham.generateName(mainRnd);
            zoopark.Add(cat);
            zoopark.Add(dog);
            zoopark.Add(ham);

            timer1.Interval = 7000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //вызывается каждый 30 секунд
            //у каждого животного голод изменяется на -10 сучайно
            //еси гоод 100 оно умирает
            //с вероятностью 1\10 может появиться новое ивотное
            //информация выводится в текст бокс
            //ДЗ: с вероятностью 1\10 может появиться новое животное - кошка
            //и ее надо добавить в список zoopark
            int koshka = mainRnd.Next(1, 10);

            foreach (var animal in zoopark)
            {
                int hunger = mainRnd.Next(-10, 10);
                animal.hunger += hunger;

                string who = "animal";
                if (animal is Cat)
                { who = "cat"; }
                if (animal is Dog)
                { who = "dog"; }
                if (animal is Hamster)
                { who = "hamster"; }

                textBoxProgress.Text += Environment.NewLine + " "+who+" " + animal.ToString();
                if (animal.hunger > 12)
                {
                    timer1.Stop();
                    MessageBox.Show("animal starve" + animal.ToString());
                }
            }
        }
    }
}
