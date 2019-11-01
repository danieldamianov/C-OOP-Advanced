using System;

namespace _9_Linked_List_Traversal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomLinkedList<int> customLinkedList = new CustomLinkedList<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commandSplit = Console.ReadLine().Split();
                switch (commandSplit[0])
                {
                    case "Add":
                        customLinkedList.Add(int.Parse(commandSplit[1]));
                        break;
                    case "Remove":
                        customLinkedList.Remove(int.Parse(commandSplit[1]));
                        break;
                }
            }
            Console.WriteLine(customLinkedList.Count);
            if (customLinkedList.Count != 0)
            {
                Console.WriteLine(string.Join(" ", customLinkedList)); 
            }
        }
    }
}
