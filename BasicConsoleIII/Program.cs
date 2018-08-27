using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleIII
{
    /// <summary>
    /// Main Program and Class for BasicConsoleIII
    /// Decision Making and Loops
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point for the application.
        /// Prints out the user menu to display activities such as:
        /// Making Change, Counting Letters, and Guessing Numbers
        /// Allows the user to choose the activity and start the fun game!
        /// </summary>
        /// <param name="args">None processes</param>
        static void Main(string[] args)
        {
            string choice = string.Empty;   // string input for user data entry

            // Main Menu Loop + User Choice Prompt
            while(choice.ToUpper() != "Q")
            {
                // Print out the menu choices
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please chose an activity:");
                Console.WriteLine("A.Making change");
                Console.WriteLine("B.Counting letters");
                Console.WriteLine("C.Number guessing game");
                Console.WriteLine("Q.Quit");

                // Prompt for the user input
                Console.Write("Your choice: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                choice = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                // Match the user input to a particular game
                switch (choice.ToUpper())
                {
                    case "A": 
                        MakingChange();         // Play the Making Change Game!
                        break;
                    case "B":
                        CountingLetters();      // Play the Counting Letters Game!    
                        break;
                    case "C":
                        NumberGuessingGame();   // Play the Number Guessing Game!
                        break;
                } // end of switch statement
            } // end of while loop
        } // end of main method

        /// <summary>
        /// This method will prompt the user for an amount due, amount paid, and will 
        /// indicate how much money is to be returned and the count of each currency 
        /// denomination expected. So, if the amount due is $7.81 and the amount paid 
        /// is $10.00, then $2.19 is expected as change. This change is comprised of 
        /// the following denominations:
        ///$1: 2
        ///10¢: 1
        ///5¢: 1
        ///1¢: 4
        /// </summary>
        private static void MakingChange()
        {
            string input = string.Empty;    // string for user input text representation of a number
            decimal due;                    // money that is amount due
            decimal paid;                   // money that is amount paid
            decimal change = 0.0M;          // money that is change due
            int[] counts = new int[11];     // integer array to represent counts of denomination below

            // money array representing denominations of money.
            decimal[] denominations = {100M, 50M, 20M, 10M, 5M, 1M, 0.50M, 0.25M, 0.10M, 0.05M, 0.01M};
            
            // Ask User Input for Amount Due and Validate
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the amount due: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

            } while (!Decimal.TryParse(input.Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out due));
            // Ends only when text is valid money value

            // Ask User Input for Amount Paid and Validate
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter the amount paid: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

            } while (!Decimal.TryParse(input.Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out paid));
            // Ends only when text is valid money value

            // If Amount Paid < Due then We cannot give change
            if (paid < due)
            {
                Console.WriteLine("You did not pay enough so no change is due. ");
            }
            // If amount paid equals amount due then no change is due
            else if (paid == due)
            {
                Console.WriteLine("Amount paid is equal to amount due. No change is due. ");
            }
            // Determine the change due and the denominations to give 
            else
            {
                change = paid - due;
                Console.WriteLine($"The following change is due: {change:C2}");

                // Determine Denominations of Change as a Count in Array
                while (change > 0)
                {
                    for (int i = 0; i < denominations.Length; i++)
                    {
                        while(change >= denominations[i])
                        {
                            counts[i]++;
                            change -= denominations[i];
                        }
                    } // end of for
                } // end of while

                // Output the results to the screen
                for (int i = 0; i < counts.Length; i++)
                {
                    if(counts[i] > 0)
                    {
                        Console.WriteLine("{0,10:C2}: {1,4}", denominations[i], counts[i]);
                    }
                } // end of for loop
            } // end of else
        } // end of MakingChange()

        /// <summary>
        /// This method will have you prompt the user for a string, called input, and 
        /// will report the statistics of the types and counts of the characters 
        /// contained within it including 
        /// 
        /// Total Characters
        /// Vowels
        /// Consonants
        /// Digits
        /// Whitespace
        /// Punctuation
        /// Symbols
        /// Other
        /// </summary>
        private static void CountingLetters()
        {
            string input = string.Empty;    // text for user input     
            int vowels = 0;                 // number of vowels in the text
            int digits = 0;                 // number of digits in the text
            int punctuation = 0;            // number of punctuation marks in the text
            int symbols = 0;                // number of symbols in the text
            int whitespace = 0;             // number of white spaces in the text
            int unknown = 0;                // number of unknown characters in the text
            int characters = 0;             // total number of characters in the text
            int consonants = 0;             // number of consonants in the text
            int letters = 0;                // number of letters in the text

            // character array of vowels // note we are not doing the y analysis
            char[] vowelsChar = new char [] { 'A', 'E', 'I', 'O', 'U' };

            // Ask user to enter a text string 
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please enter text to analyze: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // Determine Total Number of Characters
            characters = input.ToCharArray().Length;

            // Determine Number of Vowels
            vowels = FindCharacterCount(vowelsChar, input.ToUpper());

            // Determine Other Values
            foreach (char item in input.ToCharArray())
            {
                // Determine Number of Letters
                if (char.IsLetter(item))
                {
                    letters++;
                }
                // Determine Number of Digits
                if (char.IsDigit(item))
                {
                    digits++;
                }
                // Determine Number of Symbols
                if (char.IsSymbol(item))
                {
                    symbols++;
                }
                // Determine Number of White Spaces
                if (char.IsWhiteSpace(item))
                {
                    whitespace++;
                }
                // Determine Number of Punctuation Marks
                if (char.IsPunctuation(item))
                {
                    punctuation++;
                }
            } // end of foreach loop for other values

            // Determine Number of Consonants
            consonants = letters - vowels;

            // Determine Unknown Characters
            unknown = characters - digits - vowels - punctuation - consonants - whitespace - symbols;

            // Output results to screen
            Console.WriteLine($"The text contains {characters} characters with the following characteristics:");
            Console.WriteLine("{0,4} consonants", consonants);
            Console.WriteLine("{0,4} vowels", vowels);
            Console.WriteLine("{0,4} digits", digits);
            Console.WriteLine("{0,4} punctuation", punctuation);
            Console.WriteLine("{0,4} symbols", symbols);
            Console.WriteLine("{0,4} whitespace", whitespace);
            Console.WriteLine("{0,4} unknown", unknown);

        } // end of method CountingLetters()

        /// <summary>
        /// This method takes a character array of characters to search against the
        /// string input to determine if the character is in the string and how many 
        /// times it is found. The method returns the found count. 
        /// </summary>
        /// <param name="items">character array of items to find</param>
        /// <param name="input">string of text to search against to find the characters</param>
        /// <returns>count: number of times it found the character in the input string</returns>
        public static int FindCharacterCount(char[] items, string input)
        {
            string newInput = input;    // copy of the input string of text
            int indexFound;             // index of where the specific character was found
            int count = 0;              // Number of characters found in the string

            for (int i = 0; i < items.Length; i++) // loops through all the possible character possibilities
            {
                char item = items[i];

                do
                {
                    indexFound = newInput.IndexOf(item);

                    if (indexFound >= 0)
                    {
                        newInput = newInput.Remove(indexFound, 1);
                        count++;
                    }

                } while (indexFound >= 0); // there may be more characters of the same, so loop until not found -1 is returned
            } // end of for loop

            return count;
        } // end of FindCharacterCount()

        /// <summary>
        /// Simple number guessing game that generates a randome number between 1-100 
        /// and asks the user to enter in their guess. It gives them hints of their guess
        /// being too high or too low, then outputs the number of guesses they entered.
        /// Does not count non-numbers as guesses
        /// </summary>
        private static void NumberGuessingGame()
        {
            Random rnd = new Random();          // Random number for the guess number game
            int target = rnd.Next(100) + 1;     // the target number 1-100 for the guess game
            int guess = 0;                      // the parsed integer of the guess input
            int count = 0;                      // number of guesses
            string input;                       // string for the user input

            // Loop for User Input and Guessing Unit Target is Reached
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter a number between 1 and 100: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                // Attempts to Parse User Input
                // Then Give Hint if guess is high or low based on target
                if(int.TryParse(input, out guess))
                {
                    count++;

                    if (guess > target)
                    {
                        Console.WriteLine("Too high.");
                    }
                    else if(guess < target)
                    {
                        Console.WriteLine("Too low.");
                    }
                } // end of main if on valid parsed input

            } while (!(guess == target)); // loop ends when target and guess are the same

            //Outputs the number of guesses to the console
            Console.WriteLine($"You got it in {count} guesses!");
        } // end  of  NumberGuessingGame()
    } // end of class
} // end of namespace
