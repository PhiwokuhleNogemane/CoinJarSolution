using CoinData;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinAPI.Database
{

    public class DatabaseContext
    {

        public void AddCoin(ICoin coin)
        {
            DynamicParameters dataParams = new DynamicParameters();
            dataParams.Add("@Amount", coin.Amount);
            dataParams.Add("@Volume", coin.Volume);

            DapperContext.ExecuteWithoutReturn("Sp_AddCoin", dataParams);
        }
        public decimal GetTotalAmount()
        {
            decimal totalAmount = 0;
            try
            {
                totalAmount = DapperContext.ExecuteReturnScalar<decimal>("Sp_GetTotalAmount", null);
            }
            catch(Exception ex)
            {
                totalAmount = 0;
            }
            return totalAmount;
        }
        public void Reset()
        {
           
            DapperContext.ExecuteWithoutReturn("Sp_Reset", null);
        }

        public decimal GetTotalVolume()
        {
            decimal totalVolume = 0;
            try
            {
                totalVolume = DapperContext.ExecuteReturnScalar<decimal>("Sp_GetTotalVolume", null);
            }
            catch (Exception ex)
            {
                totalVolume = 0;
            }
            
            return totalVolume;
        }
    }
}