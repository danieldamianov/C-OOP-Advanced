using System;

namespace P06_TrafficLights
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] lights = Console.ReadLine().Split();
            TrafficLight[] trafficLights = new TrafficLight[lights.Length];
            for (int i = 0; i < lights.Length; i++)
            {
                trafficLights[i] = new TrafficLight(lights[i]);
            }
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < trafficLights.Length; j++)
                {
                    trafficLights[j].MoveNext();
                    Console.Write(trafficLights[j].Light + " ");
                }
                Console.WriteLine();
            }
       
        }
    }
}
