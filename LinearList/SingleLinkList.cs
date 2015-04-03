using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearList
{
    public class SingleLinkList<T> : ILinearList<T>
    {
        private Node<T> head;

        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }
        public SingleLinkList()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        //注意所有的遍历和index判断范围都不能用GetLength()来确定终点！！！！！！！！！
        //因为GetLength又要遍历一遍list！！因此都是在本身遍历的同时直接找到要操作的节点
        //如GetElem，InsertElem，DeleteElem的判断范围
        public int GetLength()
        {
            int length = 0;
            Node<T> p = head;
            while (p != null)
            {
                length++;
                p = p.Next;
            }
            return length;
        }

        public void Clear()
        {
            head = null;
        }

        public void Append(T elem)
        {
            Node<T> newNode = new Node<T>(elem);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                Node<T> p = head;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = newNode;
            }
        }

        public T GetElem(int index)
        {
            T result = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("链表为空！");
            }
            else
            {
                int currentIndex = 1;
                Node<T> p = head;
                while (currentIndex < index && p.Next != null)
                {
                    p = p.Next;
                    currentIndex++;
                }
                if (currentIndex == index)
                {
                    result = p.Data;
                }
                else
                {
                    Console.WriteLine("获取元素位置错误！");
                }
            }
            return result;
        }

        public void InsertElem(int index, T elem)
        {
            throw new NotImplementedException();
        }

        public T DeleteElem(int index)
        {
            throw new NotImplementedException();
        }

        public int LocateElem(T elem)
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
