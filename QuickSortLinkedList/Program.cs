using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(5);
            Node n2 = new Node(1);
            Node n3 = new Node(2);
            Node n4 = new Node(3);
            Node n5 = new Node(6);

            n1.Next = n2;
            n2.Next = n3;
            n3.Next = n4;
            n4.Next = n5;

            Node result = QuickSort(n1);

            Console.WriteLine("Sorted list is");
            while (result != null)
            {
                Console.Write(result.Data + " ");
                result = result.Next;
            }
        }

        static Node QuickSort(Node head)
        {
            Node tail = GetTail(head);

            if (head == null || head == tail)
            {
                return head;
            }

            Node pivot = Partition(ref head, ref tail);

            // Get the list from head to the node before pivot
            Node nodeBeforePivot = head;

            while (nodeBeforePivot.Next != pivot)
            {
                nodeBeforePivot = nodeBeforePivot.Next;
            }

            nodeBeforePivot.Next = null;

            Node sortedHead = QuickSort(head);

            Node sortedTail = GetTail(sortedHead);

            sortedTail.Next = pivot;

            pivot.Next = QuickSort(pivot.Next);

            return sortedHead;
        }

        static Node Partition(ref Node head, ref Node tail)
        {
            Node newHead = head;

            Node current = head;

            Node pivot = tail;

            Node prev = null;

            Node temp;

            while (current != pivot)
            {
                if (current.Data < pivot.Data)
                {
                    prev = current;
                    current = current.Next;
                }
                else
                {
                    if (prev != null)
                    {
                        prev.Next = current.Next;
                    }

                    temp = current.Next;

                    current.Next = null;

                    tail.Next = current;

                    tail = current;

                    current = temp;

                    newHead = temp;
                }
            }

            head = newHead;

            return pivot;
        }

        static Node GetTail(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Node tail = null;

            Node current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            tail = current;

            return tail;
        }
    }

    class Node
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data { get; set; }

        public Node Next { get; set; }
    }
}
