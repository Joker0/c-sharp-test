using System;


class Program
{
    static void calculateMininumBus(int n, int[] familyMembers){
        if (n != familyMembers.Length)
        {
            Console.WriteLine("Input must be equal with count of family");
            return;       
        }

        int maxCapacity = 4;
        int busRequired = 0;
        int totalPassenger = 0;

        //Make dictionary
        Dictionary<int, int> dict = new Dictionary<int, int>();
        //count family members
        for (int i = 0; i < familyMembers.Length; i++)
        {
            if (dict.ContainsKey(familyMembers[i]))
            {
                dict[familyMembers[i]]++;
            }
            else
            {
                dict.Add(familyMembers[i], 1);
            }
        }
       
        //Sort dictionary
        var sortedDictionary = from entry in dict orderby entry.Value ascending select entry;
        // Sum value * key
        foreach (KeyValuePair<int, int> kvp in sortedDictionary)
        {
            totalPassenger += kvp.Key * kvp.Value;
        }

        if (totalPassenger % maxCapacity == 0){
            busRequired = totalPassenger / maxCapacity;
        } else if (totalPassenger % maxCapacity != 0){
            busRequired = totalPassenger / maxCapacity + 1;
        }
        Console.WriteLine("Minimum bus required is : " + busRequired );
    }
    static void Main(string[] args)
    {
        Console.Write("Input the number of families : ");
        string inputN = Console.ReadLine();

        Console.Write("Input the number of family members : ");
        string inputFamilyMembers = Console.ReadLine();
        string [] familyMembers = inputFamilyMembers.Split(' ');
        int [] familyMembersInt = Array.ConvertAll(familyMembers, int.Parse);

        calculateMininumBus(int.Parse(inputN), familyMembersInt);
    }
}

