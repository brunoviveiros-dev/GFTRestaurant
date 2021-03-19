using System;
using System.Collections.Generic;
using System.Linq;
using GFTRestaurant.Domain.DTO.Request;
using GFTRestaurant.Domain.DTO.Response;
using GFTRestaurant.Domain.Entitys;
using GFTRestaurant.Domain.Enumerators;
using GFTRestaurant.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GFTRestaurant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            try
            {
                return _orderRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult<OrderResponseDTO> Post([FromBody] OrderRequestDTO order)
        {
            try
            {
                if (order.OrderDescription.Split(",").Count() < 2)
                    throw new ArgumentException("Unknown order.");

                var dishType = order.OrderDescription.Split(",").First().ToUpper().Trim();
                var dishesType = new List<string> { "MORNING", "NIGHT" };

                if (!dishesType.Contains(dishType))
                    throw new ArgumentException("Unknown dish type.");

                var orderDetail = _orderRepository.PlaceAnOrder(order.OrderDescription);
                return new OrderResponseDTO()
                {
                    Detail = orderDetail
                };
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        

    }
}
