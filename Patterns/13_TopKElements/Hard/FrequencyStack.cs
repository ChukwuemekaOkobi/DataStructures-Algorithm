using System.Collections.Generic;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// Design a class that simulates a Stack data structure, implementing the following two operations:
    //    push(int num) : Pushes the number ‘num’ on the stack.
    //     pop(): Returns the most frequent number in the stack.If there is a tie, return the number which was pushed later.
    //Example:


    //     After following push operations: push(1), push(2), push(3), push(2), push(1), push(2), push(5)

    //1. pop() should return 2, as it is the most frequent number
    //2. Next pop() should return 1
    //3. Next pop() should return 2
    /// </summary>
    public class FrequencyStack
    {
        readonly Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        int sequenceNumber = 0;
        readonly PriorityQueue<Element,Element> maxHeap = new (new ElementComparator());
     
        public void Push(int num)
        {
            if (!frequencyMap.TryAdd(num, 1))
            {
                frequencyMap[num]++;
            }
            var ele = new Element(num, frequencyMap[num], sequenceNumber++);
            maxHeap.Enqueue(ele, ele);
        }

        public int Pop()
        {
            int num = maxHeap.Dequeue().number;

            // decrement the frequency or remove if this is the last number
            if (frequencyMap[num] > 1)
                frequencyMap[num]--;
            else
                frequencyMap.Remove(num);

            return num;
        }

        class Element
        {
            public int number;
            public int frequency;
            public int sequenceNumber;

            public Element(int number, int frequency, int sequenceNumber)
            {
                this.number = number;
                this.frequency = frequency;
                this.sequenceNumber = sequenceNumber;
            }
        }

        class ElementComparator : IComparer<Element> {
            public int Compare(Element e1, Element e2)
            {
                if (e1.frequency != e2.frequency)
                    return e2.frequency - e1.frequency;
                // if both elements have same frequency, return the one that was pushed later 
                return e2.sequenceNumber - e1.sequenceNumber;
            }

        }
    }
}
