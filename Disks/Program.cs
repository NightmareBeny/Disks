using System;
using static System.Console;

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
        public abstract bool Copy(string value, string name);
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
        private long speedUSB3_0 = 42949672960;//42 949 672 960 Бит(скорость)
        private long volume = 549755813888;//549 755 813 888 Бит(общий объём)
        private double freevolume = 549755813888;//(свободный объём)
        public Flash(string name, string model) : base(name, model)
        {

        }

        protected override void Memory()
        {
            WriteLine("Общий объём информации: 64 Гб");
        }

        public override bool Copy(string value, string name)
        {
            double number = Convert.ToDouble(value);
            switch(name)
            {
                case "бит":
                    freevolume -= number;
                    break;
                case "б":
                    number *= 8;
                    freevolume -= number;
                    break;
                case "Кб":
                    number *= 8; number *= 1024;
                    freevolume -= number;
                    break;
                case "Мб":
                    number *= 8; number *= 1024; number *= 1024;
                    freevolume -= number;
                    break;
                case "Гб":
                    number *= 8; number *= 1024; number *= 1024; number *= 1024;
                    freevolume -= number;
                    break;
                default:
                    return false;
            }
            return true;
        }

        protected override void FreeMemory()
        {
            freevolume /= 8;
            freevolume /= 1024;
            freevolume /= 1024;
            freevolume /= 1024;
            WriteLine($"Свободное место на диске: {freevolume} Гб");
            freevolume *= 1024;
            freevolume *= 1024;
            freevolume *= 1024;
            freevolume *= 8;
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
    //abstract class DVD:Storage
    //{
    //    protected long speed = 176947200;//176 947 200бит
    //    protected long volume;
    //    protected long freevolume;
    //    protected string buf;//здесь будет храниться свободный память сразу ввиде строки, для более удобного вызова
    //    public DVD(string name, string model) : base(name, model)
    //    {

    //    }
    //}
    //class SingleSidedDVD:DVD
    //{
    //    public SingleSidedDVD(string name, string model) : base(name, model)
    //    {
    //        volume = 40372692582;//40 372 692 582 бит
    //        freevolume = 40372692582;
    //    }

    //    public override void Memory()
    //    {
    //        WriteLine("4.7 Гб");
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
    //        WriteLine("Модель устройства: " + Model+ " однослойный односторонний");
    //        WriteLine("Общий объём информации: 4,7 Гб");
    //        WriteLine("Свободное место: " + buf);
    //        WriteLine("Скорость чтения/записи: 21,09 Мб/с");
    //    }
    //}
    //class TwoWayDVD : DVD
    //{
    //    public TwoWayDVD(string name, string model) : base(name, model)
    //    {
    //        volume = 77309411328;//77 309 411 328 бит
    //        freevolume = 77309411328;
    //    }

    //    public override void Memory()
    //    {
    //        WriteLine("9 Гб");
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
            Storage flash = new Flash("MyFlash", "A103mb_1");
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
                            WriteLine("2.Съёмный HDD");
                            WriteLine("3.DVD-диск");
                            WriteLine("4.Возврат в меню");
                            choice = Convert.ToInt32(ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    flash.GetInfo();
                                    break;
                                case 2:
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
                            if (mass.Length == 2)
                                if (flash.Copy(mass[0], mass[1])) break; 
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
