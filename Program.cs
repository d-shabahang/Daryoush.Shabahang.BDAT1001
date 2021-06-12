using Assignment_1_CharacterEncodingDataSecurityPrivacy.Models;
using System;
using System.Linq;
using System.Text;

namespace Assignment_1_CharacterEncodingDataSecurityPrivacy
{
    class Program
    {
        static void Main(string[] args)
        {
            // header text with my name and the course code
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Assignment #1 by Daryoush Shabahang (BDAT 1001)"));

            while (true)
            {
                // task #1 (user will enter their name)
                // add code that would receive a string from the user through the console
                Console.WriteLine("\nPlease enter your name:");
                string full_name = Console.ReadLine();
                
                // ask user for their age as well
                Console.WriteLine("\nHow old are you?");
                string age = Console.ReadLine();

                // ask user if they want to convert either their name or age
                Console.WriteLine("\nWould you like to convert your name or your age? Enter '1' for name or '2' for age:");
                string preference = Console.ReadLine();

                string choice;

                // the program will show the conversion based on the user's selection 
                if (Int32.Parse(preference) == 1)
                    choice = full_name;
                else
                    choice = age;

                // task #2 (Binary Converter)
                // add the Class file called BinaryConverter.cs. Write the code and convert your full name
                // to Binary. Output the Binary result to the console
                BinaryConverter binary_code = new BinaryConverter();
                string binary_data = binary_code.ConvertTo(choice); // encoding
                Console.WriteLine($"\nBinary of {choice} =>: {binary_data}");
                Console.WriteLine($"Binary to string {binary_data} =>: {binary_code.ConvertBinaryToString(binary_data)}"); // decoding

                // task #3 (Hexadecimal Converter)
                // add another Class file called HexadecimalConverter.cs. Convert your name to Hexadecimal format
                HexadecimalConverter hexa_code = new HexadecimalConverter();
                string hexadecimal_data = hexa_code.ConvertTo(choice);
                Console.WriteLine($"\n{choice} as Hexadecimal =>: {hexadecimal_data}");
                Console.WriteLine($"{choice} from Hexadecimal to the original string =>: {hexa_code.ConvertFromHexToASCII(hexadecimal_data)}");

                // task #4 (Base 64 Converter)
                // add another Class file called Base64Converter.cs. Write the code to convert your full name
                // to Base 64. Execute the code and print the results
                Base64Converter base64_code = new Base64Converter();
                string base64_data = base64_code.Base64Encode(choice); // encoding
                Console.WriteLine($"\nBase64 of {choice} =>: {base64_data}");
                string base64_to = base64_code.Base64StringDecode(base64_data); // decoding
                Console.WriteLine($"Base64 to the original string =>: {base64_to}");
                //Self study: decode part of Base64

                // task #5 (Encrypt/Decrypt)
                // add another Class file called EncryptDecrypt.cs. Write the code to encrypt your full name.
                // add another function that would receive an encrypted version of your name as input and print
                // decrypted a string. Execute the code and print the results
                string plaintext = choice;
                int encryptionDepth = 20;

                int[] key = Encoding.Unicode.GetBytes(plaintext).Select(x => Convert.ToInt32(x)).ToArray(); //Notice the use of Unicode
                for (int i = 0; i < key.Length; i++)
                {
                }
                string cipherasString = String.Join(",", key.Select(x => x.ToString())); //For display purposes
                Encrypter encrypter = new Encrypter(plaintext, key, encryptionDepth);
                //Single Level Encryption
                Console.WriteLine("\nThis is the single level encryption for your name: ");
                string nameEncryptWithCipher = Encrypter.EncryptWithCipher(plaintext, key);
                Console.WriteLine($"\nEncrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");
                string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, key);
                Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");
                //Deep Encryption
                Console.WriteLine("\nThis is the deep level encryption for your name: ");
                string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(plaintext, key, encryptionDepth);
                Console.WriteLine($"\nDeep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");
                string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, key, encryptionDepth);
                Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

                // the user can either try the conversion aagain or exit the program
                Console.WriteLine("\n~~~~Please enter a key type new information and get new results or type 'Exit' to leave~~~~\n");
                string e = Console.ReadLine();
                e = e.ToLower();
                if (e == "exit")
                    break;

                Console.Clear();
            }
        }
    }
}