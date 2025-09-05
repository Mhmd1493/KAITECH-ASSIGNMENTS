using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace A1_CS_Fundamentals_Temp
{
    class Program
    {
        // Please use this Template for (A1- C# Fundamentals).
        // And follow the same approach for all other Assignments of (Programming Fundamentals using C#) course.

        static void Main(string[] args)
        {

            T10();

            Console.WriteLine("\n\n");
        }



        #region Helping Functions

        // 'Divide & Conquer' is always the best technique for solving problems.
        // You can always divide your big problem to small problems, and solve each apart.
        // Each small problem can be solved in a separate 'Function'.
        // Then you can gather these Functions to solve your big problem.
        // These 'Helping Functions' are exmaples for such aproach.
        // Feel free to use these two functions and create your own ones to help you solve your bigger problems.

        /// <summary>
        /// Ckecks if the input is numeric ('double') or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool IsDouble(string str)
        {
            return double.TryParse(str, out _);  // Search for 'Output Parameter' and learn how to use it.
        }

        /// <summary>
        /// Forces the user to enter a 'number' as an input.
        /// </summary>
        /// <remarks>
        /// (Defencive Coding)
        /// </remarks>
        /// <returns></returns>
        static double DoubleInput()
        {
            string input = Console.ReadLine();

            while (!IsDouble(input))
            {
                Console.WriteLine("Please, Enter a Valid Number");
                input = Console.ReadLine();
            }

            return double.Parse(input);
        }

        #endregion






        /// <summary>
        /// Write a C# program to count the total number of vowels in a string, and show the count of each vowel (A,E,I,O,U) separately.
        /// </summary>
        static void T1()
        {
            Console.WriteLine("Enter a string:");
            var text = Console.ReadLine();

            var lowertext = text.ToLower();

            int countA = 0, countE = 0, countI = 0, countO = 0, countU = 0;

            for (int i = 0; i < lowertext.Length; i++)
            {
                char c = lowertext[i];
                switch (c)
                {
                    case 'a': countA++; break;
                    case 'e': countE++; break;
                    case 'i': countI++; break;
                    case 'o': countO++; break;
                    case 'u': countU++; break;
                }
            }

            int total = countA + countE + countI + countO + countU;

            Console.WriteLine("\n--- Vowel Count ---");
            Console.WriteLine($"Total vowels: {total}");
            Console.WriteLine($"A: {0}", countA);
            Console.WriteLine($"E: {0}", countE);
            Console.WriteLine($"I: {0}", countI);
            Console.WriteLine($"O: {0}", countO);
            Console.WriteLine($"U: {0}", countU);
        }



        /// <summary>
        /// Write a C# program to count the total number of words in a string.
        /// </summary>
        static void T2()
        {
            Console.WriteLine("Enter a string:");
            var text = Console.ReadLine();

            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == ' ')
                {
                    count++;
                }
            }
            Console.WriteLine("Words={0}", count + 1);
            count = 0;
        }


        /// <summary>
        /// Write a C# program to replace the following words with the given ones in the following sentence.
        ///Sentence: “Hello Sameh, Welcome to Structural BIM Track.This is Round 1.”
        /// </summary>
        static void T3()
        {
            var sentence = "Hello Sameh, Welcome to Structural BIM Track. This is Round 1.";
            Console.WriteLine(sentence
                .Replace("Sameh", "Mohamed")
                .Replace("Structural BIM Track", "BIM Application Development Track")
                .Replace("1", "9")
                );
        }


        /// <summary>
        /// Write a C# program to check whether a given word is present in a given sentence.
        /// </summary>
        static void T4()
        {
            Console.WriteLine("Enter a sentence:");
            string sentence = Console.ReadLine();

            Console.WriteLine("Enter the word to search:");
            string word = Console.ReadLine();

            bool found = sentence.Contains(word);

            if (found)
            {
                Console.WriteLine("The word {0} is present in the sentence.", word);
            }
            else
            {
                Console.WriteLine("The word {0} is not present in the sentence.", word);
            }
        }


        /// <summary>
        /// Write a C# program that takes a sentence and a word from it, then extracts a substring from that word based on a starting index and length.
        /// </summary>
        static void T5()
        {
            Console.WriteLine("Input sentence:");
            string sentence = Console.ReadLine();

            Console.WriteLine("Input word to extract from:");
            string word = Console.ReadLine();

            Console.WriteLine("Input Index to Start Extraction from:");
            var index_of_extract = int.Parse(Console.ReadLine());

            Console.WriteLine("Input The Length of Substring:");
            var length = int.Parse(Console.ReadLine());

            int index_of_word = sentence.IndexOf(word);

            int startIndex = index_of_extract - 1;

            var sb = new StringBuilder();
            for (int i = startIndex; i < startIndex + length; i++)
            {
                sb.Append(word[i]);
            }
            Console.WriteLine(sb);
        }


        /// <summary>
        /// Write a C# program to check if the first character of each word in a sentence is uppercase or not.
        /// </summary>
        /// <remarks>
        /// If not, print the word that doesn’t follow the condition, After checking,
        /// display the corrected sentence where each word starts with an uppercase letter.
        /// </remarks>
        static void T6()
        {
            Console.WriteLine("Input sentence:");
            string text = Console.ReadLine();

            var originalwords = text.Split(' ');
            int incorrectwords = 0;
            string correctedSentence = "";

            for (int i = 0; i < originalwords.Length; i++)
            {
                string word = originalwords[i];

                // check if the first character is uppercase
                if (word.Length > 0 && !char.IsUpper(word[0]))
                {
                    incorrectwords++;
                    Console.WriteLine("Incorrect word: " + word);
                }

                // build corrected word
                string correctedword =
                    word.Length > 0
                    ? char.ToUpper(word[0]) + (word.Length > 1 ? word.Substring(1).ToLower() : "")
                    : "";

                correctedSentence += correctedword + " ";
            }

            Console.WriteLine();
            Console.WriteLine("Number of incorrect words: " + incorrectwords);
            Console.WriteLine("Corrected sentence: " + correctedSentence.Trim());
        }






        /// <summary>
        /// Write a C# program to search the index of the first occurrence of a given character within a sentence.
        /// </summary>
        /// <remarks>
        /// If the character doesn’t exist in the sentence, print a message.
        /// </remarks>
        static void T7()
        {

            Console.WriteLine("Input sentence:");
            string text = Console.ReadLine();

            Console.WriteLine("Input required character:");
            char searchchar = char.Parse(Console.ReadLine());

            var originalwords = text.Split(' ');
            bool found = false;

            for (int i = 0; i < originalwords.Length; i++)
            {
                string word = originalwords[i];

                if (word.Length > 0 && word.IndexOf(searchchar) >= 0)
                {
                    Console.WriteLine("In word {0}, character found at index: {1}", word, word.IndexOf(searchchar));
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("The required character {0} was not found in the sentence.", searchchar);
            }
        }



        /// <summary>
        /// Write a C# program to read a sentence from the user and replace lowercase characters with uppercase ones.
        /// For Example:
        /// Input Sentence: “Hello World”
        /// Expected Output: “HELLO WORLD”
        /// </summary>
        static void T8()
        {
            Console.WriteLine("Input sentence:");
            string text = Console.ReadLine();

            var originalwords = text.Split(' ');
            int incorrectwords = 0;
            string correctedSentence = "";

            for (int i = 0; i < originalwords.Length; i++)
            {
                string word = originalwords[i];

                // build corrected word
                string correctedword =
                    word.Length > 0
                    ? char.ToUpper(word[0]) + (word.Length > 1 ? word.Substring(1).ToUpper() : "")
                    : "";

                correctedSentence += correctedword + " ";
            }

            Console.WriteLine("Corrected sentence: " + correctedSentence.Trim());

        }





        /// <summary>
        /// Write a C# program to reverse a given sentence either by characters or by words, based on user choice.
        /// Note: If reversed by characters, print each character in reverse order with one space between them.
        /// Note: If reversed by words, reverse the order of words in the sentence, keeping each word intact.
        /// Note: Eliminate spaces in the first or the last position of the string.
        /// For Example:
        /// Input: “Hello World”
        /// Input reverse type(1 - By Characters, 2 - By Words): 1
        /// Expected Output: “d l r o W o l l e H”
        /// Input sentence: Hello World From KAITECH
        /// Input reverse type(1 - By Characters, 2 - By Words): 2
        /// Expected Output: KAITECH From World Hello
        /// </summary>
        static void T9()
        {
            Console.WriteLine("Input sentence:");
            string text = Console.ReadLine().Trim();

            Console.WriteLine("Input reverse type (1 - By Characters, 2 - By Words):");
            int reverse_choice = int.Parse(Console.ReadLine());

            switch (reverse_choice)
            {
                case 1:
                    for (int i = text.Length - 1; i >= 0; i--)
                    {
                        Console.Write(text[i] + " ");
                    }
                    Console.WriteLine();
                    break;

                case 2:
                    var originalwords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int i = originalwords.Length - 1; i >= 0; i--)
                    {
                        Console.Write(originalwords[i] + " ");
                    }
                    Console.WriteLine();
                    break;
            }
        }


            /// <summary>
            /// Write a C# program to find the maximum occurring character in a string.
            /// Note: If there’s more than one character that has the maximum occurring value, get the first one only.
            /// Note: Ignore the case sensitivity.
            /// For Example:
            /// Input: “HELLO World”
            /// Expected Output: “The Highest frequency of character 'L' appears 3 times”.
            /// </summary>
            static void T10()
            {
                Console.WriteLine("Input sentence:");
                string text = Console.ReadLine() ?? string.Empty;

                // Case-insensitive: work in uppercase
                string s = text.ToUpperInvariant();

                int[] freq = new int[26];        // frequency per A..Z
                int[] firstPos = new int[26];    // first occurrence position to break ties
                for (int i = 0; i < 26; i++) firstPos[i] = int.MaxValue;

                // Count only letters A..Z; ignore others
                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    if (c >= 'A' && c <= 'Z')
                    {
                        int idx = c - 'A';
                        freq[idx]++;
                        if (firstPos[idx] == int.MaxValue) firstPos[idx] = i;
                    }
                }

                // Find max; if tie, pick the one that appears first in the string
                int maxCount = 0;
                int bestIdx = -1;
                int bestFirst = int.MaxValue;

                for (int i = 0; i < 26; i++)
                {
                    if (freq[i] > maxCount || (freq[i] == maxCount && firstPos[i] < bestFirst))
                    {
                        maxCount = freq[i];
                        bestIdx = i;
                        bestFirst = firstPos[i];
                    }
                }
                if (bestIdx == -1)
                {
                    Console.WriteLine("No alphabetic characters found.");
                }
                else
                {
                    char bestChar = (char)('A' + bestIdx);
                    Console.WriteLine($"The Highest frequency of character '{bestChar}' appears {maxCount} times.");
                }


            }
        }
    }





