using System;

namespace FootballLeague.Services.CustomException
{
    public class GlobalException : Exception
    {
        public GlobalException()
        {

        }

        public GlobalException(string message)
            : base(message)
        {

        }
    }
}
