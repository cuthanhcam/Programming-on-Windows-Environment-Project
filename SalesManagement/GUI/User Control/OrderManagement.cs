using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class OrderManagement : UserControl
    {
        private readonly OrderService _orderService;
        
        public OrderManagement(OrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
        }

    }
}
