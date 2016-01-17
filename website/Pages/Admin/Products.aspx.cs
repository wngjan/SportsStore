using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using SportsStore.Models;
using SportsStore.Models.Repository;

namespace SportsStore.Pages.Admin
{
    public partial class Pages_Admin_Products : System.Web.UI.Page
    {
        private Repository repo = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Product> GetProducts()
        {
            return repo.Products;
        }

        public void UpdateProduct(int id)
        {
            Product myprod = repo.Products.Where(p => p.id == id).FirstOrDefault();
            if (myprod != null && TryUpdateModel(myprod,
                new FormValueProvider(ModelBindingExecutionContext))) {
                repo.SaveProduct(myprod);
            }
        }

        public void DeleteProduct(int id)
        {
            Product myprod = repo.Products.Where(p => p.id == id).FirstOrDefault();
            if (myprod != null) {
                repo.DeleteProduct(myprod);
            }
        }

        public void InsertProduct()
        {
            Product myprod = new Product();
            if (TryUpdateModel(myprod, 
                new FormValueProvider(ModelBindingExecutionContext))) {
                repo.SaveProduct(myprod);
            }
        }
    }
}