namespace LearnDSAlgorithms
{
    public class GraphQueuesLinkedNode
    {
        public int element;
        public GraphQueuesLinkedNode next;
        public GraphQueuesLinkedNode(int e, GraphQueuesLinkedNode n)
        {
            element = e;
            next = n;
        }
    }

    class GraphQueuesLinked
    {
        GraphQueuesLinkedNode front;
        GraphQueuesLinkedNode rear;
        int size;

        public GraphQueuesLinked()
        {
            front = null;
            rear = null;
            size = 0;
        }

        public int length()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void enqueue(int e)
        {
            GraphQueuesLinkedNode newest = new GraphQueuesLinkedNode(e, null);
            if (isEmpty())
                front = newest;
            else
                rear.next = newest;
            rear = newest;
            size = size + 1;
        }

        public int dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return -1;
            }
            int e = front.element;
            front = front.next;
            size = size - 1;
            if (isEmpty())
                rear = null;
            return e;
        }

        public void display()
        {
            GraphQueuesLinkedNode p = front;
            while (p != null)
            {
                Console.Write(p.element + " --> ");
                p = p.next;
            }
            Console.WriteLine();
        }
    }
}
