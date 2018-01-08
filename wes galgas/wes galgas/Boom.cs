using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes_galgas
{
    class Boom
    {
        TimeSpan wait;
        public TimeSpan Time;


        public Boom (TimeSpan wait, TimeSpan Time)
        {
            this.wait = wait;
            this.Time = Time;
        }

        public void update(TimeSpan Elapsedtime)
        {
            Time += Elapsedtime;
        }

        public bool compare (TimeSpan zero)
        {
            if (Time > wait)
            {
                Time = zero;
                return true;
            }
            return false;
        }
    }
}
