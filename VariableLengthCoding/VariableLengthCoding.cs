namespace VariableLengthCoding
{
    using System;
    using System.Text;

    class VariableLengthCoding
    {
        static void Main()
        {
            string[] firstInputLine = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder encodeStrings = new StringBuilder();

            foreach (var item in firstInputLine)
            {
                int number = int.Parse(item);
                encodeStrings.Append(Convert.ToString(number, 2).PadLeft(8, '0'));
            }

            int n = int.Parse(Console.ReadLine());

            char[] dictionary = new char[n + 1];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                char symbol = line[0];
                int index = int.Parse(line.Substring(1));
                dictionary[index] = symbol;
            }

            StringBuilder result = new StringBuilder();
            int count = 0;

            foreach (var ch in encodeStrings.ToString())
            {
                if (ch == '1')
                {
                    count++;
                }
                else
                {
                    result.Append(dictionary[count]);
                    count = 0;
                }
            }

            if (count > 0)
            {
                result.Append(dictionary[count]);
            }

            Console.WriteLine(result);
        }
    }
}
