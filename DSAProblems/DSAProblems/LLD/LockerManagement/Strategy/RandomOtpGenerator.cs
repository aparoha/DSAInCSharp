using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.LockerManagement.Strategy
{
    public class RandomOtpGenerator : IOtpGenerator
    {
        readonly private int _otpLength;
        readonly private IRandomGenerator _randomGenerator;

        public RandomOtpGenerator(int otpLength, IRandomGenerator randomGenerator)
        {
            _otpLength = otpLength;
            _randomGenerator = randomGenerator;
        }
        public string GenerateOtp()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < _otpLength; i++)
                sb.Append(_randomGenerator.GetRandomNumber(10));
            return sb.ToString();
        }
    }
}
