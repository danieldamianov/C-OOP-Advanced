using System;
using System.Collections.Generic;
using System.Text;

namespace TestAxe
{
    public class BancAccount
    {
        public BancAccount()
        {
            this.Amount = 0;
        }

        public int Amount { get; set; }

        public void Deposit(int amount)
        {
            this.Amount += amount;
        }

        public void WithDraw(int amount)
        {
            this.Amount -= amount;
            this.Amount = Math.Max(this.Amount, 0);
        }
    }
}
