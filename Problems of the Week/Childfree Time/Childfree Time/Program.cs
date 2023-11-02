using System.Diagnostics;

string info = Console.ReadLine();
int n = Convert.ToInt32(info.Split(" ")[0]);
int p = Convert.ToInt32(info.Split(" ")[1]);

List<string> list = new List<string>(); 
Dictionary<string,int> cache = new Dictionary<string,int>();
Stopwatch s = new Stopwatch();
s.Start();
for (int i = 0; i < p; i++)
{
    list.Add(Console.ReadLine());
}
s.Stop();
Console.WriteLine($"elapsed {s.Elapsed.TotalSeconds}");
s.Start();
var sums = new List<int>();
foreach (var item in list)
{
    var split = item.Split(" ");
    var parentKey = split[0] +"-"+ split[1];
    
    if(!cache.ContainsKey(parentKey))
    {
        var relatedListItems = list.Where(col => col.Split(" ")[0] == parentKey.Split("-")[1]).ToList();
        if (relatedListItems.Count != 0)
        {
            cache[parentKey]= 2 + Convert.ToInt32(split[2]);

            sums.AddRange(relatedListItems.Select(relatedItem => CalculatePortal(relatedItem, cache, list)));

            cache[parentKey] += sums.Max();
            sums.Clear();
        }
        else
        {
            cache[parentKey]= 2 + Convert.ToInt32(split[2]);
        }
    }
}
s.Stop();
Console.WriteLine($"Found it  {s.Elapsed.TotalSeconds}");
Console.WriteLine($"max {cache.OrderByDescending(col => col.Value).First().Value}");


static int CalculatePortal(string item, Dictionary<string, int> dic, List<string> list)
{
    var split = item.Split(" ");
    string key = split[0] +"-"+ split[1];
 
    switch (dic.ContainsKey(key))
    {
        case false:
        {
            dic[key] = 2 + Convert.ToInt32(split[2]);

            var relatedListItems = list.Where(col => col.Split(" ")[0] == key.Split("-")[1]).ToList(); // it will give the items starting from where last ended

            if (relatedListItems.Count != 0)
            {
                foreach (var relatedItem in relatedListItems)
                {
                    int count = CalculatePortal(relatedItem, dic, list);

                    dic[key] += count;
               
                }
                return dic[key];
            }

            return dic[key];
        }
        default:
            return dic[key];
    }
}
