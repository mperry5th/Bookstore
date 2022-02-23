﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Books bk, int qty)
        {
            BasketLineItem Line = Items
                .Where(p => p.Book.BookId == bk.BookId) //FIXIXIFIXI
                .FirstOrDefault();

            if (Line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bk, //FIXIXIXIXIX
                    Quantity = qty
                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 25);

            return sum;
        }
    }

    public class BasketLineItem
    {
        public int LineId { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
    }
}