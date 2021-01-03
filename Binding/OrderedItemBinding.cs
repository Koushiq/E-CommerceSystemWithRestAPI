using E_CommerceSystemWithRestAPI.Models;
using E_CommerceSystemWithRestAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_CommerceSystemWithRestAPI.Binding
{
    public class OrderedItemBinding
    {
        private OrderedItemRepository orderItemRepository;
        public OrderedItemBinding() { }
        public List<OrderedItem> customerBind(Customer customer)
        {
            List<OrderedItem> orderItem = orderItemRepository.GetAll().Where(s => s.CustomerId == customer.CustomerId && s.OderItemStatus == "incart").ToList();
            foreach (var item in orderItem)
            {
                item.Customer = customer;
            }
            return orderItem;
        }
    }
}