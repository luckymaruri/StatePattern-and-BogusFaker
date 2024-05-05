using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class RedState : ITrafficLightState
    {
        public void Change(TrafficLight light)
        {
            Console.WriteLine("Red -> Yellow");
            light.State=new YellowState();
        }
    }
    public class YellowState : ITrafficLightState
    {
        public void Change(TrafficLight light)
        {
            Console.WriteLine("Yellow -> Green");
            light.State = new GreenState();
        }
    }
    public class GreenState : ITrafficLightState
    {
        public void Change(TrafficLight light)
        {
            Console.WriteLine("Geen -> Red");
            light.State = new RedState();
        }
    }
}
