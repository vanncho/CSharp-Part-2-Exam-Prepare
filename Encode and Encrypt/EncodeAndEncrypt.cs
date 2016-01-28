namespace Encode_and_Encrypt
{
    using System;
    using System.Text;

    class EncodeAndEncrypt
    {
        static void Main()
        {
            string message = Console.ReadLine().Trim();
            string cypher = Console.ReadLine().Trim();

            var encrypt = EncryptText(message, cypher);
            cypher = ProcessTheCypher(cypher);

            Console.WriteLine(encrypt.ToString() + cypher);

        }

        private static string ProcessTheCypher(string cypher)
        {
            StringBuilder temp = new StringBuilder();

            int cypherLength = cypher.Length;
            int countSymbol = 1;
            char currentSymbol = new char();

            for (int i = 0; i < cypher.Length - 1; i++)
            {
                currentSymbol = cypher[i];

                if (currentSymbol == cypher[i + 1])
                {
                    countSymbol++;
                }
                else
                {
                    if (countSymbol > 2)
                    {
                        temp.Append(countSymbol.ToString());
                        temp.Append(currentSymbol);
                        countSymbol = 1;
                    }
                    else
                    {
                        temp.Append(currentSymbol, countSymbol);
                        countSymbol = 1;
                    }
                }
            }

            if (countSymbol > 2)
            {
                temp.Append(countSymbol.ToString());
                temp.Append(currentSymbol);
            }
            else if (countSymbol == 2)
            {
                temp.Append(currentSymbol, countSymbol);
                countSymbol = 1;
            }
            else if (countSymbol < 2)
            {
                temp.Append(cypher[cypher.Length - 1]);
            }

            temp.Append(cypher.Length.ToString());
            return temp.ToString();
        }

        private static StringBuilder EncryptText(string message, string cypher)
        {
            StringBuilder encrypt = new StringBuilder();

            //If the cypher string is shorter than the message
            if (cypher.Length < message.Length)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    int cypherIndex = i % cypher.Length;
                    int temp = (message[i] - 'A') ^ (cypher[cypherIndex] - 'A');
                    char encryptedChar = (char)(temp + 'A');

                    encrypt.Append(encryptedChar);
                }
            }

            //If the message string is shorter than the cypher
            if (message.Length < cypher.Length)
            {
                string rest = cypher.Substring(message.Length, cypher.Length - message.Length);
                for (int i = 0; i < message.Length; i++)
                {
                    int messageIndex = i % message.Length;
                    int temp = (cypher[i] - 'A') ^ (message[messageIndex] - 'A');
                    char encryptedChar = (char)(temp + 'A');

                    if (i <= rest.Length - 1)
                    {
                        int restIndex = i % rest.Length;
                        temp = (encryptedChar - 'A') ^ (rest[restIndex] - 'A');
                        encryptedChar = (char)(temp + 'A');
                    }

                    encrypt.Append(encryptedChar);
                }
            }

            return encrypt;
        }
    }
}
