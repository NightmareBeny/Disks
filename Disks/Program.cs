using System;
using static System.Console;
using System.Collections.Generic;

namespace Disks
{
    abstract class Storage
    {
        protected string Name { get; set; }
        protected string Model { get; set; }
        public Storage(string name, string model)
        {
            Name = name; Model = model;
        }
        protected abstract void Memory();
        //передаём объём копируемых файлов и единицы измерения
        public abstract void Copy(double value, string name);
        protected abstract void FreeMemory();
        public abstract void GetInfo();
        protected void Line()
        {
            WriteLine("============================================\n");
        }
    }

    //заданиие конструктора базового класса, вызываемого при создании экземпляров производного класса
    class Flash : Storage
    {
        public double Free { get; set; }= 549755813888;//549 755 813 888 бит(объём);
        private long speedUSB3_0 = 42949672960;//42 949 672 960 Бит(скорость)
        public Flash(string name, string model) : base(name, model)
        {

        }

        protected override void Memory()
        {
            WriteLine("Общий объём информации: 64 Гб");
        }

        public override void Copy(double value, string name)
        {
            switch(name)
            {
                case "бит":
                    Free -= value;
                    break;
                case "б":
                    value *= 8;
                    Free -= value;
                    break;
                case "Кб":
                    value *= 8; value *= 1024;
                    Free -= value;
                    break;
                case "Мб":
                    value *= 8; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                case "Гб":
                    value *= 8; value *= 1024; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                default:
                    WriteLine("Извините, неверно указан тип данных\nОбратите внимание на пример ввода единиц измерения");
                    return;
            }
                WriteLine($"Скопировано удачно!\nВремя: {value / speedUSB3_0} сек");
                FreeMemory();
        }

        protected override void FreeMemory()
        {
            Free /= 8;
            Free /= 1024;
            Free /= 1024;
            Free /= 1024;
            WriteLine($"Свободное место на диске: {Free} Гб");
            Free *= 1024;
            Free *= 1024;
            Free *= 1024;
            Free *= 8;
        }

        public override void GetInfo()
        {
            WriteLine("\nНазвание устройства: " + Name);
            WriteLine("Модель устройства: " + Model);
            Memory();
            FreeMemory();
            WriteLine("Скорость интерфейса: 5 Гб");
            Line();
        }
    }
    abstract class DVD : Storage
    {
        public double Free { get; set; }
        protected long speed = 176947200;//176 947 200бит
        public DVD(string name, string model) : base(name, model)
        {

        }
    }
    class SingleSidedDVD : DVD
    {
        public SingleSidedDVD(string name, string model) : base(name, model)
        {
           Free = 40372692582;//40 372 692 582
        }

        protected override void Memory()
        {
            WriteLine("4.7 Гб");
        }

        public override void Copy(double value, string name)
        {
            switch (name)
            {
                case "бит":
                    Free -= value;
                    break;
                case "б":
                    value *= 8;
                    Free -= value;
                    break;
                case "Кб":
                    value *= 8; value *= 1024;
                    Free -= value;
                    break;
                case "Мб":
                    value *= 8; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                case "Гб":
                    value *= 8; value *= 1024; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                default:
                    WriteLine("Извините, неверно указан тип данных\nОбратите внимание на пример ввода единиц измерения");
                    return;
            }
            WriteLine($"Скопировано удачно!\nВремя: {value / speed} сек");
            FreeMemory();
        }

