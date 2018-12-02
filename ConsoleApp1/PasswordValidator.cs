using System;
using System.Collections.Generic;

namespace ArrayExample
{
    public class PasswordValidator
    {
        public List<IPasswordRule> PasswordRules { get; set; }

        public PasswordValidator()
        {
            List<IPasswordRule> passwordRules = new List<IPasswordRule>();

            passwordRules.Add(new LengthRule(8));
            passwordRules.Add(new AlphabateRule(4));
            passwordRules.Add(new NumberRule(4));

            PasswordRules = passwordRules;
        }


        public bool IsValid(string passwordStr)
        {
            foreach (var passwordRule in PasswordRules)
            {
                var valid = passwordRule.Validate(passwordStr);
                if (valid) continue;
                Console.WriteLine(passwordRule.ErrorStatment());
                return false;
            }
            return true;
        }
    }

    public interface IPasswordRule
    {
        bool Validate(string password);
        string ErrorStatment();
    }

    public class LengthRule : IPasswordRule
    {
        private int Length { get; set; }

        public LengthRule(int length)
        {
            Length = length;
        }
        
        public bool Validate(string password)
        {
            return password.Length >= Length;
        }

        public string ErrorStatment()
        {
            return "Password length must be " + Length+ " charater long";
        }
    }

    public class AlphabateRule : IPasswordRule
    {
        private int NoOfAlphabates { get; set; }

        public AlphabateRule(int noOfAlphabates)
        {
            NoOfAlphabates = noOfAlphabates;
        }

        public bool Validate(string password)
        {
            int noAlphabatesInPassword = 0;
            foreach (char charater in password)
            {
                if ((charater >= 65 && charater <= 90) || (charater >= 97 && charater <= 122))
                    noAlphabatesInPassword++;
            }
            return noAlphabatesInPassword >= NoOfAlphabates;
        }

        public string ErrorStatment()
        {
            return "Password must contain " + NoOfAlphabates + " alphabets";
        }
    }

    public class NumberRule : IPasswordRule
    {
        private int NoOfNumbers { get; set; }

        public NumberRule(int noOfNumbers)
        {
            NoOfNumbers = noOfNumbers;
        }

        public bool Validate(string password)
        {
            int noOfNumbersInNumbers = 0;
            foreach (char charater in password)
            {
                if (charater >= 48 && charater <= 57)
                    noOfNumbersInNumbers++;
            }
            return noOfNumbersInNumbers >= NoOfNumbers;
        }

        public string ErrorStatment()
        {
            return "Password must contain " + NoOfNumbers + " numbers";
        }
    }
}


