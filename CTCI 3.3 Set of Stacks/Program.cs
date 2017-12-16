using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_3._3_Set_of_Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeaderMsg(3, 3, "Set of Stacks");

            SetOfStacks mySet = new SetOfStacks();

            Random rnd = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 50; ++i)            
                mySet.Push(rnd.Next(10, 99));

            Console.WriteLine();

            Console.WriteLine(mySet.PopAt(0) + " popped from stack 0");
            Console.WriteLine(mySet.PopAt(2) + " popped from stack 2");
            Console.WriteLine(mySet.PopAt(3) + " popped from stack 3");
            Console.WriteLine(mySet.PopAt(4) + " popped from stack 4");
            Console.WriteLine(mySet.PopAt(1) + " popped from stack 1");

            Console.WriteLine();

            for (int i = 0; i < 45; ++i)
                mySet.Pop();

            Console.ReadLine();
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 
    /// 1. Create List<> of Stack<> of ints.
    /// 2. For every Push() push onto the last stack on the list
    ///    If list is empty, or last stack has 10 items, add new stack
    /// 3. For every Pop() pop from the last stack on the list
    ///    If last stack is empty, remove and pop from the next one
    /// 4. Exceptions are handled by List<> and Stack<>
    ///    (popping from empty stack/list, out of memory, etc)
    ///    
    /// complexity:     Pop(), Push(), PopAt() run in O(1)
    ///                 Same time regardless of input
    ///                 
    ///                 Memory is O(N)
    ///                 All input is stored, so requirements grow
    ///                 as input grows.
    /// 
    /// </summary>
    public class SetOfStacks
    {
        List<Stack<int>> listStacks = new List<Stack<int>>();
        
        // Exceptions handled by list<> and stack<>
        public void Push(int passed_int)
        {
            if ((listStacks.Count == 0) || (listStacks.Last().Count > 9))
                listStacks.Add(new Stack<int>());

            listStacks.Last().Push(passed_int);

            Console.WriteLine(passed_int + " pushed onto stack " + (listStacks.Count - 1));
        }

        // Exceptions handled by list<> and stack<>
        public int Pop()
        {
            if (listStacks.Last().Count == 0)
                listStacks.RemoveAt(listStacks.Count - 1);

            int temp = listStacks.Last().Pop();

            Console.WriteLine(temp + " popped from stack " + (listStacks.Count - 1));

            return temp;
        }

        // Exceptions handled by list<> and stack<>
        internal int PopAt(int v)
        {            
            return listStacks.ElementAt(v).Pop();
        }
    }

    
}
