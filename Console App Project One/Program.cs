using System;

namespace Console_App_Project_One
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();

            Console.WriteLine("Welcome to the most awesome bank ever.  In order to use your money with us, you'll have to give us some information.");

            user.FirstName = AskQuestion("What is your first name?");
            Console.WriteLine("Great! Your name is " + user.FirstName + ".");

            user.LastName = AskQuestion("What is your last name?");
            Console.WriteLine("Right. So your full name is " + user.FirstName + " " + user.LastName + ".");

            user.IsAccountOwner = AskBoolQuestion("Are you the account owner?");
            Console.WriteLine("Cool. Account owner: " + user.IsAccountOwner);

            user.PinNumber = AskPinNumber("What would you like for your 4-digit Pin Number to be?", 4);
            Console.WriteLine("Yes, we can use that.  Keep this for your records:  " + user.PinNumber);
                
            //This is only needed when debugging. We can remove the below line when published.
            Console.ReadLine();
        }

        static string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question">A question to be asked to the console.</param>
        /// <param name="limit">We should limit the pinNUmber to 4 digits.</param>
        /// <returns></returns>
        static string AskPinNumber(string question, int length)
        {
            string numberString = null;

            while (numberString == null)
            {
                var response = AskQuestion(question);

                if (response.Length == length && Int32.TryParse(response, out int _))
                {
                    numberString = response;
                }
            }

            return numberString;
        }

        static bool AskBoolQuestion(string question)
        {
            var hasAnswered = false;
            var responseBool = false;

            while (!hasAnswered)
            {
                var response = AskQuestion(question + " (y/n)");

                if (response == "y")
                {
                    responseBool = true;
                    hasAnswered = true;
                }
                else if (response == "n")
                {
                    responseBool = false;
                    hasAnswered = true;
                }
            }

            return responseBool;
        }
    }
}
