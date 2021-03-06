﻿// Copyright 2015 Tosho Toshev
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElmCommunicator.Commands;
using UnitsNet;

namespace ElmCommunicator.Responses.ElmResponses
{
    public class ReadInputVoltageResponseMessage : ResponseMessage
    {
        public override string ExpectedCommand
        {
            get { return "AT RV"; }
        }

        public ElectricPotential Voltage { get; set; }

        public override IReceiveMessage Parse(string message)
        {
            message = message.Replace(" ", string.Empty);
            message = message.Replace("\r\n", string.Empty);
            this.Voltage = ElectricPotential.FromVolts(double.Parse(message));
            return this;
        }
    }
}
