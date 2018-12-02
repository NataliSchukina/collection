using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;




namespace Collections

{

    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static IEnumerable<Handluggage> luggage;

        static void Main(string[] args)
        {

            try
            {
                List<Handluggage> luggage = new List<Handluggage>();

                luggage.Add(new Handluggage(12, 34, 56, 3));
                luggage.Add(new Handluggage(11, 4, 54, 3));
                luggage.Add(new Handluggage(11, 34, 46, 6));
                luggage.Add(new Handluggage(11, 4, 6, 6));
                luggage.Add(new Handluggage(20, 5, 6, 1));
                luggage.Add(new Handluggage(17, 4, 8, 6));

                foreach (Handluggage a in luggage)
                {
                    Console.WriteLine(a);

                }

                Console.WriteLine("Сортируем данные по весу");

                CompWeight<Handluggage> sortlug = new CompWeight<Handluggage>();
                luggage.Sort(sortlug);
                foreach (Handluggage a in luggage)
                    Console.WriteLine(a);


                Console.WriteLine("Сортируем данные по высоте");
                var hightsort = GetSortedCollection(luggage);
                foreach (Handluggage a in hightsort)
                    Console.WriteLine(a);
            }
            catch (HandluggageException ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info(ex);
            }

            try
            {
                List<Handluggage> luggage1 = new List<Handluggage>();

                luggage1.Add(new Handluggage(12, 34, 56, 3));
                luggage1.Add(new Handluggage(11, 4, 54, 3));
                luggage1.Add(new Handluggage(111, 34, 46, 6));
                luggage1.Add(new Handluggage(11, 4, 6, 6));
                luggage1.Add(new Handluggage(20, 5, 6, 16));
                luggage1.Add(new Handluggage(17, 4, 8, 6));

                foreach (Handluggage a in luggage)
                {
                    Console.WriteLine(a);

                }
            }
            catch (HandluggageException ex)
            {
                Console.WriteLine(ex.Message);
                logger.Info(ex);
            }
            Console.ReadKey();
        }

        public static IEnumerable<Handluggage> GetSortedCollection(IEnumerable<Handluggage> collection)
        {
            return collection.OrderBy(luggage => luggage.Hight);
        }
    }
}

