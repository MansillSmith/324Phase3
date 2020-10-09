using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeLayout
{
    class Record
    {
        public DateTime date;
        public String exerciseType;
        public int duration;
        public double distance;
        public double speed;

        public Record(DateTime date, String exerciseType, int duration, double distance, double speed)
        {
            this.date = date;
            this.exerciseType = exerciseType;
            this.duration = duration;
            this.distance = distance;
            this.speed = speed;
        }
    }
}
