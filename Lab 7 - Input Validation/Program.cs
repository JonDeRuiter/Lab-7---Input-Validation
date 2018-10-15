using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7___Input_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            string input;

            do
            {
                //Console.WriteLine("Please enter a valid name: ");
                //input = Console.ReadLine();
                //bool name = ValidName(input);
                //if (name)
                //{
                //    Console.WriteLine($"{input} is a valid name!");
                //}
                //else
                //{
                //    Console.WriteLine($"{input} is not a valid name!");
                //}
                //Console.WriteLine("Please enter a valid email: ");
                //input = Console.ReadLine();
                //bool email = ValidEmail(input);
                //if (email)
                //{
                //    Console.WriteLine($"{input} is a valid email!");
                //}
                //else
                //{
                //    Console.WriteLine($"{input} is not a valid email.");
                //}
                Console.WriteLine("Please enter a valid phone number: ");
                input = Console.ReadLine();
                ValidPhone(input);
                //if (phone)
                //{
                //    Console.WriteLine($"{input} is a valid phone number!");
                //}
                //else
                //{
                //    Console.WriteLine($"{input} is not a valid phone number!");
                //}
                Console.WriteLine("Please enter a valid date (dd/mm/yyyy): ");
                Console.WriteLine("Please enter a valid html element: ");
                
                

                again = Continue();
            } while (again);

        }
        public static bool Continue()
        {
            bool run;
            Console.WriteLine("Continue? y/n");
            string answer = Console.ReadLine();
            answer = answer.ToLower();

            if (answer == "y")
            {
                run = true;
            }
            else if (answer == "n")
            {
                run = false;
            }
            else
            {
                Console.WriteLine("Sorry, I didn't understand that. Try again.");
                run = Continue();
            }
            return run;
        }
        public static bool ValidName (string input)
        {
            int counter = 0;
            bool valid;
            char[] nameArray = input.ToCharArray();

            //If anything does not conform to name parameters it adds to the counter, if counter is above 0, the string is not a valid name
            for (int i = 0; i < input.Length; i++)
            {
                if (!(char.IsLetter(nameArray[i])))
                {
                    counter++;
                }                
            }
            if (input.Length > 30 || char.IsLower(nameArray[0]))
            {
                counter++;
            }
            if (counter > 0)
            {
                valid = false;
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        public static bool ValidEmail(string input)
        {
            //searching stackoverflow, this is how it works in the real world, but it doesn' correspond with the build specifications
            //try
            //{
            //    var address = new System.Net.Mail.MailAddress(input);
            //    return address.Address == input;


            //}
            //catch
            //{
            //    return false;
            //}

            bool user, domain, domainName, valid = true;
            char[] fullEmail = input.ToCharArray();
            int at, period;

            at = input.IndexOf("@");
            period = input.IndexOf(".");
                        
            if (at > 4 && at < 31)
            {

                user = IsCharNum(0, (at-1), fullEmail);
            }
            else
            {
                user = false;
            }

            if (((period-1) - at) >= 5 && (input.Length - (period+1)) <= 10)
            {
                domain = IsCharNum((at+1), (period-1), fullEmail);
            }
            else
            {
                domain = false;
            }

            if (input.Length - (period + 1) >= 2 && input.Length - (period + 1) <= 3)
            {
                domainName = IsCharNum((period+1),(input.Length - 1), fullEmail);
            }
            else
            {
                domainName = false;
            }
            if (user && domain && domainName)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;

        }
        public static bool IsCharNum(int start, int end, char[] fullEmail)
        {
            bool charValid = true;
            int counter = 0;
            

            for (int i = start; i < (end + 1) ; i++)
            {
                if (!(NumReal(fullEmail) || Char.IsLetter(fullEmail[i])))
                {
                    counter++;
                }
            }
            if (counter > 0)
            {
                charValid = false;
            }
            else
            {
                charValid = true;
            }
            return charValid;
        } 
        public static bool NumReal(char[] fullEmail)
        {
            bool valid = true;
            for (int i = 0; i < fullEmail.Length; i++)
            {
                if (!(Char.IsDigit(fullEmail[i])))
                {
                    valid = false;
                }
            }

            return valid;
        }
        public static void ValidPhone(string input)
        {
            string first, second, third, phoneDigits;
            try
            {
                first = input.Substring(0, 3);
                second = input.Substring(4, 3);
                third = input.Substring(8, 4);
            }catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Not a valid Phone Number");
                first = "INVALID";
                second = "INVALID";
                third = "INVALID";
            }

            phoneDigits = first + second + third;
            

            char[] phoneArray = phoneDigits.ToCharArray();
            for (int i = 0; i < phoneDigits.Length; i++)
            {

                if (Char.IsDigit(phoneArray[i]))
                {

                }
                else
                {
                    throw new Exception e;
                }
            }
            Console.WriteLine($"{phoneDigits} is a valid phone Number!");


        }
    }
}
