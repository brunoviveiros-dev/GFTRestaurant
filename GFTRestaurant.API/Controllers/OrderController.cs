using System;
using System.Collections.Generic;
using System.Linq;
using GFTRestaurant.App.Dto;
using GFTRestaurant.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GFTRestaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IAppServiceOrder _appServiceOrder;

        public OrderController(IAppServiceOrder appServiceOrder)
        {
            this._appServiceOrder = appServiceOrder;
        }

        [HttpGet]
        public IEnumerable<OrderDto> Get()
        {
            try
            {
                return _appServiceOrder.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult<OrderDto> Post([FromBody] OrderDto order)
        {
            try
            {
                if (order.Detail.Split(",").Count() < 2)
                    throw new ArgumentException("Unknown order.");

                var dishType = order.Detail.Split(",").First().ToUpper().Trim();
                var dishesType = new List<string> { "MORNING", "NIGHT" };

                if (!dishesType.Contains(dishType))
                    throw new ArgumentException("Unknown dish type.");

                var newOrder = _appServiceOrder.CreateAnOrder(order.Detail);
                _appServiceOrder.Add(newOrder);

                return newOrder;
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    
    }
}
