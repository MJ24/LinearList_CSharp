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

        //允许为空时插到第一个，允许插到尾节点的后一个
        public void InsertElem(int index, T elem)
        {
            Node<T> newNode = new Node<T>(elem);
            if (IsEmpty())
            {
                if (index == 1)
                {
                    head = newNode;
                }
                else
                {
                    Console.WriteLine("链表为空！只允许在第一个插入.");
                }
            }
            else if (index == 1)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node<T> p = head;
                int currentIndex = 1;
                while (p.Next != null && currentIndex < index - 1)
                {
                    p = p.Next;
                    currentIndex++;
                }
                if (currentIndex == index - 1)
                {
                    newNode.Next = p.Next;
                    p.Next = newNode;
                }
                else
                {
                    Console.WriteLine("插入元素位置错误！");
                }
            }
        }

        public T DeleteElem(int index)
        {
            T result = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("链表为空！");
            }
            else if (index == 1)
            {
                result = head.Data;
                head = head.Next;
            }
            else
            {
                Node<T> p = head;
                int currentIndex = 1;
                while (p.Next != null && currentIndex < index - 1)
                {
                    p = p.Next;
                    currentIndex++;
                }
                if (currentIndex == index - 1)
                {
                    if (p.Next == null)
                    {
                        Console.WriteLine("删除元素位置错误！");
                    }
                    else
                    {
                        result = p.Next.Data;
                        p.Next = p.Next.Next;
                    }
                }
                else
                {
                    Console.WriteLine("删除元素位置错误！");
                }
            }
            return result;
        }

        public int LocateElem(T elem)
        {
            if (IsEmpty())
            {
                Console.WriteLine("链表为空！");
                return -1;
            }
            else
            {
                int result = 0;
                Node<T> p = head;
                while (p != null)
                {
                    result++;
                    if (p.Data.Equals(elem))
                    {
                        break;
                    }
                    p = p.Next;
                }
                if (p == null)
                {
                    Console.WriteLine("链表中不存在此元素！");
                    result = -1;
                }
                return result;
            }
        }

        //反转的关键在于前中后三个节点都要操作
        //前节点用于给中节点的next赋值
        //后节点用于继续往后遍历，每一次循环都是前=中，中=后，后=后.next
        //这样循环就可以继续往后遍历
        public void Reverse()
        {
            Node<T> pre = null;
            Node<T> current = null;
            Node<T> latter = head;
            while (latter != null)
            {
                pre = current;
                current = latter;
                latter = latter.Next;
                current.Next = pre;
            }
            head = current;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("链表为空！");
            }
            else
            {
                Node<T> p = head;
                while (p != null)
                {
                    Console.WriteLine(p.Data);
                    p = p.Next;
                }
            }
        }
    }
}
