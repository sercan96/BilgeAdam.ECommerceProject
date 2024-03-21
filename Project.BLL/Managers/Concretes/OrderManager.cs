using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class OrderManager : BaseManager<Order>, IOrderManager
    {
        IOrderRepository _ordRep;
        public OrderManager(IOrderRepository ordRep) :base(ordRep)
        {
            _ordRep = ordRep;
        }

        public override string Add(Order item)
        {
            // BL (KDV, Gümrük,Kargo vs işlemleri(ücret işlemleri))
            return base.Add(item);
        }
    }
}
