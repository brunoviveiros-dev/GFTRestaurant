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

        public OrderDtoResponse Add(OrderDtoResponse orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _serviceOrder.Add(order);
            var orderResponse = _mapper.Map<OrderDtoResponse>(order);
            return orderResponse;
        }

        public void Update(OrderDtoResponse orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _serviceOrder.Update(order);
        }

        public void Delete(OrderDtoResponse orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _serviceOrder.Delete(order);
        }

        public void DeleteAll()
        {
            _serviceOrder.DeleteAll();
        }

        public IEnumerable<OrderDtoResponse> GetAll()
        {
            var orders = _serviceOrder.GetAll();
            var ordersDto = _mapper.Map<IEnumerable<OrderDtoResponse>>(orders);
            return ordersDto;
        }

        public OrderDtoResponse GetById(int id)
        {
            var order = _serviceOrder.GetById(id);
            var orderDto = _mapper.Map<OrderDtoResponse>(order);
            return orderDto;
        }

        public OrderDtoResponse CreateAnOrder(string orderInput)
        {
            var order = _serviceOrder.CreateAnOrder(orderInput);
            var orderDto = _mapper.Map<OrderDtoResponse>(order);
            return orderDto;
        }
    }
}
