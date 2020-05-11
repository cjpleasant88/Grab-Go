using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GrabAndGo.Models.ViewModels
{
    public class ShoppingList
    {

        public string  ProductName { get; set; }
        public int Quantity { get; set; }
        public int AisleNumber { get; set; }
        public string Category { get; set; }

        //public List<string> Products { get; set; }

        //public List<ShoppingListLine> UserShoppingList { get; set; }

        //private readonly List<ShoppingListLine> lineCollection = new List<ShoppingListLine>();

        //public virtual void AddItem(Product product, int quantity, int listID)
        //{
        //    ShoppingListLine line = lineCollection
        //    .Where(p => p.ProductID == product.ProductID)
        //    .FirstOrDefault();

        //    if (line == null)
        //    {
        //        lineCollection.Add(new ShoppingListLine
        //        {
        //            ProductID = product.ProductID,
        //            Quantity = quantity,
        //            ListID = listID
        //        });
        //    }
        //    else
        //    {
        //        line.Quantity += quantity;
        //    }
        //}

        //public virtual IEnumerable<ShoppingListLine> GetList(int listID)
        //{
        //    lineCollection = 
        //}

        //public virtual void Clear() => lineCollection.Clear();

        //public virtual IEnumerable<ShoppingListLine> Lines => lineCollection;
    }
}
