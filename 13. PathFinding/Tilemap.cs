using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._PathFinding
{
	internal class Tilemap
	{
		/******************************************************
		 * 타일맵 (Tilemap)
		 * 
		 * 2차원 평면의 그래프를 정점이 아닌 위치를 통해 표현하는 그래프
		 * 위치의 이동가능 유무만을 가지는 타일맵과,
		 * 타일의 종류를 표현한 이차원 타일맵이 있음
		 * 인접한 이동가능한 위치간 간선이 있으며 가중치는 동일함
		 ******************************************************/

		// <타일맵 그래프>
		// 예시 - 위치의 이동가능 표현한 이차원 타일맵
		bool[,] tileMap1 = new bool[7, 7]
		{
			{ false, false, false, false, false, false, false },
			{ false,  true,  true, false, false, false, false },
			{ false, false,  true, false, false,  true, false },
			{ false, false,  true,  true,  true,  true, false },
			{ false, false,  true, false, false, false, false },
			{ false, false,  true,  true,  true,  true, false },
			{ false, false, false, false, false, false, false },
		};
		/*
		 * ■ ■ ■ ■ ■ ■ ■
		 * ■   ■   ■ ■ ■
		 * ■   ■   ■   ■
		 * ■   ■       ■
		 * ■   ■   ■ ■ ■
		 * ■           ■
		 * ■ ■ ■ ■ ■ ■ ■
		 */

		// 예시 - 타일의 종류를 표현한 이차원 타일맵
		enum TileType
		{
			None	= ' ',
			Wall	= '■',
			Path	= '*',
			Start	= 'S',
			Goal	= 'E',
		}

		char[,] tileMap2 = new char[9, 9]
		{
			{ '■', '■', '■', '■', '■', '■', '■', '■', '■' },
			{ '■', 'S', '■', '■', ' ', ' ', '■', '■', '■' },
			{ '■', '*', '■', '■', ' ', '■', '■', ' ', '■' },
			{ '■', '*', '■', '■', ' ', '■', '■', ' ', '■' },
			{ '■', '*', '■', '*', '*', '*', '*', '*', '■' },
			{ '■', '*', '■', '*', '■', '■', '■', '*', '■' },
			{ '■', '*', '■', '*', '■', '■', '■', '*', '■' },
			{ '■', '*', '*', '*', '■', '■', '■', 'E', '■' },
			{ '■', '■', '■', '■', '■', '■', '■', '■', '■' },
		};
		/*
		 * ■ ■ ■ ■ ■ ■ ■ ■ ■
		 * ■ S ■ ■     ■ ■ ■
		 * ■ * ■ ■   ■ ■   ■
		 * ■ * ■ ■   ■ ■   ■
		 * ■ * ■ * * * * * ■
		 * ■ * ■ * ■ ■ ■ * ■
		 * ■ * ■ * ■ ■ ■ * ■
		 * ■ * * * ■ ■ ■ E ■
		 * ■ ■ ■ ■ ■ ■ ■ ■ ■
		 */
	}
}
