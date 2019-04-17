using Build_IT_WindLoads.Factors.Interfaces;
using System;

namespace Build_IT_WindLoads.Factors
{
    public class DirectionalFactor : IFactor
    {
        public double WindDirection { get; }

        private readonly WindZone _windZone;

        public DirectionalFactor(WindZone windZone, double windDirection)
        {
            _windZone = windZone;
            if (windDirection < 0)
                windDirection = 360 + windDirection % 360;
            WindDirection = windDirection % 360;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>[PN-EN 1991-1-4 Tab.NB.2]</remarks>
        public double GetFactor()
        {
            switch (_windZone)
            {
                case WindZone.I:
                    return GetFactoryForFirstWindZone();
                case WindZone.II:
                    return GetFactoryForSecondWindZone();
                case WindZone.III:
                    return GetFactoryForThirdWindZone();
                default:
                    throw new ArgumentException("wrong wind zone.");
            }
        }

        private double GetFactoryForFirstWindZone()
        {
            if (WindDirection < 15)
                return 0.8;
            if (WindDirection < 195)
                return 0.7;
            if (WindDirection < 225)
                return 0.8;
            if (WindDirection < 255)
                return 0.9;
            if (WindDirection < 315)
                return 1;
            if (WindDirection < 345)
                return 0.9;
            else
                return 0.8;
        }

        private double GetFactoryForSecondWindZone()
        {
            if (WindDirection < 15)
                return 1;
            if (WindDirection < 45)
                return 0.9;
            if (WindDirection < 75)
                return 0.8;
            if (WindDirection < 195)
                return 0.7;
            if (WindDirection < 225)
                return 0.8;
            if (WindDirection < 255)
                return 0.9;
            if (WindDirection < 345)
                return 1;
            else
                return 1;
        }

        private double GetFactoryForThirdWindZone()
        {
            if (WindDirection < 15)
                return 0.8;
            if (WindDirection < 135)
                return 0.7;
            if(WindDirection < 165)
                return 0.9;
            if (WindDirection < 345)
                return 1;
            else
                return 0.8;
        }
    }
}
