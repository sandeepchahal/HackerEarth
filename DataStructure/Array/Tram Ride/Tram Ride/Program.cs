String line;
line = Console.ReadLine();
int N = Convert.ToInt32(line);
line = Console.ReadLine();
int start = Convert.ToInt32(line);
line = Console.ReadLine();
int finish = Convert.ToInt32(line);
line = Console.ReadLine();
int[] Ticket_cost = new int[N];
Ticket_cost = line.Split().Select(str => int.Parse(str)).ToArray();

long out_ = Solve(N, start, finish, Ticket_cost);

static long Solve(int N, int start, int finish, int[] Ticket_cost)
{
    // You must complete the logic for the function that is provided
    // before compiling or submitting to avoid an error.
    // Write your code here

    int hitCount = 0;
    long forwardCost = 0;
    long backwardCost = 0;
    int index = start-1;
    while (true)
    {
        if (hitCount == 0)
        {
            if (index == N )
            {
                index = 0;
            }
            else if(index == finish-1) 
            {
                hitCount = 1;
            }
            else
            {
                forwardCost += Ticket_cost[index];
                index++;
            }
        }
        else
        {
            if(index == N)
            {
                index = 0;
            }
            else
            {
                backwardCost += Ticket_cost[index];
                index++;
            }
            if(index == start - 1)
            {
                break;
            }

            if(backwardCost > forwardCost) 
            {
                break;
            }
        }
    }

    Console.WriteLine($"forward - {forwardCost} \n backward - {backwardCost}");
    return forwardCost>=backwardCost?backwardCost:forwardCost;

}