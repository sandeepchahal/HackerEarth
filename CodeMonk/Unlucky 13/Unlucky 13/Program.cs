// See https://aka.ms/new-console-template for more information

Dictionary<int, long> cache = new Dictionary<int, long>();  
Console.WriteLine("Hello, World!");
String line;
line = Console.ReadLine();
int T = Convert.ToInt32(line);

for (int t_i = 0; t_i < T; t_i++)
{
    line = Console.ReadLine();
    long Num = Convert.ToInt64(line);

    long out_ = answer(Num);
    Console.Out.WriteLine(out_);
}

static long answer(long Num)
{
    int twoDigit = 99;
    int threeDigit = 980;

    if(Num.ToString().Length%2 ==0) // even split
    {

    }
    else
    {
        //odd split
    }

    return Num;
}