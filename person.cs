using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ZooSimulator
{
    public enum VUZ
    {
        BMSTU,
        MSU,
        HSE,
        MIFI,
        FIZTEH,
        SPBGU
    }
    public class person
    {
        public string fio = "";
        public int YearBirth = 0;
        public int YearGraduate = 0;
        public VUZ vuzz;
        public void GenVuz(Random rnd)
        {
            int vuz = rnd.Next(1, 6);
            if (vuz == 1) vuzz = VUZ.BMSTU;
            if (vuz == 2) vuzz = VUZ.MSU;
            if (vuz == 3) vuzz = VUZ.HSE;
            if (vuz == 4) vuzz = VUZ.MIFI;
            if (vuz == 5) vuzz = VUZ.FIZTEH;
            if (vuz == 6) vuzz = VUZ.SPBGU;
            //Задание 1 - дописать выбор вуза

        }
        public void init()
        { }
        public person()
        {
            Random rnd = new Random();
            GenVuz(rnd);
            YearBirth = 1990;
            YearGraduate = 2015;
            generateName(rnd);
        }
        public person(Random rnd, int year, int grad)
        {

            GenVuz(rnd);
            YearBirth = year;
            YearGraduate = grad;

            generateName(rnd);

        }
        public person(Random rnd, List<string> names, bool nameFromFile = true)
        {

            GenVuz(rnd);

            if (nameFromFile)
            {
                NameFromFile(rnd, names);
                YearBirth = rnd.Next(1980, 2000);
                YearGraduate = YearBirth + rnd.Next(20, 25);
            }
            else
            {
                generateName(rnd);
            }
        }
        public override string ToString()
        {
            return fio + " Y=" + YearBirth + " G=" + YearGraduate + " Vuz=" + vuzz.ToString();
        }
        public static List<string> GetNames()
        {
            string path = @"C:\names\name_rus.txt";
            //1) открыть файл
            //2) прочитать из него все строки (имена) 1988 шт
            //3) случайно выбрать из этих имен 1
            //4) записать имя в поле класса
            String line;

            //Pass the file path and file name to the StreamReader constructor
            //проблема: кодировка файла ANSI - надо преобразовать в UTF8 (unicode)
            var ansi = Encoding.GetEncoding(1251);
            StreamReader sr = new StreamReader(path, ansi);
            List<string> names = new List<string>();
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                
                //добавить в список
                names.Add(line);
                //Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();

            return names;
        }
        public void NameFromFile(Random rnd, List<string> names)
        {

            int count = names.Count;
            //Random rnd = new Random();
            int nm = rnd.Next(0, count - 1);
            string namee = names[nm];
            //Console.ReadLine();
            fio = namee;

        }
        public void generateName(Random random)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int ch = random.Next(65, 89);
                sb.Append(((char)ch).ToString());
            }
            fio = sb.ToString();

        }
        //задание 2 - написать функцию инициализации , 3 штуки
        //1 - по умолчанию задает параметры и генерирует имя (взять из зоопарка)
        //2 - задает из параметров в скобках
        //3 - берет имя из файла с именами который скачан, год рождения случайно от 1980 до 2000
        //
        //Задание 3 - создать штук 100-1000 таких персон, с 3 функцией инициализации, выбрать и вывести
        //тех у кого имя начинается на "м"
    }
}
