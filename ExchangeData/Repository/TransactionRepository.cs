﻿using ExchangeData.Base;
using ExchangeData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeData.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(Net17112313ExchangeContext content) : base(content)
        {
        }
    }

}
