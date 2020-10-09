using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdaysWebApi.Models
{
    public class BirthdayContext: DbContext
    {

        public BirthdayContext(DbContextOptions<BirthdayContext> options) :base(options)
        {

        }


        public DbSet<Birthday> Birthdays { get; set; }


    }
}
