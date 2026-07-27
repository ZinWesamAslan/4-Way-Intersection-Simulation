using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionSimulation4Way
{
    public class ClsRoad
    {
        // Private Fields
        private List<ClsLane> _lanes;
        private ClsTrafficLight _trafficLight;

        // Properties
        public List<ClsLane> Lanes
        {
            get { return _lanes; }
        }

        public ClsTrafficLight TrafficLight
        {
            get { return _trafficLight; }
            set { _trafficLight = value; }
        }

        // Constructor
        public ClsRoad(ClsTrafficLight trafficLight, int numberOfLanes = 2)
        {
            // التحقق من أن عدد المسارات محصور بين 2 و 3 بناءً على مخطط UML (2..3)
            if (numberOfLanes < 2 || numberOfLanes > 3)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfLanes), "Road must have between 2 and 3 lanes.");
            }

            _trafficLight = trafficLight;
            _lanes = new List<ClsLane>();

            for (int i = 0; i < numberOfLanes; i++)
            {
                _lanes.Add(new ClsLane());
            }
        }

        // Method لإضافة مسار جديد مع الحفاظ على القيد (2..3)
        public bool AddLane(ClsLane lane)
        {
            if (_lanes.Count < 3 && lane != null)
            {
                _lanes.Add(lane);
                return true;
            }
            return false; // لا يمكن إضافة أكثر من 3 مسارات
        }
    }
}
