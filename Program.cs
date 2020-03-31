using System;
using System.Text.RegularExpressions;
using regularexp.Validators;

namespace regularexp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                1. Passwords must consist of a mixture of letters and numerical digits only, with at least one of each.
                2. Passwords must be between 5 and 12 characters in length.
                3. Passwords must not contain any sequence of characters immediately followed by the same sequence. Examples of
                repeated sequences: “aa”, “aaa”, “abab”, “abcabc
            
            */

            string pattern; 

            pattern = @"^";

            pattern += @"(?=.*[A-Za-z])(?=.*\d).";

            // pattern += @"[\S\s]{5,12}";

            //  pattern += @"([A-Za-z0-9])\1/g";

            // pattern += @"([a-z])\1/ig";

            // pattern += @"(?:(.)(?!\1{2}))+";

            // pattern += @"[a-zA-Z0-9_.-]*";

            // at least 5 characters and no more than 12 
            // pattern = @"^.{5,12}$";
            
            // pattern = @"^[a-zA-Z0-9_.-]*$";
            
            // at least one character
            // pattern += @"^[\w\d_.-]+$";

            /*
                ([a-zA-Z0-9]+[_-])* 
                Zero or more occurrences of one or more letters or numbers 
                followed by an underscore or dash. 
                This causes all names that contain a dash or underscore to have letters or numbers between them.


                [a-zA-Z0-9]+ 
                One or more letters or numbers. 
                This covers all names that do not contain an underscore or a dash.

            */

            // ^([a-zA-Z0-9]+[_-])*[a-zA-Z0-9]+\.[a-zA-Z0-9]+$

            // pattern += @"([a-zA-Z0-9]+[_-])*[a-zA-Z0-9]+\.[a-zA-Z0-9]+";
            
            // pattern = @"^.{5,12}[a-zA-Z0-9_.-]*$";

            // matches repeating patterns.
            // ([A-Za-z0-9])\1


            pattern += @"$";

            Regex regex = new Regex(pattern);

            // Define some test strings.
            string[] tests = { "", "pa$$w0rd","pa$$w0rd1", "aaabbb123", "213343", "111111111", "1234Hello",
                                "al12", "abcdefgh","alkm123" };

            // Check each test string against the regular expression.
            foreach (string test in tests)
            {
                if (regex.IsMatch(test))
                    Console.WriteLine("{0} is a valid password.", test);
                else
                    Console.WriteLine("{0} is not a valid password.", test);
            }

        

            /*
            Console.WriteLine("----------");


            string patternForMatches = @"([A-Za-z0-9])\1";

            Regex regexForMatches = new Regex(patternForMatches);


            foreach (string testMatch in tests)
            {
                MatchCollection matches = regexForMatches.Matches(testMatch);

                if(matches.Count > 0)
                {
                    Console.WriteLine("There are matches {0} in {1}", matches.Count.ToString(), testMatch);
                } else {
                    Console.WriteLine("There are no matches");
                }
            }
            */
            
            LettersAndNumbersValidator lettersAndNumbersValidator = new LettersAndNumbersValidator();
            NoRepeatingPatternValidator noRepeatingPatternValidator = new NoRepeatingPatternValidator();
            StringValidator stringValidator = new StringValidator();

            
            foreach (string test in tests)
            {
                Console.WriteLine(test);

                if(stringValidator.validate(test))
                {
                    Console.WriteLine("string is 5 characters long and max length 12");
                } else {
                    Console.WriteLine("xxx too short or too long");
                }     

                if(lettersAndNumbersValidator.validate(test))
                {
                    Console.WriteLine("string has letters and numbers");
                } else {
                    Console.WriteLine("xxx doesn't have strings and or numbers");
                }               

                if(noRepeatingPatternValidator.validate(test))
                {
                    Console.WriteLine("string has no repeating patterns");
                } else {
                    Console.WriteLine("xxx does have repeating pattern");
                }     

                if(stringValidator.validate(test) && 
                   lettersAndNumbersValidator.validate(test) && 
                   noRepeatingPatternValidator.validate(test))
                {
                   Console.WriteLine("This is a valid password");
                } else {
                    Console.WriteLine("This is not a valid password");
                }

                Console.WriteLine("");
            }
        }
    }
}
