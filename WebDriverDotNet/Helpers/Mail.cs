using System;

namespace WebDriverDotNet.Helpers
{
    public class Mail
    {
        public static string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Numbers = "012345679";

        public static string SpecialCharacters = "~!@#$%^&*()_+|";

        private static readonly Random Random = new Random();

        public string Email { get; private set; }
        
        public string Subject { get; private set; }
        
        public string Message { get; private set; }
        
        public string SecretPassword { get; private set; }

        public Mail(string email, string subject = "Secret password")
        {
            this.Email = email;
            this.Subject = subject;
            this.SecretPassword = GenerateRandomPassword(length: 7);
            this.Message = $"The Secret Password is : {this.SecretPassword}.";
        }

        public static string GenerateRandomPassword(int length, bool IsNumbersAllowed = true, 
                                    bool IsLettersAllowed = true, bool IsSpecialCharactersAllowed = true)
        {
            var result = new System.Text.StringBuilder();
            int numberOfChars = 0;

            if (length < 1)
            {
                throw new ArgumentException("Password length must be positive!");
            }

            for (int i = 0; i < length; i++)
            {
                if (numberOfChars < length && IsNumbersAllowed)
                {
                    result.Append(Numbers[Random.Next(Numbers.Length)]);
                    numberOfChars++;
                }

                if (numberOfChars < length && IsLettersAllowed)
                {
                    result.Append(Letters[Random.Next(Letters.Length)]);
                    numberOfChars++;
                }

                if (numberOfChars < length && IsSpecialCharactersAllowed)
                {
                    result.Append(SpecialCharacters[Random.Next(SpecialCharacters.Length)]);
                    numberOfChars++;
                }
            }

            return result.ToString();
        }
    }
}
