using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._PathFinding
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool[,] tileMap = new bool[9, 9]
			{
				{ false, false, false, false, false, false, false, false, false },
				{ false,  true,  true,  true, false, false, false,  true, false },
				{ false,  true, false,  true, false, false, false,  true, false },
				{ false,  true, false,  true,  true,  true,  true,  true, false },
				{ false,  true, false,  true, false, false, false,  true, false },
				{ false,  true, false,  true, false, false, false,  true, false },
				{ false, false, false, false, false, false, false,  true, false },
				{ false,  true,  true,  true,  true,  true,  true,  true, false },
				{ false, false, false, false, false, false, false, false, false },
			};
			List<(int x, int y)> path;

			AStar.PathFinding(tileMap, (1, 1), (1, 7), out path);
			PrintResult(tileMap, path);
		}

		static void PrintResult(in bool[,] tileMap, in List<(int x, int y)> path)
		{
			char[,] pathMap = new char[tileMap.GetLength(0), tileMap.GetLength(1)];
			for (int y = 0; y < pathMap.GetLength(0); y++)
			{
				for (int x = 0; x < pathMap.GetLength(1); x++)
				{
					if (tileMap[y, x])
						pathMap[y, x] = ' ';
					else
						pathMap[y, x] = '■';
				}
			}

			foreach ((int x, int y) point in path)
			{
				pathMap[point.y, point.x] = '*';
			}

			(int x, int y) start = path.First();
			(int x, int y) end = path.Last();
			pathMap[start.y, start.x] = 'S';
			pathMap[end.y, end.x] = 'E';

			for (int i = 0; i < pathMap.GetLength(0); i++)
			{
				for (int j = 0; j < pathMap.GetLength(1); j++)
				{
					Console.Write(pathMap[i, j]);
				}
				Console.WriteLine();
			}
		}
	}
}