using System;
using System.IO;

namespace Framework.Utils
{
    public class UserCreatorUtil
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Browser { get; set; }

        private readonly string _parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public UserCreatorUtil(string environment)
        {
            this.Name = ExtractValueFromFile(environment, "Name");
            this.Password = ExtractValueFromFile(environment, "Password");
            this.Browser = ExtractValueFromFile(environment, "Browser");
        }

        private string ExtractValueFromFile(string environment, string property)
        {
            string result = String.Empty;
            using (var reader = new StreamReader(Path.Combine(_parentPath, "Sources", $"{environment}.properties")))
            {
                string line; 
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(property))
                    {
                        result = line.Substring(line.IndexOf('=') + 1);
                    }
                }
            }

            return result;
        }
    }
}
