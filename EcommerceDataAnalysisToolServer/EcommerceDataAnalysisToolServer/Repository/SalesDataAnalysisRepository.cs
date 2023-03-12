﻿using System;
using EcommerceDataAnalysisToolServer.Models;
using EcommerceDataAnalysisToolServer.Data;
using EcommerceDataAnalysisToolServer.Interfaces;

namespace EcommerceDataAnalysisToolServer.Repository
{
	public class SalesDataAnalysisRepository : ISalesDataAnalysisRepository
    {
        private DataContext _context;

        public SalesDataAnalysisRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method that handles Get all data
        /// </summary>
        /// <returns>return all the data from the DB</returns>
        public ICollection<Ecommerce> GetAllSales()
        {
            return _context.Ecommerce.ToList();
        }

        /// <summary>
        /// Method to Get the sales data by ID
        /// </summary>
        /// <param name="id">sales data id</param>
        /// <returns>sales data of the given id</returns>
        public Ecommerce GetSalesById(int id)
        {
            return _context.Ecommerce.Where(sale => sale.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Method for checking whether the sales data exist for the given id
        /// </summary>
        /// <param name="id">sales data id</param>
        /// <returns></returns>
        public bool SalesDataExists(int id)
        {
            return _context.Ecommerce.Any(sales => sales.Id == id);
        }

        /// <summary>
        /// Method to handle create new data.
        /// </summary>
        /// <param name="saleData">new sales data</param>
        /// <returns>true if new data has been created or false if new data is not created</returns>
        public bool AddSalesData(Ecommerce saleData)
        {
            saleData.Date = DateTime.UtcNow;
            _context.Add(saleData);
            return Save();
        }

        /// <summary>
        /// Method that handle updating a data
        /// </summary>
        /// <param name="id">sales data id</param>
        /// <param name="updatedSaleData">updated sales data</param>
        /// <returns>true if new data has been updated or false if new data is not updated</returns>
        public bool EditSalesData(Ecommerce updatedSaleData)
        {
            updatedSaleData.Date = DateTime.UtcNow;
            _context.Update(updatedSaleData);
            return Save();
        }

        /// <summary>
        /// Method that handle deleting a data
        /// </summary>
        /// <param name="id">sales data id</param>
        /// <returns>true if new data has been deleted or false if new data is not deleted</returns>
        public bool DeleteSalesData(int id)
        {
            _context.Remove(GetAllSales().FirstOrDefault(a => a.Id == id));
            return Save();
        }


        /// <summary>
        /// Save the changes to the database
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved == 1;
        }
    }
}
