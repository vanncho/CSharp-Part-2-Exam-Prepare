namespace VariableLengthCoding_Video
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class VariableLengthCodingVideo
    {
        static void Main()
        {
            var numbersAsStrings = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder encodedString = new StringBuilder();

            foreach (var str in numbersAsStrings)
            {
                var num = int.Parse(str);
                encodedString.Append(Convert.ToString(num, 2).PadLeft(8, '0'));
            }

            int n = int.Parse(Console.ReadLine());
            char[] dictionary = new char[n + 1];

            for (int i = 0; i < n; i++)
            {
                ///////////////////////////////////////////// Da vidq kakvo tochno praviat dolnite
                var line = Console.ReadLine();
                char symbol = line[0];
                int index = int.Parse(line.Substring(1));
                dictionary[index] = symbol;
            }

            StringBuilder decoded = new StringBuilder();
            int once = 0;
            foreach (var ch in encodedString.ToString())
            {
                if (ch == '1')
                {
                    once++;
                }
                else
                {
                    decoded.Append(dictionary[once]);
                    once = 0;
                }
            }

            if (once > 0)
            {
                decoded.Append(dictionary[once]);
            }

            Console.WriteLine(decoded);
        }
    }
}
