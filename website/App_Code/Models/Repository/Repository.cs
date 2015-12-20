using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Repository 的摘要说明
/// </summary>

namespace SportsStore.Models.Repository
{
    public class Repository
    {
        public Repository()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        private DataContext context = new DataContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
