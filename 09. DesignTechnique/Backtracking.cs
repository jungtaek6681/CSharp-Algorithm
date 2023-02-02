using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _09._DesignTechnique
{
	internal class Backtracking
	{
		/******************************************************
		 * 백트래킹 (Backtracking)
		 * 
		 * 모든 경우의 수를 전부 고려하는 알고리즘
		 * 후보해를 검증 도중 해가 아닌경우 되돌아가서 다시 해를 찾아가는 기법
		 ******************************************************/

		// 예시 - N개의 퀸(체스판의 서로 공격할 수 없는 퀸 N개 놓기)
		private bool NQueen(bool[,] board, int y = 0)
		{
			int ySize = board.GetLength(0);
			int xSize = board.GetLength(1);

			for (int i = 0; i < xSize; i++)
			{
				if (!CanPlace(board, i, y))
					continue;

				if (y >= ySize - 1)
				{
					board[y, i] = true;
					PrintBoard(board);
					return true;
				}

				bool[,] copyBoard = board.Clone() as bool[,];
				copyBoard[y, i] = true;

				if (NQueen(copyBoard, y + 1))
					return true;
			}

			return false;
		}

		private bool CanPlace(bool[,] board, int x, int y)
		{
			int ySize = board.GetLength(0);
			int xSize = board.GetLength(1);

			// 직선 검증
			for (int i = 0; i < xSize; i++)
			{
				if (board[y, i])
					return false;
			}
			for (int j = 0; j < ySize; j++)
			{
				if (board[j, x])
					return false;
			}

			// 대각선 검증
			for (int j = 0; j < ySize; j++)
			{
				for (int i = 0; i < xSize; i++)
				{
					if (board[j, i] && y - x == j - i)
						return false;
					if (board[j, i] && y + x == j + i)
						return false;
				}
			}

			return true;
		}

		private void PrintBoard(bool[,] board)
		{
			for (int y = 0; y < board.GetLength(0); y++)
			{
				for (int x = 0; x < board.GetLength(1); x++)
				{
					if (board[y, x])
						Console.Write("Q");
					else
						Console.Write('.');
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}
