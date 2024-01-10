using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
    internal class Backtracking
    {
        /*********************************************************************
         * 백트래킹 (Backtracking)
         * 
         * 모든 경우의 수를 전부 고려하는 알고리즘
         * 후보해를 검증 도중 해가 아닌경우 되돌아가서 다시 해를 찾아가는 기법
         **********************************************************************/

        // 예시 - 순열
        List<int> list = new List<int>();
        void Permutation(int n, int r, int count = 0)
        {
            if (count == r)
            {
                Console.WriteLine(string.Join(' ', list));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (list.Contains(i))
                {
                    continue;
                }

                list.Add(i);
                Permutation(n, r, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
