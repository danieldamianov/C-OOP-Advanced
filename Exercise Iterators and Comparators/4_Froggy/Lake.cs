using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _4_Froggy
{
    public class Lake : IEnumerable<int>
    {
        List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i+=2)
            {
                yield return this.stones[i];
            }
            for (int i = this.stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return this.stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
