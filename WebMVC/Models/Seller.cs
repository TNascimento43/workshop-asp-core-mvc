﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public double BaseSalary { get; set; }

        public DateTime BirthDate { get; set; }

        public Departament Departament { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Departament = departament;
        }

        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(salesRecord => salesRecord.Date >= initial && salesRecord.Date <= final).Sum(
                salesRecord => salesRecord.Amount);
        }
    }
}
