﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TestApp.Masterdb.EF.Models
{
    public partial class Employee
    {
        public int EmployeeID { get; set; }
        public int? WorkerID { get; set; }
        public decimal? PayPerHour { get; set; }

        public virtual Worker Worker { get; set; }
    }
}