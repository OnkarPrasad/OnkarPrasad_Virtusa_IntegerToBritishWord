using System;
 
namespace OnkarPrasad_Virtusa_NumberToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int number;
            bool isValid;
            Console.WriteLine("\n Enter integer between 1 to 999999999 to get in British English words or Enter '0' to quit the program at any time\n");

            do
            {
                Console.WriteLine("\n Enter integer:\n");
                input = Console.ReadLine();
                isValid = int.TryParse(input, out number);
                if (number > 0)
                {
                    if (!isValid)
                        Console.WriteLine("\n  Not an integer, please try again\n");
                    else
                        Console.WriteLine("\n You have entered : {0}\n", GetConvertedNumberToBritishWord(number));
                }
                else
                {
                    Console.WriteLine("\n  Enter integer between 1 to 999999999 only \n");
                }
            }
            while (!(isValid && number == 0)) ;
            Console.WriteLine("\nProgram ended");
        }
        public static string GetConvertedNumberToBritishWord(int number)
        {
            if (number == 0) return "Zero";
            string and = "and ";  
            int[] num = new int[4];
            int first = 0;
            int ones, hundreds, tens;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
  
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };

            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                ones = num[i] % 10;              // ones
                tens = num[i] / 10;
                hundreds = num[i] / 100;             // hundreds
                tens = tens - 10 * hundreds;               // tens
                if (hundreds > 0) sb.Append(words0[hundreds] + "Hundred ");
                if (ones > 0 || tens > 0)
                {
                    if (hundreds > 0 || i < first) sb.Append(and);
                    if (tens == 0)
                        sb.Append(words0[ones]);
                    else if (tens == 1)
                        sb.Append(words1[ones]);
                    else
                        sb.Append(words2[tens - 2] + words0[ones]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
