using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearList
{
    public interface ILinearList<T>
    {
        bool IsEmpty();
        int GetLength();
        void Clear();
        void Append(T elem);
        T GetElem(int index);
        void InsertElem(int index,T elem);
        T DeleteElem(int index);
        int LocateElem(T elem);
        void Reverse();
        void Print();
    }
}
