using System;
using System.Collections.Generic;
using System.Text;

namespace RedisOpLibrary
{
    public class TString:IValue
    {
        private string Data { get; set; }

        public TString() { }

        public TString(object data)
        {
            Data = data.ToString();
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public static implicit operator TString(int value)
        {
            return new TString() { Data=value.ToString() };
        }

        public static implicit operator TString(long value)
        {
            return new TString() { Data = value.ToString() };
        }

        public static implicit operator TString(double value)
        {
            return new TString() { Data = value.ToString() };
        }
    }
}
