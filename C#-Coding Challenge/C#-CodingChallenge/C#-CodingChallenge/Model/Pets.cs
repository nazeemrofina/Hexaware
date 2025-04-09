using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace C__CodingChallenge.Model
{
    class Pets
    {
        public string name { get; set; }
        public int age { get; set; }
        public string breed { get; set; }
        public Pets(string name, int age, string breed)
        {
            this.name = name;
            this.age = age;
            this.breed = breed;
        }

        public override string ToString()
        {
            return $"Name {name}\npet age {age}\npet breed: {breed}";
        }
    }
}
