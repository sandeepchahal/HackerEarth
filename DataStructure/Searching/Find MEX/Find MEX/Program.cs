int size = Convert.ToInt32(Console.ReadLine());
string[] s = Console.ReadLine()?.Split(' ');
int last = 0;
List<string> traversed = new List<string>();
for (int i = 0; i < size; i++)
{
    traversed.Add(s[i]);
    if (s[i] == last.ToString())
    {
        last = GetMEX(traversed, last);
    }
    Console.Write($"{last} ");
}
static int GetMEX(List<string> t, int last)
{
    while (true)
    {
        if (t.Contains(last.ToString()))
        {
            last++;
        }
        else
        {
            break;
        }
    }
    return last;
}