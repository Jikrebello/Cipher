using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //create the loop for encoding or deciphering text
            while (true)
            {
                Console.WriteLine("Enter 1 to encode a message.");
                Console.WriteLine("Enter 2 to decode a message.");
                Console.WriteLine("Enter 0 to exit." + Environment.NewLine);
                string input = Console.ReadLine();

                // the user has chosen to encode a message
                if (input == "1")
                {
                    // 1) Get message as string from user
                    Console.Write("Type the message you wish to encode: ");
                    string rawMessage = Console.ReadLine();

                    // 2) Encode string into base64
                    List<byte> byteList = new List<byte>();
                    foreach (char _char in rawMessage)
                        byteList.Add((byte)_char);

                    string base64String = Convert.ToBase64String(byteList.ToArray());

                    // 3) get each char in the string and convert it to a byte value in the string
                    List<byte> byteValuesList = new List<byte>();
                    foreach (char _char in base64String)
                        byteValuesList.Add((byte)_char);

                    // 4) turn the byte values into hex values
                    StringBuilder hex = new StringBuilder(byteValuesList.Count * 2);
                    foreach (byte _byte in byteValuesList)
                        hex.AppendFormat("{0:x2}", _byte);

                    string hexString = hex.ToString();

                    // 5) convert the hex into dec and output the final result in a string
                    string decodedString = "";
                    foreach (char _char in hexString)
                        decodedString += ((byte)_char).ToString() + " ";

                    Console.WriteLine(Environment.NewLine + "Your encoded message is: " + Environment.NewLine + decodedString + Environment.NewLine);
                }
                // the user has chosen to decode a message
                else if (input == "2")
                {
                    // 1) Get message as string from user
                    Console.Write(Environment.NewLine + "Type the message you wish to decode: ");
                    string codedMessage = Console.ReadLine();

                    // 2) Split the string and place each value into a list<int>
                    char[] spilter = { ' ' };
                    string[] splitList = codedMessage.Split(spilter);

                    List<int> numbersList = new List<int>();

                    foreach (string _str in splitList)
                        numbersList.Add(Convert.ToInt32(_str));

                    // 3) Convert each int from numbers into a char and put that into a char list
                    List<char> asciiValuesFromNumbersList = new List<char>();

                    foreach (int _num in numbersList)
                        asciiValuesFromNumbersList.Add((char)_num);

                    // 4) Join the x and the x + 1 chars together into a string list
                    List<string> hexValuesFromAscii = new List<string>();

                    for (int i = 0; i < asciiValuesFromNumbersList.Count - 1; i += 2)
                        hexValuesFromAscii.Add(asciiValuesFromNumbersList[i].ToString() + asciiValuesFromNumbersList[i + 1].ToString());

                    // 5) Convert each string from hexValuesFromAscii into an int and put that into an int list
                    List<int> decimalsFromHex = new List<int>();

                    foreach (string hexVal in hexValuesFromAscii)
                        decimalsFromHex.Add(Convert.ToInt32(hexVal, 16)); // converts hex to dec very  nicely.

                    // 6) Convert each int from decimalsFromHex into a char and put that into an char list
                    List<char> asciiFromDecimals = new List<char>();

                    foreach (int _num in decimalsFromHex)
                        asciiFromDecimals.Add((char)_num);

                    // 7) Put the char list into a string
                    string base64String = new string(asciiFromDecimals.ToArray());

                    // 8) Convert the string using base 64
                    byte[] conversion = Convert.FromBase64String(base64String);
                    string result = Encoding.ASCII.GetString(conversion);

                    // 9) Output the result
                    Console.WriteLine(Environment.NewLine + "Your decoded message is: " + Environment.NewLine + "--- " + result + " ---" + Environment.NewLine);
                }
                // the user wants to exit
                else if (input == "0")
                {
                    Console.WriteLine("Thank you, good bye!.");
                    break;
                }
            }
        }
    }
}
