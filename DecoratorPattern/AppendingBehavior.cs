using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    public class AppendingBehavior : Decorator
    {
        public override string Reverse(string input)
        {
            string resultString;
            resultString = base.Reverse(input);
            if (resultString != null)
            {
                resultString = resultString + "Christopher Henry Davila";
            }
            
            return resultString;
            
        }
    }
}
