﻿using System;
using System.Globalization;

namespace ElmCommunicator.Commands.ElmCommands
{
    public class CanSilentMonitoringSetSendMessage : SendMessage
    {
        public CanSilentMonitoringSetSendMessage(bool state)
        {
            Command = "AT CSM";
            Data = Convert.ToInt32(state).ToString(CultureInfo.InvariantCulture);
        }
    }
}