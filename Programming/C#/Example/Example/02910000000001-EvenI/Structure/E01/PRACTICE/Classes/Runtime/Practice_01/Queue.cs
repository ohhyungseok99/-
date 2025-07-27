using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.PRACTICE
{
	internal class Queue
	{
		class PriorityQueue
		{
			private int[] heap;
			private int size;

			public PriorityQueue(int capacity)
			{
				heap = new int[capacity + 1]; // index 0은 사용하지 않음
				size = 0;
			}

			public void Enqueue(int value)
			{
				if(size + 1 >= heap.Length)
					Array.Resize(ref heap, heap.Length * 2);

				heap[++size] = value;
				HeapifyUp(size);
			}

			public int Dequeue()
			{
				if(size == 0)
				{
					throw new InvalidOperationException("Queue is empty.");
				}

				int min = heap[1];
				heap[1] = heap[size--];
				HeapifyDown(1);
				return min;
			}

			public bool IsEmpty() => size == 0;

			private void HeapifyUp(int index)
			{
				while(index > 1 && heap[index] < heap[index / 2])
				{
					Swap(index, index / 2);
					index /= 2;
				}
			}

			private void HeapifyDown(int index)
			{
				while(2 * index <= size)
				{
					int child = 2 * index;
					if(child < size && heap[child + 1] < heap[child])
						child++;

					if(heap[index] <= heap[child])
						break;

					Swap(index, child);
					index = child;
				}
			}

			private void Swap(int i, int j)
			{
				int temp = heap[i];
				heap[i] = heap[j];
				heap[j] = temp;
			}

			public void Print()
			{
				Console.Write(" Array (1-indexed): ");
				for(int i = 1; i <= size; i++)
				{
					Console.Write(heap[i] + " ");
				}
				Console.WriteLine();
			}
		}

		static void Main(string[] args)
		{
			var Random = new Random();
			var priorityQueue = new PriorityQueue(10);
			Console.WriteLine("입력 순서");
			for(int i = 0; i < 50; i++)
			{
				int value = Random.Next(1, 100);
				priorityQueue.Enqueue(value);
				Console.Write(value + "{0} ",value);
			}

			Console.WriteLine("\n우선 순위 큐");


			while(!priorityQueue.IsEmpty())
			{
				Console.Write("{0} ", priorityQueue.Dequeue());
			}


			//var pQueue = new PriorityQueue(10);
			//pQueue.Enqueue(10);
			//pQueue.Enqueue(20);
			//pQueue.Enqueue(5);
			//pQueue.Enqueue(15);
			//
			//pQueue.Print();

		}
	}
}
