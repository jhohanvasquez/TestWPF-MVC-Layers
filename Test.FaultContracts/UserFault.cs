﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.ServiceModel;

namespace Test.FaultContracts
{
    [DataContract]
    public class UserFault
    {

        [DataMember]
        public string FaultMessage;

        public UserFault(string msg)
        {
            FaultMessage = msg;
        }

    }
}
