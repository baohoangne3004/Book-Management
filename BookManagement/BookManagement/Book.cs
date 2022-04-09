using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookManagement
{
    class Book
    {
        private string id;
        private string title;
        private double unitPrice;
        private int quantity;

        public Book(string id, string title, double unitPrice, int quantity)
        {
            this.id = id;
            this.title = title;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
        }

        public string Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public string ToString()
        {
            return this.Id
                + "\t" + this.Title
                + "\t" + this.UnitPrice
                + "\t" + this.Quantity;
        }
    }
}
