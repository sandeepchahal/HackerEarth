
string[] f = File.ReadAllLines(@"C:\Users\SandeepSingh\OneDrive - Leapwork A S\Pictures\Personal\HackerEarth\DataStructure\Array\MinimumLength\MinimumLength.txt");

int n = Convert.ToInt32(f[0]);
for (int i = 0; i < n; i++)
{
    int size = Convert.ToInt32(f[1]);
    int subArrayLength = 2;
    string a1 = f[2];
    string a2 = f[3];

    var a = a1.Split(' ').ToList();
    var b = a2.Split(' ').ToList();

    int index = 0;
    int result = -1;
    var sub1 = new List<string>();
    var sub2 = new List<string>();

    while (subArrayLength < size)
    {
       
        for (int count = index; count < index + subArrayLength; count++)
        {
            //10 5630 10715 1592
            sub1.Add(a[count]);
            sub2.Add(b[count]);

        }

        sub1.Sort();
        sub2.Sort();

        if (CompareList(sub1, sub2))
        {
            result = subArrayLength;
            break;
        }
        else
        {
            sub1.Clear(); 
            sub2.Clear();
            index++;
        }

        if ((index-1) + subArrayLength == size)
        {
            index = 0;
            subArrayLength++;
        }

    }

    Console.WriteLine(result);
}

static bool CompareList(List<string> a, List<string> b)
{
    for (int i = 0; i < a.Count(); i++)
    {
        if (a[i] != b[i])
            return false;
    }
    return true;
}
Console.ReadLine();