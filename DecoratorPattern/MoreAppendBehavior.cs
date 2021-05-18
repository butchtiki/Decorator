using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    public class MoreAppendBehavior: Decorator
    {
        public override string Reverse(string input)
        {
            string resultString;
            resultString = base.Reverse(input);
            if(resultString != null)
            {
                resultString = resultString + "Welcome";
            }

            return resultString;

        }
    }
}
