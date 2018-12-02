using System;

namespace ArrayExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwordStr = "";
            Console.WriteLine("Please enter password:");
            passwordStr = Console.ReadLine();
            var passwordExample = new PasswordValidator();
            var isValid = passwordExample.IsValid(passwordStr);
            Console.WriteLine("Password Is valid :" + isValid);
            Console.ReadLine();
        }
    }
}
