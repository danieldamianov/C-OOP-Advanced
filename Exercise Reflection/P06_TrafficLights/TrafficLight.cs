using System;
using System.Collections.Generic;
using System.Text;

namespace P06_TrafficLights
{
    public class TrafficLight
    {
        private Lights light;
        int counter;

        public TrafficLight(string light)
        {
            this.light = Enum.Parse<Lights>(light, true);
            counter = (int)this.light;
        }

        public void MoveNext()
        {
            this.counter++;
            if (this.counter == 4)
            {
                this.counter = 1;
            }
            this.light = (Lights)this.counter;
        }

        public string Light => this.light.ToString();
    }
}
