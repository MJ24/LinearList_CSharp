using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearList
{
    class SequenceList<T> : ILinearList<T>
    {
        private T[] data;
        private int maxSize;
        private int lastIndex;

        //索引器，index范围是1到lastIndex + 1的闭区间
        //因此凡是遍历实际值时，终点都是lastIndex而不是data.length！！！！
        //因此也不能用foreach去遍历！！！！！！！！！！！！
        public T this[int index]
        {
            get
            {
                if (index < 1 || index > lastIndex + 1)
                {
                    Console.WriteLine("获取元素位置错误！");
                    return default(T);
                }
                else
                {
                    return data[index - 1];
                }
            }
            set
            {
                if (index < 1 || index > lastIndex + 1)
                {
                    Console.WriteLine("设置元素位置错误！");
                }
                else
                {
                    data[index - 1] = value;
                }
            }
        }
        public int MaxSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }
        public int LastIndex
        {
            get { return lastIndex; }
        }
        public SequenceList(int size)
        {
            data = new T[size];
            maxSize = size;
            lastIndex = -1;
        }

        //顺序表可以当lastIndex要大于maxSize时重新弄一个更大的数组
        //这里暂不实现，IsFull对内使用
        private bool IsFull()
        {
            return lastIndex == maxSize - 1;
        }

        public bool IsEmpty()
        {
            return lastIndex == -1;
        }

        public int GetLength()
        {
            return lastIndex + 1;
        }

        public void Clear()
        {
            lastIndex = -1;
        }

        public void Append(T elem)
        {
            if (IsFull())
            {
                Console.WriteLine("顺序表已满！");
            }
            else
            {
                //当表为空时也满足
                data[++lastIndex] = elem;
            }
        }

        public T GetElem(int index)
        {
            T result = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("顺序表为空！");
            }
            else if (index < 1 || index > lastIndex + 1)
            {
                Console.WriteLine("获取元素位置错误！");
            }
            else
            {
                result = data[index - 1];
            }
            return result;
        }

        public void InsertElem(int index, T elem)
        {
            if (IsFull())
            {
                Console.WriteLine("顺序表已满！");
            }
            else if (index < 1 || index > lastIndex + 2)
            {
                Console.WriteLine("插入元素位置错误！");
            }
            else if (index == lastIndex + 2)
            {
                data[++lastIndex] = elem;
            }
            else
            {
                //注意index是对于list而言的，对于data数组来说是index - 1
                //即要插在list第1个实际上是插在data数组的第0个
                for (int i = lastIndex + 1; i >= index; i--)
                {
                    data[i] = data[i - 1];
                }
                data[index - 1] = elem;//同上为index - 1
                lastIndex++;
            }
        }

        public T DeleteElem(int index)
        {
            T result = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("顺序表为空！");
            }
            else if (index < 1 || index > lastIndex + 1)
            {
                Console.WriteLine("删除元素位置错误！");
            }
            else if (index == lastIndex + 1)
            {
                result = data[lastIndex];
                index--;
            }
            else
            {
                result = data[index - 1];
                for (int i = index - 1; i < lastIndex; i++)
                {
                    data[i] = data[i + 1];
                }
                lastIndex--;
            }
            return result;
        }

        public int LocateElem(T elem)
        {
            //-1代表此list中不存在此元素
            int result = -1;
            if (IsEmpty())
            {
                Console.WriteLine("顺序表为空！");
            }
            else
            {
                //注意是i <= lastIndex而不是i <= data.Length !!!!!!!!!!!!!!!!!!!!
                for (int i = 0; i < lastIndex; i++)
                {
                    if (data[i].Equals(elem))
                    {
                        result = i + 1;
                        break;
                    }
                }
                if (result == -1)
                {
                    Console.WriteLine("元素{0}在顺序表中不存在", elem);
                }
            }
            return result;
        }

        public void Reverse()
        {
            int length = lastIndex + 1;
            for (int i = 0; i < length / 2; i++)
            {
                T temp = data[i];
                data[i] = data[length - 1 - i];
                data[length - 1 - i] = temp;
            }
        }

        public void Print()
        {
            //注意是<= lastIndex而不<= data.length！！！！！！！！！
            //同样也不能用foreach！！！！！！！！！！！！！！！！！！
            for (int i = 0; i <= lastIndex; i++)
            {
                Console.WriteLine(data[i]);
            }
        }
    }
}
