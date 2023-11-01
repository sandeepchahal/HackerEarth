int n = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int noOfArachers = Convert.ToInt32(Console.ReadLine());

    List<string> targets = Console.ReadLine().Split(' ').OrderByDescending(x => x).Distinct().ToList();

    long max = Convert.ToInt64(targets[0]);

    long count = max;
    List<string> newList = targets.Skip(1).ToList();
    while(true)
    {
        if(Compare(newList,max)) 
            break;
        max += count;
    }
    Console.WriteLine(max);
}


static bool Compare(List<string> list, long number)
{
    foreach(string target in list)
    {
        if(number % Convert.ToInt64(target) !=0)
            return false;
    }
    return true;
}