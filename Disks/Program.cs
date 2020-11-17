using System;
using static System.Console;

namespace Disks
{
    abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public Storage(string name, string model)
        {
            Name = name; Model = model;
        }
        public abstract void Memory();
        //передаём объём копируемых файлов и единицы измерения
        public abstract void Copy(long value, string name);
        public abstract void FreeMemory();
        public abstract void GetInfo();
    }

    //заданиие конструктора базового класса, вызываемого при создании экземпляров производного класса
    class Flash : Storage
    {
        private long speedUSB3_0 = 42949672960;//42 949 672 960 Бит(скорость)
        private long volume = 549755813888;//549 755 813 888 Бит(общий объём)
        private long freevolume = 549755813888;//(свободный объём)
        private string buf;//здесь будет храниться свободный память сразу ввиде строки, для более удобного вызова
        public Flash(string name, string model) : base(name, model)
        {

        }

        public override void Memory()
        {
            WriteLine("64 Гб");
        }

        public override void Copy(long value, string name)
        {
            //Через Split(' ') разделяем и передаём сюда
            //здесь всё преобразуем в бит
            //и занимаем freevolume
        }

        public override void FreeMemory()
        {
            //дописать перевод в единицы измерения, инициализация buf
            WriteLine((volume - freevolume));
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model);
            WriteLine("Общий объём информации: 64 Гб");
            WriteLine("Свободное место: "+buf);
            WriteLine("Скорость интерфейса: 5 Гб");
        }
    }
    abstract class DVD:Storage
    {
        protected long speed = 176947200;//176 947 200бит
        protected long volume;
        protected long freevolume;
        protected string buf;//здесь будет храниться свободный память сразу ввиде строки, для более удобного вызова
        public DVD(string name, string model) : base(name, model)
        {

        }
    }
    class SingleSidedDVD:DVD
    {
        public SingleSidedDVD(string name, string model) : base(name, model)
        {
            volume = 40372692582;//40 372 692 582 бит
            freevolume = 40372692582;
        }

        public override void Memory()
        {
            WriteLine("4.7 Гб");
        }

        public override void Copy(long value, string name)
        {
            //Через Split(' ') разделяем и передаём сюда
            //здесь всё преобразуем в бит
            //и занимаем freevolume
        }

        public override void FreeMemory()
        {
            //дописать перевод в единицы измерения, инициализация buf
            WriteLine((volume - freevolume));
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model+ " однослойный односторонний");
            WriteLine("Общий объём информации: 4,7 Гб");
            WriteLine("Свободное место: " + buf);
            WriteLine("Скорость чтения/записи: 21,09 Мб/с");
        }
    }
    class TwoWayDVD : DVD
    {
        public TwoWayDVD(string name, string model) : base(name, model)
        {
            volume = 77309411328;//77 309 411 328 бит
            freevolume = 77309411328;
        }

        public override void Memory()
        {
            WriteLine("9 Гб");
        }

        public override void Copy(long value, string name)
        {
            //Через Split(' ') разделяем и передаём сюда
            //здесь всё преобразуем в бит
            //и занимаем freevolume
        }

        public override void FreeMemory()
        {
            //дописать перевод в единицы измерения, инициализация buf
            WriteLine((volume - freevolume));
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model + " однослойный двусторонний");
            WriteLine("Общий объём информации: 9 Гб");
            WriteLine("Свободное место: " + buf);
            WriteLine("Скорость чтения/записи: 21,09 Мб/с");
        }
    }
    class HDD:Storage
    {
        private long speedUSB2_0 = 4026531840;//4 026 531 840 бит(скорость)
        private string buf;//здесь будет храниться свободный память сразу ввиде строки, для более удобного вызова
        private int number = 2;//кол-во разделов
        public HDD(string name, string model) : base(name, model)
        {
            Tom[] mass = new Tom[number];
            for (int i = 0; i < number; i++)
                mass[i].Name = $"Tom{i++}";
        }
        public override void Memory()
        {
            WriteLine("128Гб");
        }

        public override void Copy(long value, string name)
        {
            //Через Split(' ') разделяем и передаём сюда
            //здесь всё преобразуем в бит
            //и занимаем freevolume
        }

        public override void FreeMemory()
        {
            //дописать перевод в единицы измерения, инициализация buf
            WriteLine((volume - freevolume));
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model + " однослойный двусторонний");
            WriteLine("Общий объём информации: 9 Гб");
            WriteLine("Свободное место: " + buf);
            WriteLine("Скорость чтения/записи: 21,09 Мб/с");
        }
    }
    class Tom
    {
        private string name;
        public string Name { 
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
