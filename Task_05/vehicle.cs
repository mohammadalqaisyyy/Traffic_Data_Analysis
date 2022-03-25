using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Mohammad Al-Qaisy

namespace Task_05
{
    class vehicle
    {
        string type = "", number = "", Nu = "", speedClass = "No Speed Range";
        int displacment, speed, exit;
        List<Coordinate> list = new List<Coordinate>();

        public vehicle(string s)
        {
            string[] sub = s.Split(',');
            string[] sub2 = sub[0].Split(':');
            sub[0] = sub2[1];
            type = sub2[0].Split(' ')[0];
            number = sub2[0].Split(' ')[1].Trim('(').Trim(')');
            Nu = sub[sub.Length - 1].Remove(0, 1);
            for (int i = 0; i < sub.Length - 1; i += 2)
            {
                sub[i] = sub[i].Trim('(');
                sub[i + 1] = sub[i + 1].Trim(')');
                list.Add(new Coordinate(Int16.Parse(sub[i]), Int16.Parse(sub[i + 1])));
            }
            Displacment();
            Speed();
            Exit();
        }

        void Displacment()
        {
            double x1 = list[0].x, x2 = list[list.Count - 1].x;
            double y1 = list[0].y, y2 = list[list.Count - 1].y;
            displacment = (int) Math.Sqrt(Math.Pow(x2-x1,2)+ Math.Pow(y2 - y1, 2));
        }

        void Speed()
        {
            speed = (30 * displacment) / list.Count;
        }

        void Exit()
        {
            IDictionary<int, string> IDexit = new Dictionary<int, string>();
            IDexit.Add(1, "First");
            IDexit.Add(2, "Second");
            IDexit.Add(3, "Third");
            IDexit.Add(4, "Forth");
            foreach(KeyValuePair<int, string> t in IDexit)
            {
                if (Nu == t.Value)
                    exit = t.Key;
            }
        }

        public string _number
        {
            get { return number; }
        }
        public string _type
        {
            get { return type; }
        }
        public string _speedClass
        {
            set { speedClass = value; }
            get { return speedClass; }
        }
        public int _Displacement
        {
            get { return displacment; }
        }
        public int _speed
        {
            get { return speed; }
        }
        public int _exit
        {
            get { return exit; }
        }
    }
}
