using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    internal class PhoneInfo
    {
        public int id { get; set; }
        public string model { get; set; }
        public decimal price { get; set; }
        public int storage { get; set; }
        public int ram { get; set; }

        public PhoneInfo(string model, decimal price, int storage, int ram)
        {
            this.model = model;
            this.price = price;
            this.storage = storage;
            this.ram = ram;
        }

        public string GetInfo()
        {
            return $"ID: {id}, Модель: {model}, Цена: {price}, Хранилище: {storage}GB, RAM: {ram}GB";
        }
    }
}