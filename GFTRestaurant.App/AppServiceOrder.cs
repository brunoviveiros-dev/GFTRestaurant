using AutoMapper;
using GFTRestaurant.App.Dto;
using GFTRestaurant.App.Interfaces;
using GFTRestaurant.Domain.Entities;
using GFTRestaurant.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace GFTRestaurant.App
{
    public class AppServiceOrder : IAppServiceOrder
    {
        private readonly IServiceOrder _serviceOrder;
        private readonly IMapper _mapper;

        public AppServiceOrder(IServiceOrder serviceOrder, IMapper mapper)
        {
            this._serviceOrder = serviceOrder;
            this._mapper = mapper;
        }

        public void Add(OrderDto orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _serviceOrder.Add(order);
        }

        public void Update(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _serviceOrder.Update(order);
        }

        public void Delete(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _serviceOrder.Delete(order);
        }

        public IEnumerable<OrderDto> GetAll()
        {
            var orders = _serviceOrder.GetAll();
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public OrderDto GetById(int id)
        {
            var order = _serviceOrder.GetById(id);
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public OrderDto CreateAnOrder(string orderInput)
        {
            var order = _serviceOrder.CreateAnOrder(orderInput);
            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }
    }
}
