using System;
using System.Collections.Generic;
using System.Text;

namespace N_puzz
{
    class queue
    {

        public List<Node> AllNodes;
        public Dictionary<string, int> check;

        // O(1)
        public queue()
        {
            AllNodes = new List<Node>();
            check = new Dictionary<string, int>();
        }

        // O(1)
        public void swap(List<Node> nodes, int firstIndex, int secandIndex)
        {
            Node node = nodes[firstIndex];
            nodes[firstIndex] = nodes[secandIndex];
            nodes[secandIndex] = node;
        }

        // O(log(N))
        public void push(Node node)
        {
            AllNodes.Add(node);

            //O(1)
            if (!check.ContainsKey(node.ID))
                check.Add(node.ID, 0);

            check[node.ID]++;
            int lastIndex = AllNodes.Count - 1;

            // O(log(N))
            while (lastIndex > 0)
            {

                int middleIndex = (lastIndex - 1) / 2;

                // O(1)
                if (AllNodes[lastIndex].finalcost.CompareTo(AllNodes[middleIndex].finalcost) < 0)
                {
                    swap(AllNodes, lastIndex, middleIndex);
                }
                lastIndex = middleIndex;
            }
        }

        //O(1)
        public int leftChild(int index)
        {
            return index * 2 + 1;
        }

        //O(1)
        public int rightChild(int index)
        {
            return index * 2 + 2;
        }

        // O(log(N))
        public Node pop()
        {
            int lastindex = AllNodes.Count - 1;
            Node frontItem = AllNodes[0];
            check[AllNodes[0].ID]--;
            // O(1)
            if (check[AllNodes[0].ID] == 0)
                check.Remove(AllNodes[0].ID);
            AllNodes[0] = AllNodes[lastindex];
            AllNodes.RemoveAt(lastindex);
            --lastindex;

            // O(log(N))
            minHeap(0, lastindex);

            return frontItem;
        }

        // O(N)
        public void minHeap(int parentIndex, int lastindex)
        {

            int leftIndex = leftChild(parentIndex);
            int rigthIndex = rightChild(parentIndex);

            // O(1)
            if (leftIndex < lastindex && AllNodes[rigthIndex].finalcost <= AllNodes[leftIndex].finalcost)
                leftIndex = rigthIndex;

            // O(1)
            if (rigthIndex < lastindex && AllNodes[parentIndex].finalcost <= AllNodes[leftIndex].finalcost)
            {
                leftIndex = parentIndex;
            }

            // O(N)
            if (leftIndex <= lastindex && leftIndex != parentIndex)
            {
                swap(AllNodes, leftIndex, parentIndex); //O(1)
                minHeap(leftIndex, lastindex);//O(N)
            }
        }

        // O(1)
        public Node frontelement()
        {
            Node frontItem = AllNodes[0];
            return frontItem;
        }

        // O(1)
        public int size()
        {
            return AllNodes.Count;
        }

    }
}
