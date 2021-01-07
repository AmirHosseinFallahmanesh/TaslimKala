using System;
using System.Collections.Generic;
using System.Linq;

namespace TK.Core.Entites
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine cartLine = GetCartLine(product.ProductID);
            if (cartLine != null)
            {
              //update
            }
            else
            {
                lines.Add(new CartLine() { Quantity = quantity, Product = product });
            }

        }

        public virtual void RemoveLine(int productId)
        {
            lines.RemoveAll(a => a.Product.ProductID == productId);
        }

        public virtual int GetTotalPrice()
        {
            return lines.Sum(e => e.Product.Price * e.Quantity);
        }

        public virtual void Clear()
        {
            lines.Clear();
        }

        public IEnumerable<CartLine> CartLines { get => lines; }

        private CartLine GetCartLine(int productId)
        {
            return lines.FirstOrDefault(p => p.Product.ProductID == productId);
        }

    }


    public class Order
    {
        public int OrderID { get; set; }

        public List<CartLine> Lines { get; set; }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PaymentNote { get; set; }
        public string ZipCode { get; set; }

        public string paymentToken { get; set; }
        public string PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
