string info = Console.ReadLine();
int n = Convert.ToInt32(info.Split(" ")[0]);
int p = Convert.ToInt32(info.Split(" ")[1]);

List<string> list = new List<string>(); 
Dictionary<string,int> cache = new Dictionary<string,int>();
for (int i = 0; i < n; i++)
{
    list.Add(Console.ReadLine());
}

foreach (var item in list)
{
    string parentKey = item.Split(' ')[0] + item.Split(' ')[1];
    List<int> sums = new List<int>();
    if(!cache.ContainsKey(parentKey))
    {
        var relatedListItems = list.Where(col => col.Split(" ")[0] == parentKey[1].ToString()).ToList();

        if (relatedListItems.Count != 0)
        {
            cache[parentKey]= 2 + Convert.ToInt32(item.Split(' ')[2]);
           
            foreach (var relatedItem in relatedListItems)
            {
                sums.Add(CalculatePortal(relatedItem, cache, list));
            }

            cache[parentKey] += sums.Max();

        }
    }
}

Console.WriteLine(cache.OrderByDescending(col => col.Value).First().Value);
Console.ReadLine();

static int CalculatePortal(string item, Dictionary<string, int> dic, List<string> list)
{
    string key = item.Split(' ')[0] + item.Split(' ')[1];
 
    if (!dic.ContainsKey(key))
    {
        dic[key] = 2 + Convert.ToInt32(item.Split(' ')[2]);

        var relatedListItems = list.Where(col => col.Split(" ")[0] == key[1].ToString()).ToList(); // it will give the items starting from where last ended

        if (relatedListItems.Count != 0)
        {
            foreach (var relatedItem in relatedListItems)
            {
                int count = CalculatePortal(relatedItem, dic, list);

                dic[key] += count;
               
            }
            return dic[key];
        }
        else
        {
            return dic[key];
        }
    }
    else
    {
        return dic[key];
    }
}
