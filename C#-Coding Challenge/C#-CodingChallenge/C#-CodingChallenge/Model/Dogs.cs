using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__CodingChallenge.Model;

namespace C__CodingChallenge.Model
{
    class Dogs:Pets
    {
       public string dogBreed { get; set; }
        public Dogs(string dogBreed,string name,int age,string breed):base(name,age,breed)
        {
            this.dogBreed = dogBreed;
            //this.name = name;
            //this.age = age;
        }
    }
}
