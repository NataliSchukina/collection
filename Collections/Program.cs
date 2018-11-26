using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections

{
    public abstract class Box
    {
        public uint Length { get; set; }
        public uint Width { get; set; }
        public uint Hight { get; set; }
        public uint Weight { get; set; }
        public abstract string AlarmMessage();
        public abstract string MessageaboutWeight();

    }
    public class Handluggage : Box
    {
        const uint maxmeasure = 115; // максимальное значение суммы трех измерений 
        const uint maxweight = 10;   // ограничение по весу
        public Handluggage(uint Lenght, uint Widht, uint Hight, uint Weight)
        {
            this.Length = Lenght;
            this.Width = Widht;
            this.Hight = Hight;
            this.Weight = Weight;
        }

        public override string AlarmMessage()
        {
            if (Length + Width + Hight > maxmeasure)
                return "Объект не продходит как ручная кладь";
            else return "Ручная кладь";

        }
        public override string MessageaboutWeight()
        {
            if (Weight > maxweight)
                return "Есть перевес, необходима оплата";
            else return "Вес соответствует";
        }
        public override string ToString()
        {
            return String.Format("Длина: {0}\tШирина: {1}\tВысота: {2}\tВес: {3}",
                this.Length, this.Width, this.Hight, this.Weight);
        }
    }
    class CompWeight<T> : IComparer<T>
        where T : Handluggage
    {
        public int Compare(T x, T y)
        {
            if (x.Weight < y.Weight)
                return 1;
            if (x.Weight > y.Weight)
                return -1;
            else return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Handluggage> luggage = new List<Handluggage>();

            luggage.Add(new Handluggage(12, 34, 56, 3));
            luggage.Add(new Handluggage(112, 4, 56, 3));
            luggage.Add(new Handluggage(12, 34, 56, 12));
            luggage.Add(new Handluggage(11, 4, 6, 12));
            luggage.Add(new Handluggage(25, 5, 6, 4));
            luggage.Add(new Handluggage(17, 4, 8, 6));
            foreach (Handluggage a in luggage)
                Console.WriteLine(a);
            Console.WriteLine("Сортируем данные по весу");

            CompWeight<Handluggage> sortlug = new CompWeight<Handluggage>();
            luggage.Sort(sortlug);
            foreach (Handluggage a in luggage)
                Console.WriteLine(a);


            Console.WriteLine("Сортируем данные по высоте");
            var hightsort = GetSortedCollection(luggage);
            foreach (Handluggage a in hightsort)
                Console.WriteLine(a);

            Console.ReadKey();
        }

        public static IEnumerable<Handluggage> GetSortedCollection(IEnumerable<Handluggage> collection)
        {
            return collection.OrderBy(luggage => luggage.Hight);
        }
    }
}

