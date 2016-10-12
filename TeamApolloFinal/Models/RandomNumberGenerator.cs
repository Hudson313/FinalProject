using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamApolloFinal.Models
{
    public class RandomNumberGenerator
    {
        private static Random RandNum = new Random();

        public int NumberBetween(int minVal, int maxVal)
        {
            return RandNum.Next(minVal, maxVal + 1);
        }
    }
}