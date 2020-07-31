using System;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string patternEmoji = @"(:{2}|\*{2})(?<name>[A-Z][a-z]{2,})\1";
            string numbersPattern = @"\d";

            var numbers = Regex.Matches(input, numbersPattern);

            ulong coolThreshold = 1;

            foreach (Match num in numbers)
            { ulong currentNum = ulong.Parse(num.Value);
                coolThreshold *= currentNum;
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");

            MatchCollection emojies = Regex.Matches(input, patternEmoji);

            Console.WriteLine($" {emojies.Count} emojis found in the text. The cool ones are:");

            foreach (Match item in emojies)
            {
                ulong emojiCoolness = 0;
                var name = item.Groups["name"].ToString();
                for (int i = 0; i < name.Length; i++)
                {
                                        
                    var numOfchar = name[i];
                    emojiCoolness += numOfchar;
                }
                if (emojiCoolness>coolThreshold)
                {
                    Console.WriteLine(item.Value);
                }
            }

        }
    }
}
