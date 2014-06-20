﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElmCommunicator.Commands;

namespace ElmCommunicator.Responses
{
    public abstract class ResponseMessage : IReceiveMessage
    {
        public string Command { get; set; }
        public string Data { get; set; }
        public string StartTermination { get; set; }
        public string EndTermination { get; set; }
        public abstract IReceiveMessage Parse(string message);
        public int HexToDec(string hex)
        {
            if(string.IsNullOrEmpty(hex))
                throw new ArgumentNullException("hex");

            return int.Parse(hex, NumberStyles.HexNumber);
        }

        public byte ReverseByte(byte val)
        {
            byte result = 0;
            int counter = 8;
            while (counter > 0)
            {
                result <<= 1;
                result |= (byte)(val & 1);
                val = (byte)(val >> 1);
                counter--;
            }

            return result;
        }

        public byte[] StringToByteArray(string hex, bool bitSwap = false)
        {
            hex = hex.Replace(" ", string.Empty);

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x =>
                             {
                                 byte result = Convert.ToByte(hex.Substring(x, 2), 16);
                                 if (bitSwap)
                                 {
                                     result = this.ReverseByte(result);
                                 }

                                 return result;
                             }).ToArray();
        }
    }
}
