using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class TrafficLight
    {
        public ITrafficLightState State;
        public TrafficLight(ITrafficLightState state)
        {
            State = state;
        }
        public void Change()
        {
            State.Change(this);
        }
    }
}