        protected override void FreeMemory()
        {
            Free /= 8;
            Free /= 1024;
            Free /= 1024;
            Free /= 1024;
            WriteLine($"Свободное место на диске: {Free} Гб");
            Free *= 1024;
            Free *= 1024;
            Free *= 1024;
            Free *= 8;
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model + " однослойный односторонний");
            Memory();
            FreeMemory();
            WriteLine("Скорость чтения/записи: 21,09 Мб/с");
            Line();
        }
    }
    class TwoWayDVD : DVD
    {
        public TwoWayDVD(string name, string model) : base(name, model)
        {
            Free = 77309411328;//77 309 411 328 бит
        }

        protected override void Memory()
        {
            WriteLine("9 Гб");
        }

        public override void Copy(double value, string name)
        {
            switch (name)
            {
                case "бит":
                    Free -= value;
                    break;
                case "б":
                    value *= 8;
                    Free -= value;
                    break;
                case "Кб":
                    value *= 8; value *= 1024;
                    Free -= value;
                    break;
                case "Мб":
                    value *= 8; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                case "Гб":
                    value *= 8; value *= 1024; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                default:
                    WriteLine("Извините, неверно указан тип данных\nОбратите внимание на пример ввода единиц измерения");
                    return;
            }
            WriteLine($"Скопировано удачно!\nВремя: {value / speed} сек");
            FreeMemory();
        }

        protected override void FreeMemory()
        {
            Free /= 8;
            Free /= 1024;
            Free /= 1024;
            Free /= 1024;
            WriteLine($"Свободное место на диске: {Free} Гб");
            Free *= 1024;
            Free *= 1024;
            Free *= 1024;
            Free *= 8;
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model + " однослойный двусторонний");
            WriteLine("Общий объём информации: 9 Гб");
            Memory();
            FreeMemory();
            WriteLine("Скорость чтения/записи: 21,09 Мб/с");
            Line();
        }
    }
    //class HDD:Storage
    //{
    //    private long speedUSB2_0 = 4026531840;//4 026 531 840 бит(скорость)
    //    private string buf;//здесь будет храниться свободный память сразу ввиде строки, для более удобного вызова
    //    private int number = 2;//кол-во разделов
    //    public HDD(string name, string model) : base(name, model)
    //    {
    //        Tom[] mass = new Tom[number];
    //        for (int i = 0; i < number; i++)
    //            mass[i].Name = $"Tom{i++}";
    //    }
    //    public override void Memory()
    //    {
    //        WriteLine("128Гб");
    //    }

    //    public override void Copy(long value, string name)
    //    {
    //        //Через Split(' ') разделяем и передаём сюда
    //        //здесь всё преобразуем в бит
    //        //и занимаем freevolume
    //    }

    //    public override void FreeMemory()
    //    {
    //        //дописать перевод в единицы измерения, инициализация buf
    //        WriteLine((volume - freevolume));
    //    }

    //    public override void GetInfo()
    //    {
    //        WriteLine("Название устройства: " + Name);
    //        WriteLine("Модель устройства: " + Model + " однослойный двусторонний");
    //        WriteLine("Общий объём информации: 9 Гб");
    //        WriteLine("Свободное место: " + buf);
    //        WriteLine("Скорость чтения/записи: 21,09 Мб/с");
    //    }
    //}
    //class Tom
    //{
    //    private string name;
    //    public string Name { 
    //        get
    //        {
    //            return name;
    //        }
    //        set
    //        {
    //            name = value;
    //        }
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            List<Flash> flashes = new List<Flash>();
            flashes.Add(new Flash("MyFlash", "A103mb_0"));
            List<DVD> singlesidesdvds = new List<DVD>();
            List<DVD> twowaydvds = new List<DVD>();
            singlesidesdvds.Add(new SingleSidedDVD("MySingleDVD", "419569"));
            twowaydvds.Add(new TwoWayDVD("MyTwoWayDVD", "48288_8254a"));
            int choice;
            while (true)
            {
                //возврат в начало
                beg:
                WriteLine("Выберите цифру");
                WriteLine("1.Просмотреть информацию о доступных устройствах");
                WriteLine("2.Скопировать данные на устройства");
                WriteLine("3.Выход из программы");
                choice = Convert.ToInt32(ReadLine());
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            WriteLine("Выберите цифру устройства");
                            WriteLine("1.Flash-память");
                            WriteLine("2.DVD-диск");
                            WriteLine("3.Съёмный HDD");
                            WriteLine("4.Возврат в меню");
                            choice = Convert.ToInt32(ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    foreach (Flash flash in flashes)
                                    { flash.GetInfo(); }
                                    break;
                                case 2:
                                    foreach (SingleSidedDVD dvd in singlesidesdvds)
                                    { dvd.GetInfo(); }
                                    foreach (TwoWayDVD dvd in twowaydvds)
                                    { dvd.GetInfo(); }
                                    break;
                                case 3:
                                    break;
                                case 4: goto beg;
                                default: WriteLine("Извините, такой команды нет"); break;
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            WriteLine("Введите, какой объём информации будете копировать(например 102 Гб, 68 Мб, 10 Кб, 8 бит, 1024 б)");
                            var data = ReadLine();
                            string[] mass = data.Split(' ');
                            double number = Convert.ToDouble(mass[0]);
                            if (mass.Length == 2)
                            {
                                int id = flashes.Count; bool isfree = false;
                                for (int i = 0; i < flashes.Count; i++)
                                    if (flashes[i].Free != 0)
                                    { id = i; isfree = true; break; }
                                if (!isfree)
                                {
                                    flashes.Add(new Flash($"MyFlash{id}", $"A103mb_{id}"));
                                    while (number > 64 && mass[1]=="Гб")
                                    {
                                        flashes[id].Copy(64, "Гб"); id++; number -= 64;
                                        flashes.Add(new Flash($"MyFlash{id}", $"A103mb_{id}"));                                        
                                    }
                                    flashes[id].Copy(number, mass[1]);
                                }
                                else flashes[id].Copy(number, mass[1]);
                                break;
                            }
                            else WriteLine("Извините, неверно указан тип данных\nОбратите внимание на пример ввода единиц измерения"); 
                        }
                        break;
                    case 3:
                        return;
                    default: WriteLine("Извините, такой команды нет"); 
                        break;
                }
            }
        }
    }
}
