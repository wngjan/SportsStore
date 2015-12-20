﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportsStore.Models;
using SportsStore.Models.Repository;


public partial class Pages_ProductList : System.Web.UI.Page
{
    private Repository repo = new Repository();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected IEnumerable<Product> GetProducts()
    {
        return repo.Products;
    }
}
