﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class PutAccountParameters
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public AccountStatus PutAccount { get; set; }
    }
}
