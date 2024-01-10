using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
    internal class DivideAndConquer
    {
        /*************************************************************************
         * 분할정복 (Divide and Conquer)
         * 
         * 큰 문제를 작은 문제로 나눠서 푸는 하향식 접근 방식
         * 분할을 통해서 해결하기 쉬운 작은 문제로 나눈 후 정복한 후 병합하는 과정
         **************************************************************************/

        // 예시 - 거듭 제곱
        int Pow(int x, int n)
        {
            if (n == 1)
            {
                return x;
            }

            int halfPow = Pow(x, n / 2);
            if (n % 2 == 0)
            {
                return halfPow * halfPow;
            }
            else
            {
                return halfPow * halfPow * x;
            }
        }
    }
}
