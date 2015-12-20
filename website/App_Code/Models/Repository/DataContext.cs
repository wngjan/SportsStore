using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

/// <summary>
/// DataContext 的摘要说明
/// </summary>
namespace SportsStore.Models.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
