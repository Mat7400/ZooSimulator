using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimulator
{
    //Интерфейс с функциями говорить и изменить голод.
    //реализовывает полиморфизм. то есть эти функции реализуются по-своему в каждом классе
    //Интерфейс только определяет 1)возвращаемый тип функции - int
    //2)название функции ChangeHunger 3) и ее параметры Random rnd
    //то есть во всех классах Кошка, Собяка, Хомяк 
    //код внутри функций свой но название, тип и параметры одинаковые.
    public interface TalkingAnimal
    {
        string Talks();
        int ChangeHunger(Random rnd);
    }
    public class testAnimal
    {
        //эти параметры задаются по умолчанию при создании класса, потом меняются в конструкторе
        public string name = "";
        public bool hasTail = false;
        public bool canFLY = true;
        public int numberPaws = 2;
        //голод. если дойдет до 100, умирает
        public int hunger = 0;
        public bool isAlive = true;
        //делегат - указатеь на любая функция которая принимает 2 чиса и строку
        public delegate int OnAdd(int x, int y, string name);
        //название события
        public event OnAdd Adding;
        

        public void generateName(Random random)
        {
            

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int ch = random.Next(65, 89);
                sb.Append( ((char)ch).ToString() );
            }
            name = sb.ToString();
            //вызываем событие с аргументами
            if (Adding != null) Adding(1, 2, name); 

            //paws
            numberPaws = random.Next(1, 4);
        }
        /// <summary>
        /// конструктор - специальная функция которая при создании класса позволяет
        /// заполнить его поля и сделать проверки входных данных
        /// </summary>
        /// <param name="incName">имя</param>
        /// <param name="iTail">хвост</param>
        /// <param name="Fly">полет</param>
        /// <param name="paws">лапы количество</param>
        public testAnimal(string incName, bool iTail, bool Fly, int paws)
        {
            if (paws >= 8) System.Windows.Forms.MessageBox.Show("BEWARE OF SPIDER");
            //кусок кода 1 - выводится первым
            if (Fly) System.Windows.Forms.MessageBox.Show("IT CAN FLY");

            if (paws <= 1)
            {
                Exception ex = new Exception("no work with such animals");
                throw ex;
            }

            hasTail = iTail;
            canFLY = Fly;
            numberPaws = paws;
            name = incName;
        }
        public testAnimal()
        { 
            //пустой констуктор по умолчанию
            //такое же название но нет параметров в () - другой кусок кода
        }
        public string BaseStr()
        {
            return name + " " + numberPaws.ToString();
        }
        public override string ToString()
        {
            return name + " hunger " + hunger.ToString();
        }
        public string saySmth()
        {
            return "not definded";
        }
        
    }
    /// <summary>
    /// класс кошки наследуется от Животного. кроме базовых 4 признаков и функции 
    /// добавляется свой признак poroda и функция meow
    /// </summary>
    public class Cat : testAnimal, TalkingAnimal
    {
        //деегат - функция принимащая строку
        public delegate void OnMeow(string m);
        //событие - кошка очет мяукнуть
        public event OnMeow WantMeow;

        public string poroda = "";
        //инкапсуляция - принцип ООП. скрываем детали реализации (инкапсулируем их в приватные 
        //функции) как бы засовывем в капсулу.
        private int getChange(Random rnd)
        {
            int change = 5;

            return rnd.Next(-change / 2, change);
        }
        public int ChangeHunger(Random rnd)
        {
            hunger += getChange(rnd);
            if (hunger < 1)
            {
                hunger = 1;
            }
            return hunger;
        }

        public string meow()
        {
            //вызываем событие
            if (WantMeow != null) WantMeow("meowwq");

            return "MEOW";
        }

        public string Talks()
        {
            return "MEOW";
        }
    }
    /// <summary>
    /// класс собаки наследуется от Животного. кроме базовых 4 признаков и функции 
    /// добавляется 2 своих признак VetPasport и naskolkoKrasivaya и функция гаф
    /// </summary>
    public class Dog: testAnimal, TalkingAnimal
    {
        public string VetPasport = "";
        public int naskolkoKrasivaya = 100;
        public Dog()
        {
            VetPasport = "OK";
        }
        public Dog(int krasota)
        {
            if (krasota<10)
            {
                System.Windows.Forms.MessageBox.Show(" NE MILAYA");
            }
            naskolkoKrasivaya = krasota;
        }
        //вызываем базовый констуктор
        public Dog(int krasota, string myvetpasport, string incName, int paws, bool fly) 
            : base(incName,true,fly,paws)
        {
            //кусок кода 2 - выводится после базового констуктора класса testAnimal
            if (fly) System.Windows.Forms.MessageBox.Show("DOGS can't FLY");

            if (krasota < 10)
            {
                //проверки входных параметров позволяет их обработать
                System.Windows.Forms.MessageBox.Show(" NE MILAYA");
            }
            naskolkoKrasivaya = krasota;
            VetPasport = myvetpasport;

        }

        public int ChangeHunger(Random rnd)
        {
            int change = 8;

            hunger += rnd.Next(-change/2, change);
            if (hunger < 1)
            {
                hunger = 1;
            }
            return hunger;
        }

        public string gaf()
        {
            return name + " says gaf-gaf";
        }

        public string Talks()
        {
            return " gaf-gaf";
        }
    }
    //ДЗ до 22.04: сделать класс хомячка с признаком насколько пушистый от 1 до 100
    //и фукнцией пищать
    /// <summary>
    /// класс Хомяк наследуется от Животного. кроме базовых 4 признаков и функции 
    /// добавляется свой признак пушистость и функция пищание
    /// </summary>
    public class Hamster : testAnimal , TalkingAnimal
    {
        /// <summary>
        /// пушистость. при создании класса Хомяка она задается в 1 первым деом.
        /// </summary>
        public int pushistost = 1;
        public string sqeek()
        {
            return "hamster says pipipi";
        }

        public string Talks()
        {
            return "pipipi";
        }

        public int ChangeHunger(Random rnd)
        {
            int change = 4;

            hunger += rnd.Next(-change/2, change);
            if (hunger < 1)
            {
                hunger = 1;
            }
            return hunger;
            
        }

        public Hamster()
        {
            //в базовом коснтрукторе - нет параметров, все по умолчанию
            pushistost = 100;
        }
        public Hamster(int push)
        {
            if (push < 10)
            {
                System.Windows.Forms.MessageBox.Show(" Лысый ");
            }
            pushistost = push;
        }
        //вызываем базовый констуктор
        public Hamster(int push, string incName, bool fly)
            : base(incName, false, fly, 4)
        {
            //кусок кода 2 - выводится после базового констуктора класса testAnimal
            if (fly)
            {
                //Исключения. 1/0 или 4999555777 + 4999555777
                //нестандартное поведение программы когда может быть ошибка
                //программа может полностью прекратить работу
                //чтобы продложить работу программы такие ошибки можно "ловить" - try {} catch{}
                throw new Exception("Hamster can't FLY");
                //System.Windows.Forms.MessageBox.Show("Hamster can't FLY");
            }

            if (push < 10)
            {
                System.Windows.Forms.MessageBox.Show(" Лысый ");
            }
            pushistost = push;
            

        }
    }
}
