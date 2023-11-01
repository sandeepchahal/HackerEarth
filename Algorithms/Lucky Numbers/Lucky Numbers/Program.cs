using System.Diagnostics;

string n = Console.ReadLine();

// let's find in the lesser 

string min = string.Empty;
string max = string.Empty;

int count = 0;


if (n.Contains("0"))
{
    for (int i = 0; i < n.Length - 1; i++)
    {
        min += "9";
    }
}
else
{
    for (int i = 0; i < n.ToString().Length; i++)
    {
        if (count == n.ToString().Length)
        {
            break;
        }
        if (char.GetNumericValue(n[i]) % 2 == 0)
        {
            min += char.GetNumericValue(n[i]) - 1;
            count++;
            for (int j = i + 1; j < n.Length; j++)
            {
                min += "9";
                count++;
            }
        }
        else
        {
            min += n[i].ToString();
            count++;
        }
    }

}
count = 0;

for (int i = 0; i < n.ToString().Length; i++)
{
    if (count == n.ToString().Length)
    {
        break;
    }
    if (char.GetNumericValue(n[i]) % 2 == 0)
    {
        max += char.GetNumericValue(n[i]) + 1;
        count++;
        for (int j = i + 1; j < n.Length; j++)
        {
            max += "1";
            count++;
        }
    }
    else
    {
        max += n[i].ToString();
        count++;
    }
}

Console.WriteLine($"{min} {max}");

if (Convert.ToInt64(n) - Convert.ToInt64(min) <= Convert.ToInt64(max) - Convert.ToInt64(n))
{
    Console.WriteLine(min);
}
else
{
    Console.WriteLine(max);
}


