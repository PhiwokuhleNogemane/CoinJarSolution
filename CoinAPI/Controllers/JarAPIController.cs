using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoinData;
using CoinAPI.Helpers;
using System.Web.Mvc;
using CoinAPI.Database;

namespace CoinAPI.Controllers
{
    public class JarAPIController : ApiController
    {
        [CacheFilter(TimeDuration = 100)]
        public APIResponse GetAddCoinResult(int coinTypeID)
        {
            APIResponse response = new APIResponse();
            ICoinJar coinJar = new ConcreteCoinJar();
            CoinFactory coinFactory = new CoinFactory();

            try
            {
                ICoin coin = coinFactory.GetCoin(coinTypeID);
                decimal fututureVolume = 0;
                decimal totalVolume = GetTotalVolume();
                fututureVolume = totalVolume + coin.Volume;
             

                if (fututureVolume > 42)
                {
                    response.IsSuccess = false;
                    response.ResponseMesage = $"Sorry this coin wont fit. The Jar is almost full. You can either add a coin of Volume size {42-GetTotalVolume()} or less OR reset Jar";

                    response = SetTotals(response);

                    return response;
                }

                if (totalVolume >= 42)
                {
                    response.IsSuccess = false;
                    response.ResponseMesage = "Sorry you cant add coins Jar is Full";
                    response = SetTotals(response);
                    return response;
                }
                if(coin.Amount==0)
                {
                    response.IsSuccess = false;
                    response.ResponseMesage = "Please enter a valid coin";
                    response = SetTotals(response);
                    return response;
                }
                coinJar.AddCoin(coin);   
                response.IsSuccess = true;
                response = SetTotals(response);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.ResponseMesage = ex.ToString();
            }
            return response;
           
        }

        [CacheFilter(TimeDuration = 100)]
        public APIResponse GetTotalAmount()
        {
            APIResponse response = new APIResponse();
            ICoinJar coinJar = new ConcreteCoinJar();

            try
            {
                response.TotalAmount = coinJar.GetTotalAmount();
                response.IsSuccess = true;
                response = SetTotals(response);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.ResponseMesage = ex.ToString();
            }
            return response;
        }    
        public APIResponse GetResetResult()
        {
            APIResponse response = new APIResponse();
            ICoinJar coinJar = new ConcreteCoinJar();
            try
            {
                coinJar.Reset();
                response.IsSuccess = true;
                response = SetTotals(response);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.ResponseMesage = ex.ToString();
            }

            return response;
        }
        private decimal GetTotalVolume()
        {
            DatabaseContext databaseContext = new DatabaseContext();
            return databaseContext.GetTotalVolume();
        }

        private APIResponse SetTotals(APIResponse response)
        {
            ICoinJar coinJar = new ConcreteCoinJar();
            response.TotalVolume = GetTotalVolume();
            response.TotalAmount = coinJar.GetTotalAmount();
            return response;
        }
    }
}
