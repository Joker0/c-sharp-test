using System;
using System.Text;

class Program
{
    static string procVowel(string param)
    {
        if (string.IsNullOrEmpty(param))
        {
            return string.Empty;
        }

        // Constants
        const string VOWELS = "aeiou";

        // Convert to lowercase and extract vowels
        var vowelChars = param.ToLower()
                             .Where(c => VOWELS.Contains(c))
                             .ToArray();

        if (!vowelChars.Any())
        {
            return string.Empty;
        }

        // Make a dictionary of vowel counts
        var vowelCount = new Dictionary<char, int>();
        foreach (char vowel in VOWELS)
        {
            vowelCount[vowel] = 0;
        }

        // Count vowels
        foreach (char c in vowelChars)
        {
            vowelCount[c]++;
        }

        // Build result using StringBuilder and make distinct vowels
        var result = new StringBuilder(vowelChars.Length);
        var distinctVowels = vowelChars.Distinct();

        // Build result
        foreach (char vowel in distinctVowels)
        {
            result.Append(new string(vowel, vowelCount[vowel]));
        }

        return result.ToString();
    }

    static string procConsonant(string param)
    {
        if (string.IsNullOrEmpty(param))
        {
            return string.Empty;
        }

        // Constants
        const string CONSONANTS = "bcdfghjklmnpqrstvwxyz";

        // Convert to lowercase and extract consonants
        var consonantChars = param.ToLower()
                                 .Where(c => CONSONANTS.Contains(c))
                                 .ToArray();

        if (!consonantChars.Any())
        {
            return string.Empty;
        }

        // Make a dictionary of consonant counts
        var consonantCount = new Dictionary<char, int>();
        foreach (char consonant in CONSONANTS)
        {
            consonantCount[consonant] = 0;
        }

        // Count consonants
        foreach (char c in consonantChars)
        {
            consonantCount[c]++;
        }

        // Build result using StringBuilder and distinct consonants
        var result = new StringBuilder(consonantChars.Length);
        var distinctConsonants = consonantChars.Distinct();

        // Build result
        foreach (char consonant in distinctConsonants)
        {
            result.Append(new string(consonant, consonantCount[consonant]));
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.Write("Input one line of words (S) : ");
        string input = Console.ReadLine();

        string charVowel = procVowel(input);
        string charConsonant = procConsonant(input);

        Console.WriteLine("Vowel Characters : ");
        Console.WriteLine(charVowel);
        Console.WriteLine("Consonant Characters : ");
        Console.WriteLine(charConsonant);
    }
}