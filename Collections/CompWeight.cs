using System.Collections.Generic;




namespace Collections

{
    class CompWeight<T> : IComparer<T>
        where T : Handluggage
    {
        public int Compare(T x, T y)
        {
            if (x.Weight < y.Weight)
                return 1;
            if (x.Weight > y.Weight)
                return -1;
            else
                return 0;
        }
    }
}

