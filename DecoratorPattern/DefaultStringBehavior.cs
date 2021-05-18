using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    public class DefaultStringBehavior : IStringBehavior
    {
        public string Reverse(string input)
        {
            if (input != null)
            {
                var tempString = input.ToCharArray();
                Array.Reverse(tempString);
                Console.WriteLine(tempString);
                return new string(tempString);
            }
            else
            {
                return null;
            }
            
        }

    }
}
