using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__CodingChallenge.Model
{
    class Cats : Pets
    {
        string catcolour { get; set; }
        public Cats(string catcolour, string name, int age, string breed) : base(name, age, breed)
        {
            this.catcolour = catcolour;
        }
    }
}
