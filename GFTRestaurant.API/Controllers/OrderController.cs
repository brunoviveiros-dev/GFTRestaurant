using System;
using System.Collections.Generic;
using System.Linq;
using GFTRestaurant.App.Dto;
using GFTRestaurant.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GFTRestaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IAppServiceOrder _appServiceOrder;

        public OrderController(IAppServiceOrder appServiceOrder)
        {
            this._appServiceOrder = appServiceOrder;
        }

        [HttpGet]
        public IEnumerable<OrderDtoResponse> Get()
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

        [HttpDelete]
        public IActionResult DeleteAll()
        {
            try
            {
                _appServiceOrder.DeleteAll();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult<OrderDtoResponse> Post([FromBody] OrderDtoRequest order)
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
                var orderDto = _appServiceOrder.Add(newOrder);

                return orderDto;
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    
    }
}
