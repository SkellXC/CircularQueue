using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Transactions;

namespace queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] queue = new string[3];
            int front = -1;
            int back = -1;
            int size = 0;
            Enqueue(queue, ref back, ref size, "abc");
            Enqueue(queue, ref back, ref size, "def");
            Enqueue(queue, ref back, ref size, "ghi");
            deQueue(queue, ref size, ref front);
            Enqueue(queue, ref back, ref size, "jkl");
            DisplayList(queue, size, front);
        }
        static bool isFull(string[] queue, int size)
        {
            // Return false if the queue is equal to the size else return false
            return (size == queue.Length) ? true : false;
        }
        static bool isEmpty(string[] queue, int size)
        {
            return (size == 0);
            // If size is 0 (the list is empty) then the statement size == 0 evaluates to 'true' which is then returned. Else it returns False
        }

        static void Enqueue(string[] queue, ref int back, ref int size, string item)// Item is what is added to the queue
        {   // If the queue is not full
            if (!isFull(queue, size))
            {
                int max = 3;
                size += 1;
                back = (back + 1) % max;// Sends the position back to 1 if it goes past the end of the list
                queue[back] = item;
                Console.WriteLine(back);
                return;

            }
            Console.WriteLine("Queue is full");
        }
        static void deQueue(string[] queue, ref int size, ref int front)
        {
            if (!isEmpty(queue, size))
            {
                int max = 3;
                size -= 1;
                front = (front + 1) % max;
                queue[front] = null;
                

            }

        }
        static void DisplayList(string[] queue, int size, int front)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(queue[(front + i) % queue.Length]);
            }
        }
    }
}
