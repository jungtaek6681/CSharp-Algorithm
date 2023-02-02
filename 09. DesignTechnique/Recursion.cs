using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._DesignTechnique
{
	internal class Recursion
	{
		/******************************************************
		 * 재귀 (Recursion)
		 * 
		 * 어떠한 것을 정의할 때 자기 자신을 참조하는 것
		 ******************************************************/

		// <재귀함수 조건>
		// 1. 함수내용 중 자기자신함수를 다시 호출해야함
		// 2. 종료조건이 있어야 함

		// <재귀함수 사용>
		// Factorial : 정수를 1이 될 때까지 차감하며 곱한 값
		// x! = x * (x-1)!;
		// 1! = 1;
		// ex) 5! = 5 * 4 * 3 * 2 * 1
		int Factorial(int x)
		{
			if (x == 1)
				return 1;
			else
				return x * Factorial(x - 1);
		}
	}
}
