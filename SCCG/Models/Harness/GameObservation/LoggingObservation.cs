using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Harness.GameObservation
{
    public class LoggingObservation : IGameObservation
    {
        string logMessage { get; set; }

        public LoggingObservation(string message)
        {
            this.logMessage = message;
        }

        public string GetShortInformalDescription()
        {
            return this.logMessage;
        }
    }
}
