namespace Utilities
{
    public static class Graphs
    {
        public static void SetRandomEdge(bool[,] graph, int n)
        {
            bool found = false;
            int i = 0;
            int j = 0;

            int count = 0;
            System.Random random = new System.Random();

            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    if (graph[k, l])
                        continue;

                    count++;

                    if (random.Next(0, count) == 0)
                    {
                        found = true;
                        i = k;
                        j = l;
                    }
                }
            }

            if (found)
                graph[i, j] = true;
        }

        public static void SetRandomEdge(int[,] graph, int n)
        {
            bool found = false;
            int i = 0;
            int j = 0;

            int count = 0;
            System.Random random = new System.Random();

            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    if (graph[k, l] != int.MaxValue)
                        continue;

                    count++;

                    if (random.Next(0, count) == 0)
                    {
                        found = true;
                        i = k;
                        j = l;
                    }
                }
            }

            if (found)
                graph[i, j] = random.Next(1, 10);
        }
    }
}
