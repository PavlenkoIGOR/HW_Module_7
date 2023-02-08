using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Композиция
 */
namespace _769
{
    class Person<T> where T : Vehicle  // хотя здесь можно и без обобщений
    {
        public string Name;
        private string serialEngine;
        public T vehicle;
        public string number;
        public Person(string name, T vehicle, string number, string serialEngine)
        {
            Console.WriteLine("asdfhgj");
            this.vehicle = vehicle;
            this.number = number;
            this.serialEngine = serialEngine;
            Name = name;
        }
    }
    abstract class Motor
    {
        public int Power;
        public double V;
        public virtual void EngineSound()
        {
            Console.WriteLine("Двигатель как-то работает");
        }
    }
    class Motor1 : Motor
    {
        public Motor1(int Power, double V)
        {
            this.Power = Power;
            this.V = V;
        }
        public override void EngineSound()
        {
            Console.WriteLine("Двигатель звучит Бррррррррум");
        }
    }
    class Motor2 : Motor
    {
        public Motor2(int Power, double V)
        {
            this.Power = Power;
            this.V = V;
        }
        public override void EngineSound()
        {
            Console.WriteLine("Двигатель звучит ВЖЖЖЖЖЖЖЖ");
        }
    }
    class Wheels
    {
        public int Diametr;
        public int Width;
    }
    class Vehicle
    {
        protected class Milesage
        {
            public double miles;
        }
        public static int wheelsQuantity; //Обращение к static  элементу делается через название класса.
        private string _marka;
        public string Marka
        {
            get
            {
                return $"Марка: \t\t{_marka}";
            }
            set
            {
                _marka = value;
            }
        }
        private string _model;
        public string Model
        {
            get
            {
                return $"Модель: \t{_model}";
            }
            set
            {
                _model = value;
            }
        }
        public int Year;
        public double _100km_h;
        /// <summary>
        /// агрегация
        /// </summary>
        public Motor Motor;
        /// <summary>
        /// композиция
        /// </summary>
        public Wheels wheels = new Wheels();
        public Vehicle(int diametr, int width)
        {
            wheels.Diametr = diametr;
            wheels.Width = width;
        }
    }
    class BaseOfPersons
    {
        public Person<Vehicle>[] collection;
        public BaseOfPersons(Person<Vehicle>[] collection)
        {
            this.collection = collection;
        }
        public void ShowInfo()
        {
            for (int i = 0; i < collection.Length; i++)
            {
                Console.WriteLine($"Владелец: \t{collection[i].Name}");
                Console.WriteLine($"Гос. номер: \t{collection[i].number}");
                Console.WriteLine($"{collection[i].vehicle.Marka}");
                Console.WriteLine(collection[i].vehicle.Model);
                Console.WriteLine($"Мощность: \t{collection[i].vehicle.Motor.Power} л.с.");
                Console.WriteLine($"Объём: \t\t{collection[i].vehicle.Motor.V} л.");
                Console.WriteLine($"Год выпуска: \t{collection[i].vehicle.Year} год");
                Console.WriteLine($"c 0 до 100км/ч: {collection[i].vehicle._100km_h} с.");
                Console.WriteLine($"Колеса: \t{collection[i].vehicle.wheels.Diametr}''");
                Console.WriteLine($"Ширина колес: \t{collection[i].vehicle.wheels.Width}мм");

                Console.WriteLine();
            }
        }
    }
    internal class HW_Module_7
    {
        static void Main(string[] args)
        {
            //---------Павленко Игорь---------//
            Motor1 motor1 = new Motor1(600, 8.4);
            Motor2 motor2 = new Motor2(510, 8.3);

            Vehicle viper = new Vehicle(19, 275);
            viper.Marka = "Dodge";
            viper.Model = "Viper";
            viper._100km_h = 3.4d;
            viper.Year = 2018;
            Vehicle.wheelsQuantity = 4;
            viper.Motor = motor1;
            string namePavlenko = "Павленко Игорь";
            string gosNumberPavlenko = "A001AA";
            string serialEnginePavlenko = "XXX123QWERTY345XX";
            Person<Vehicle> Pavlenko = new Person<Vehicle>(namePavlenko, viper, gosNumberPavlenko, serialEnginePavlenko);
            //---------Иванов Иван---------//
            Motor1 motorPriora = new Motor1(106, 1.6);
            Vehicle priora = new Vehicle(15, 195);
            priora.Marka = "LADA";
            priora.Model = "Priora";
            priora._100km_h = 11.5d;
            priora.Year = 2014;
            priora.Motor = motorPriora;
            string nameIvanov = "Иванов Иван";
            string gosNumberPriora = "Е000КХ";
            string serialEnginePriora = "CCQ773ASDFY543QQ";


            Person<Vehicle>[] collection = new Person<Vehicle>[] {
                                                                    new Person<Vehicle>(namePavlenko, viper, gosNumberPriora, serialEnginePriora),
                                                                    new Person<Vehicle>(nameIvanov, priora, gosNumberPriora, serialEnginePriora)
                                                                 };

            ///Pavlenko
            Console.WriteLine("\t\tПавленко Игорь владеет автомобилем: \n{0} \n{1} \nГос. номер: \t{2}", Pavlenko.vehicle.Marka, Pavlenko.vehicle.Model, Pavlenko.number);
            Console.WriteLine("\nТехнические характеристики: \n");
            Console.Write("Объём двигателя: \t   {0} л., ", Pavlenko.vehicle.Motor.V);
            Pavlenko.vehicle.Motor.EngineSound();
            Console.WriteLine("Мощность двигателя: \t   {0} л.с.", Pavlenko.vehicle.Motor.Power);
            Console.WriteLine("Разгон до 100км/ч: \t {0} с.", Pavlenko.vehicle._100km_h);
            Console.WriteLine("Год выпуска: \t\t   {0} г.в.", Pavlenko.vehicle.Year);
            Console.WriteLine("Двигатель 2ой модификации  {0} л.с. \n", motor2.Power);
            ///Ivanov ------------- вывод при помощи коллекции
            Console.WriteLine("\t\tИванов Иван владеет автомобилем: \n{0} \n{1} \nГос. номер: \t{2}", collection[1].vehicle.Marka, collection[1].vehicle.Model, collection[1].number);
            Console.WriteLine("\nТехнические характеристики: \n");
            Console.Write("Объём двигателя: \t   {0} л., ", collection[1].vehicle.Motor.V);
            collection[1].vehicle.Motor = motor2;
            collection[1].vehicle.Motor.EngineSound();
            Console.WriteLine("Мощность двигателя: \t   {0} л.с.", collection[1].vehicle.Motor.Power);
            Console.WriteLine("Мощность двигателя: \t   {0} л.с.", collection[1].vehicle.Motor.Power);
            Console.WriteLine("Разгон до 100км/ч:\t\t{0} с.", collection[1].vehicle._100km_h);
            Console.WriteLine("Год выпуска: \t\t   {0} г.в.", collection[1].vehicle.Year);

            BaseOfPersons baseOfPersons = new BaseOfPersons(collection);
            Console.WriteLine("\n------------вывод коллекции------------\n");
            baseOfPersons.ShowInfo();
            Console.ReadKey();
        }
    }
}


 
