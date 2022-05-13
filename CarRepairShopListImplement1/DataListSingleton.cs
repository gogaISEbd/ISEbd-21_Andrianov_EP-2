using System;
using System.Collections.Generic;
using System.Text;
using CarRepairShopListImplement.Models;

namespace CarRepairShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<repair> repair { get; set; }
        public List<WareHouse> Warehouses { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            repair = new List<repair>();
            Warehouses = new List<WareHouse>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }

    }
}
