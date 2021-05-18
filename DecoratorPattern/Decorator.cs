using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    public class Decorator : IStringBehavior
    {
        protected IStringBehavior stringBehavior;

        public void SetStringBehavior(IStringBehavior stringBehavior)
        {
            this.stringBehavior = stringBehavior;
        }

        public virtual string Reverse(string input)
        {
            //Console.WriteLine(this.stringBehavior);
            if (this.stringBehavior != null)
            {
                //Console.WriteLine(this.stringBehavior.Reverse(input));
                return this.stringBehavior.Reverse(input);
            }



            return input;
        }
    }
}
