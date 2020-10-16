using Common.DataObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class ApiVentasContext : DbContext
	{
		public ApiVentasContext()
		{
		}

		public ApiVentasContext(DbContextOptions<ApiVentasContext> options) : base(options)
		{ }

		//DBSets
		public DbSet<Users> Users { get; set; }
		public DbSet<Customers> Customers { get; set; }
		public DbSet<Sales> Sales { get; set; }
	}
}
