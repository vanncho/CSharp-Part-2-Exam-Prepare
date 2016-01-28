using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4.Decode_and_Decrypt
{
    class DecodeAndDecrypt
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var inputInList = new List<int>();

            //takes the length of the cypher
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(input[i]))
                {
                    inputInList.Add(input[i] - '0');
                }
                if (char.IsLetter(input[i]))
                {
                    break;
                }
            }

            inputInList.Reverse();
            int cypherLength = 0;
            var number = new StringBuilder();

            foreach (var digit in inputInList)
            {
                cypherLength *= 10;
                cypherLength += digit;
            }

            string inputWithoutLength = input.Substring(0, (input.Length - inputInList.Count));

            //Decode the text
            var text = new StringBuilder();
            int repeatChar = 0;

            foreach (var symbol in inputWithoutLength)
            {
                if (char.IsDigit(symbol))
                {
                    repeatChar *= 10;
                    repeatChar += int.Parse(symbol.ToString());
                }
                else
                {
                    if (repeatChar == 0)
                    {
                        text.Append(symbol);
                    }
                    else
                    {
                        text.Append(symbol, repeatChar);
                        repeatChar = 0;
                    }
                }
            }
            
            string cypher = (text.ToString()).Substring(text.Length - cypherLength, cypherLength);
            string message = (text.ToString()).Substring(0, text.Length - cypherLength);
            
            var decryptedTextTemp = new StringBuilder();
            var decryptedTextFinal = new StringBuilder(message);
            int count = 0;

            //var steps = Math.Max(message.Length, cypher.Length);
            //for (int step = 0; step < steps; step++)
            //{
            //    var messageIndex = step % message.Length;
            //    var cypherIndex = step % cypher.Length;
            //    decryptedTextFinal[messageIndex] = (char)(((decryptedTextFinal[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
            //}
            //Console.WriteLine(decryptedTextFinal);

            //If the cypher string the message string are equals
            if (message.Length == cypher.Length)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    char xor = (char)(((message[i] - 'A') ^ (cypher[i] - 'A')) + 'A');
                    decryptedTextTemp.Append(xor.ToString());
                }
            
                Console.WriteLine(decryptedTextTemp);
            }
            
            //If the cypher string is shorter than the message
            if (message.Length > cypher.Length)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    if (count == cypher.Length)
                    {
                        count = 0;
                    }
                
                    char xor = (char)(((message[i] - 'A') ^ (cypher[count] - 'A')) + 'A');
                
                    decryptedTextTemp.Append(xor.ToString());
                    count++;
                }
                
                Console.WriteLine(decryptedTextTemp);
            }
            //If the message string is shorter than the cypher
            if (message.Length < cypher.Length)
            {
                string tempSbuilder = cypher.Substring(message.Length, (cypher.Length - message.Length));
                for (int i = 0; i < message.Length; i++)
                {
                    char xor = (char)(((message[i] - 'A') ^ (cypher[count] - 'A')) + 'A');
            
                    decryptedTextTemp.Append(xor.ToString());
                }
                for (int j = 0; j < tempSbuilder.Length; j++)
                {
                    char xor = (char)(((tempSbuilder[j] - 'A') ^ (decryptedTextTemp[j] - 'A')) + 'A');
            
                    decryptedTextFinal.Append(xor.ToString());
                }
            
                decryptedTextTemp.Remove(0, decryptedTextFinal.Length);
                decryptedTextFinal.Append(decryptedTextTemp);
                Console.WriteLine(decryptedTextFinal);
            }
        }
    }
}
