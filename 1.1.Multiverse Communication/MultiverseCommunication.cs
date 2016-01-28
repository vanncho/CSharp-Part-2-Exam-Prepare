using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1.Multiverse_Communication
{
    class MultiverseCommunication
    {
        static void Main()
        {
            string input = Console.ReadLine();;

            List<string> digits = new List<string>();
            string numberIn13thSystem = string.Empty;

            for (int i = 0; i < input.Length; i+=3)
            {
                string digit = string.Empty;
                digit = input.Substring(i, 3);
                digits.Add(digit);
            }

            foreach (string item in digits)
            {
                string temp = string.Empty;
                switch (item)
                {
                    case "CHU": temp = "0"; break;
                    case "TEL": temp = "1"; break;
                    case "OFT": temp = "2"; break;
                    case "IVA": temp = "3"; break;
                    case "EMY": temp = "4"; break;
                    case "VNB": temp = "5"; break;
                    case "POQ": temp = "6"; break;
                    case "ERI": temp = "7"; break;
                    case "CAD": temp = "8"; break;
                    case "K-A": temp = "9"; break;
                    case "IIA": temp = "A"; break;
                    case "YLO": temp = "B"; break;
                    case "PLA": temp = "C"; break;
                }
                numberIn13thSystem += temp;
            }

            long decimalRepresentation = 0;
            for (int i = 0; i < numberIn13thSystem.Length; i++)
            {

                decimalRepresentation *= 13;
                if (numberIn13thSystem[i] >= '0' && numberIn13thSystem[i] <= '9')
                {
                    decimalRepresentation += numberIn13thSystem[i] - '0';
                }
                else
                {
                    decimalRepresentation += numberIn13thSystem[i] + 10 - 'A';
                }
            }

            Console.WriteLine(decimalRepresentation);
        }
    }
}
