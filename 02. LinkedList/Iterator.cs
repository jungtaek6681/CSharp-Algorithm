using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList
{
    internal class Iterator
    {
        /*******************************************************************
         * 반복기 (Iterator)
         * 
         * 자료구조에 저장되어 있는 요소들을 순차적으로 접근하기 위한 객체
         * C# 대부분의 자료구조는 반복기를 포함
         * 이를 통해 자료구조종류와 내부구조에 무관하게 순회가능
         *******************************************************************/

        // <반복기 사용>
        // 반복기 객체를 자료구조에서 생성하여 순차적으로 확인하며 순회
        // IEnumerable : 자료구조의 반복기 생성 인터페이스
        // IEnumerator : 자료구조의 반복기 객체 인터페이스
        void Main1()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4 };

            // 반복기 객체 생성
            IEnumerator<int> iter = list.GetEnumerator();

            // 반복기 객체가 현재 가리키는 데이터 확인
            Console.WriteLine($"iter.Current = {iter.Current}");

            // 반복기 객체가 다음 데이터를 가리키도록 이동 (반환은 다음 데이터 유무)
            bool isEnd = iter.MoveNext();

            // 반복기 객체가 처음 데이터를 가리키도록 초기화
            iter.Reset();

            // 반복기 객체를 이용한 순회
            iter.Reset();
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current);
            }
        }


        // <반복기 사용의의>
        // 반복기를 사용하는 경우 자료구조종류와 내부구조에 무관하게 순회가능
        void Main2()
        {
            int size = 5;
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            for (int i = 0; i < size; i++)
            {
                list.Add(i);
                linkedList.AddLast(i);
            }

            // 반복기 사용이 없는 경우
            // 자료구조 내 데이터를 순회하기 위해 자료구조 내부구조를 이용해야 함
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
            }

            for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
            {
                Console.Write(node.Value);
            }


            // 반복기 사용을 하는 경우
            // 자료구조 내 데이터를 순회하기 위해 반복기 사용만을 필요
            for (IEnumerator<int> iter = list.GetEnumerator(); iter.MoveNext();)
            {
                Console.Write(iter.Current);
            }

            for (IEnumerator<int> iter = linkedList.GetEnumerator(); iter.MoveNext();)
            {
                Console.Write(iter.Current);
            }
        }


        // <foreach 반복문>
        // 반복기를 이용하는 반복문
        // IEnumerable 인터페이스를 포함하는 객체에 사용가능
        void Main3()
        {
            int size = 5;
            int[] array = new int[size];
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            SortedSet<int> set = new SortedSet<int>();

            for (int i = 0; i < size; i++)
            {
                array[i] = i;
                list.Add(i);
                linkedList.AddLast(i);
                stack.Push(i);
                queue.Enqueue(i);
                set.Add(i);
            }

            // IEnumerable 인터페이스를 포함하는 데이터 집합은 모두 foreach를 통해 순회 가능
            foreach (int element in array)      { Console.WriteLine(element); }
            foreach (int element in list)       { Console.WriteLine(element); }
            foreach (int element in linkedList) { Console.WriteLine(element); }
            foreach (int element in stack)      { Console.WriteLine(element); }
            foreach (int element in queue)      { Console.WriteLine(element); }
            foreach (int element in set)        { Console.WriteLine(element); }
            foreach (int element in IterFunc()) { Console.WriteLine(element); }
        }

        IEnumerable<int> IterFunc()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }
    }
}
