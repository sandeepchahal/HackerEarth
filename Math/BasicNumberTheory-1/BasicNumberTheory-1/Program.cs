// See https://aka.ms/new-console-template for more information

int n  = Convert.ToInt32(Console.ReadLine());
for (int index = 0; index < n; index++)
{
    int count = 0;
    int size = Convert.ToInt32(Console.ReadLine());
    List<int> list = Console.ReadLine().Split(" ").ToList().Select(col => Convert.ToInt32(col)).ToList();
    List<int> primeList = new List<int>();
    List<int> primeCache = new List<int>();
    foreach (var item in list)
    {
        if(IsPrime(item))
            primeList.Add(item);
    }

    if (primeList.Count > 2)
    {
        primeList.Sort();
        for (int i = 0; i < primeList.Count()-2; i++)
        {
            for (int j = i+2; j < primeList.Count(); j++)
            {
                int cal = primeList[i] * primeList[i + 1] * primeList[j];
                if (primeCache.Contains(cal))
                {
                    count++;
                }
                else
                {
                    if (IsPrime(cal))
                    {
                        primeCache.Add(cal);
                        count++;
                    }
                }
            }
        }
    }
    Console.WriteLine(count);
}

static bool IsPrime(int num)
{
    for (int i = 2; i <= num/2; i++)
    {
        if (num % i == 0)
            return false;
    }

    return true;
}