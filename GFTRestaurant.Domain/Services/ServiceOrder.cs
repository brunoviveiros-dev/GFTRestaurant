﻿using GFTRestaurant.Domain.Entities;
using GFTRestaurant.Domain.Enumerators;
using GFTRestaurant.Domain.Interfaces;
using GFTRestaurant.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFTRestaurant.Domain.Services
{
    public class ServiceOrder : IServiceOrder
    {
        private readonly IOrderRepository _orderRepository;

        public ServiceOrder(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public void Add(Order obj)
        {
            _orderRepository.Add(obj);
        }

        public void Delete(Order obj)
        {
            _orderRepository.Delete(obj);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(long id)
        {
            return _orderRepository.GetById(id);
        }

        public void Update(Order obj)
        {
            _orderRepository.Update(obj);
        }

        public Order CreateAnOrder(string orderInput)
        {
            try
            {
                var orderOutput = string.Empty;
                var orderList = orderInput.Split(",").ToList();
                var dishesList = new List<KeyValuePair<int, string>>();

                switch (orderList.First().ToUpper())
                {
                    case "MORNING":
                        foreach (var order in orderList.Skip(1))
                        {
                            var dish = (eDishMorning)Convert.ToInt32(order);

                            //Not a valid dish OR ordered the same dish more than once and is not coffee
                            if (!Enum.IsDefined(typeof(eDishMorning), dish) ||
                                (dish != eDishMorning.coffee && dishesList.Count(x => x.Value == dish.ToString()) > 0))
                            {
                                dishesList.Add(new KeyValuePair<int, string>(int.MaxValue, "error"));
                                break;
                            }

                            dishesList.Add(new KeyValuePair<int, string>(Convert.ToInt16(order), dish.ToString()));
                        }

                        //Group multiple coffees
                        var coffeCount = dishesList.Count(x => x.Key == (int)eDishMorning.coffee);
                        if (coffeCount > 1)
                        {
                            dishesList.RemoveAll(x => x.Key.Equals((int)eDishMorning.coffee));
                            dishesList.Add(new KeyValuePair<int, string>((int)eDishMorning.coffee, $"{eDishMorning.coffee}(x{ coffeCount})"));
                        }

                        break;

                    case "NIGHT":
                        foreach (var order in orderList.Skip(1))
                        {
                            var dish = (eDishNight)Convert.ToInt32(order);

                            //Not a valid dish OR ordered the same dish more than once and is not potato
                            if (!Enum.IsDefined(typeof(eDishNight), dish) ||
                                (dish != eDishNight.potato && dishesList.Count(x => x.Value == dish.ToString()) > 0))
                            {
                                dishesList.Add(new KeyValuePair<int, string>(int.MaxValue, "error"));
                                break;
                            }

                            dishesList.Add(new KeyValuePair<int, string>(Convert.ToInt16(order), dish.ToString()));
                        }

                        //Group multiple potatoes
                        var potatoCount = dishesList.Count(x => x.Key == (int)eDishNight.potato);
                        if (potatoCount > 1)
                        {
                            dishesList.RemoveAll(x => x.Key.Equals((int)eDishNight.potato));
                            dishesList.Add(new KeyValuePair<int, string>((int)eDishNight.potato, $"{eDishNight.potato}(x{ potatoCount})"));
                        }

                        break;
                }

                foreach (var dish in dishesList.OrderBy(x => x.Key))
                    orderOutput += $"{dish.Value},";

                orderOutput = orderOutput.Remove(orderOutput.Length - 1);
                return new Order() { Detail = orderOutput };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
