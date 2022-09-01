using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Maxco.Business
{
    public class OrderScheduling:DefaultTableProperties
    {
        public OrderScheduling()
        {
            OrderKnittingScheduling = new OrderKnittingScheduling();
            OrderDyeingScheduling = new OrderDyeingScheduling();
            OrderCuttingScheduling = new OrderCuttingScheduling();
            OrderSewingScheduling = new OrderSewingScheduling();
        }
        public int ScheduleID { get; set; }
        public int OrderID { get; set; }
        public virtual OrderKnittingScheduling OrderKnittingScheduling { get; set; }
        public virtual OrderDyeingScheduling OrderDyeingScheduling { get; set; }
        public virtual OrderCuttingScheduling OrderCuttingScheduling { get; set; }
        public virtual OrderSewingScheduling OrderSewingScheduling { get; set; }

    }
}
