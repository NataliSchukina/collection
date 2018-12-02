using System.Linq;
using NLog;




namespace Collections

{
    public class Handluggage : Box
    {
        const uint maxmeasure = 115; // максимальное значение суммы трех измерений 
        const uint maxweight = 10;   // ограничение по весу
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Handluggage(uint Lenght, uint Widht, uint Hight, uint Weight)
        {
            this.Length = Lenght;
            this.Width = Widht;
            this.Hight = Hight;
           
            if (Weight> maxweight)
                throw new HandluggageException("Внесен вес больше допустимого значения");
            else
                this.Weight = Weight;
            if (Length + Width + Hight > maxmeasure)
               
                logger.Info("Внесен размер багажа больше допустимого значения");
                                   
        }

        public override string AlarmMessage()
        {
            if (Length + Width + Hight > maxmeasure)
                return "Объект не продходит как ручная кладь";
            else
                return "Ручная кладь";

        }
        public override string MessageaboutWeight()
        {
            if (Weight > maxweight)
                return "Есть перевес, необходима оплата";
            else
                return "Вес соответствует";
        }
        public override string ToString()
        {
            return $"   {GetHandluggageDescription("Length")}: {this.Length}" +
                   $"\t {GetHandluggageDescription("Width")}: {this.Width}" +
                    $"\t {GetHandluggageDescription("Hight")}: {this.Hight}" +
                   $"\t {GetHandluggageDescription("Weight")}: {this.Weight}";
         }

        private string GetHandluggageDescription(string propName)
        {
            foreach (var prop in typeof(Handluggage).GetProperties())
            {
                if (propName == prop.Name)
                {
                    var attrs = prop.GetCustomAttributes(typeof(DescriptionFieldAttribute), false);

                    if (attrs == null)
                        return null;

                    return ((DescriptionFieldAttribute)attrs.First()).Name;
                }
            }

            return null;
        }
    }
}

