
            using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//1.Properties :

//Create a TimePeriod Class that stores time period.
//Internally the class stores the time in seconds,
//but a property named Hours that enables the client to specify a time in Hours.
//The accessors for the Hours property should perform the conversion between hours and seconds
namespace Assignment__day_5_class
{
    class Program2
    {
        static void Main(string[] args)
        { 
        Timeperiod tp = new Timeperiod();
        int times= tp.time();
            tp.timeinhour = times;
            Console.WriteLine(tp.time_in_hour);
    }
}
    class Timeperiod
    {
        int timeinmin;
        public int time()
        {
            Console.WriteLine("Enter the time: ");
            timeinmin = Convert.ToInt32(Console.ReadLine());
            return timeinmin;
        }
        public float timeinhour = 0.0f;
        
      
        public float time_in_hour
        {
            get { return (float)timeinmin/60; }
           // set { timeinhour=value*60; }
            

        }
    }
}

        
