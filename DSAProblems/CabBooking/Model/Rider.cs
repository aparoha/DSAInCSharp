using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBooking.Model
{
    public class Rider
    {
        public string ID {  get; private set;}
        public string Name {  get; private set;}
        public Rider(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
