﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API_Football.SDK.Models
{
    public class Status
    {
        public Account Account { get; set; }
        public Subscription Subscription { get; set; }
        public Requests Requests { get; set; }
    }
}