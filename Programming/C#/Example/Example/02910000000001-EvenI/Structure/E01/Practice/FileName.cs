using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Programming.E01
{
	class Node
	{
		public Node Val { get; set; } = null;
		public int Value { get; set; } = 0;
		public Node Next { get; set; } = null;

		//public Node(int value = 0)
		//{
		//	Val = null;
		//	Value = value;
		//	Next = null;
		//}
	}


	class LinkedListNode
	{
		public Node Head { get; set; }
		public Node Prev { get; set; }
		public Node DummyHead;

		public LinkedListNode()
		{
			DummyHead = new Node();

		}

		// 연결 리스트에 마지막에 값을 추가한다
		public void AddLast(int value)
		{

			Node newNode = new Node();
			newNode.Value = value;
			newNode.Next = null;

			Node current = DummyHead;

			while(current.Next != null)
			{
				current = current.Next;
			}

			current.Next = newNode;
		}

		public void Remove(int value)
		{
			Node Prev = DummyHead;
			Node current = DummyHead.Next;

			// 현재 노드 삭제
			while(current != null)
			{
				if(current.Value == value)
				{
					Prev.Next = current.Next;
					return;
				}

				Prev = current;
				current = current.Next;
			}
		}

		public void print()
		{
			Node current = DummyHead.Next;
			Console.WriteLine("리스트 시작");


			while(current != null)
			{
				Console.WriteLine(current.Value);
				current = current.Next;
			}
			Console.WriteLine("리스트 끝\n");

		}
	}

	class Program
	{
		static void Main()
		{
			// 연결 리스트 생성 및 값 추가
			LinkedListNode linkedList = new LinkedListNode();

			linkedList.AddLast(100);
			linkedList.AddLast(200);
			linkedList.AddLast(300);
			linkedList.AddLast(400);
			linkedList.AddLast(500);

			linkedList.print();

			linkedList.Remove(200);

			linkedList.print();

		}
	}
}
