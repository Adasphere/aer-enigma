using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Models.Business
{
    public class Alert
    {
        public string Title
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public TimeSpan Length
        {
            get;
            set;
        }

        public AlertLevel Level
        {
            get;
            set;
        }
    }
}
