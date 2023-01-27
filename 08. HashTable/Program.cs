using System.Collections.Generic;
using System;
using System.Collections;

namespace _08._HashTable
{
	internal class Program
	{
		/******************************************************
		 * 해시테이블 (HashTable)
		 * 
		 * 키 값을 해시함수로 해싱하여 해시테이블의 특정 위치로 직접 엑세스하도록 만든 방식
		 * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
		 ******************************************************/

		// <해시테이블의 시간복잡도>
		// 접근			탐색			삽입			삭제
		// X			O(1)		O(1)		O(1)

		// <해시테이블 주의점 - 충돌>
		// 해시함수가 서로 다른 입력 값에 대해 동일한 해시테이블 주소를 반환하는 것
		// 모든 입력 값에 대해 고유한 해시 값을 만드는 것은 불가능하며 충돌은 피할 수 없음
		// 대표적인 충돌 해결방안으로 체이닝과 개방주소법이 있음

		// <충돌해결방안 - 체이닝>
		// 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
		// 장점 : 해시테이블에 자료가 많아지더라도 성능저하가 적음
		// 단점 : 해시테이블 외 추가적인 저장공간이 필요

		// <충돌해결방안 - 개방주소법>
		// 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식
		// 해시 충돌시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정
		// 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제시 오버헤드가 적음
		// 단점 : 해시테이블에 자료가 많아질수록 성능저하가 많음
		// 해시테이블의 공간 사용률이 높을 경우 성능저하가 발생하므로 재해싱 과정을 진행함
		// 재해싱 : 해시테이블의 크기를 늘리고 테이블 내의 모든 데이터를 다시 해싱 

		void Dictionary()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			dictionary.Add("txt", "텍스트 파일");
			dictionary.Add("bmp", "이미지 파일");
			dictionary.Add("mp3", "오디오 파일");

			Console.WriteLine(dictionary["txt"]);       // 키값은 인덱서를 통해 접근

			if (dictionary.ContainsKey("mp3"))
				Console.WriteLine("mp3 키 값의 데이터가 있음");
			else
				Console.WriteLine("mp3 키 값의 데이터가 없음");

			if (dictionary.Remove("mp3"))
				Console.WriteLine("mp3 키 값에 해당하는 데이터를 지움");
			else
				Console.WriteLine("mp3 키 값에 해당하는 데이터를 못지움");

			if (dictionary.ContainsKey("mp3"))
				Console.WriteLine("mp3 키 값의 데이터가 있음");
			else
				Console.WriteLine("mp3 키 값의 데이터가 없음");

			string output;
			if (dictionary.TryGetValue("bmp", out output))
				Console.WriteLine(output);
			else
				Console.WriteLine("bmp 키 값의 데이터가 없음");
		}

		static void Main(string[] args)
		{
			DataStructure.HashTable<string, string> hashTable = new DataStructure.HashTable<string, string>();

			hashTable.Add("txt", "텍스트 파일");
			hashTable.Add("bmp", "이미지 파일");
			hashTable.Add("mp3", "오디오 파일");

			Console.WriteLine(hashTable["txt"]);       // 키값은 인덱서를 통해 접근

			if (hashTable.ContainsKey("mp3"))
				Console.WriteLine("mp3 키 값의 데이터가 있음");
			else
				Console.WriteLine("mp3 키 값의 데이터가 없음");

			if (hashTable.Remove("mp3"))
				Console.WriteLine("mp3 키 값에 해당하는 데이터를 지움");
			else
				Console.WriteLine("mp3 키 값에 해당하는 데이터를 못지움");

			if (hashTable.ContainsKey("mp3"))
				Console.WriteLine("mp3 키 값의 데이터가 있음");
			else
				Console.WriteLine("mp3 키 값의 데이터가 없음");

			string output;
			if (hashTable.TryGetValue("bmp", out output))
				Console.WriteLine(output);
			else
				Console.WriteLine("bmp 키 값의 데이터가 없음");
		}
	}
}