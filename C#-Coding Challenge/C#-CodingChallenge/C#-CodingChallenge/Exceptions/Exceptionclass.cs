using C__CodingChallenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C__CodingChallenge.Exceptions
{

    
        public class InvalidPetAgeHandling : Exception
        {
            public InvalidPetAgeHandling(string msg) : base(msg) { }
        }
        public class NullReferenceExceptionHandling : Exception
        {
            public NullReferenceExceptionHandling(string msg) : base(msg) { }
        }
        public class InsufficientFundsException : Exception
        {
            public InsufficientFundsException(string msg) : base(msg) { }
        }
        public class FileHandlingException : Exception
        {
            public FileHandlingException(string msg) : base(msg) { }
        }
        public class CustomExceptionforAdoptionErrors : Exception
        {
            public CustomExceptionforAdoptionErrors(string msg) : base(msg) { }
        }

    }

