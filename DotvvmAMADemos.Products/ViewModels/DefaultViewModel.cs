using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotvvmAMADemos.Products.Services;
using DotVVM.Framework.Controls;
using DotvvmAMADemos.Products.Model;

namespace DotvvmAMADemos.Products.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
		private readonly OrderService orderService;

		public GridViewDataSet<OrderListDTO> Orders { get; set; } = new GridViewDataSet<OrderListDTO>()
		{
			PagingOptions =
			{
				PageSize = 10
			},
			SortingOptions =
			{
				SortExpression = nameof(OrderListDTO.CreatedDate),
				SortDescending = true
			}
		};

		public DefaultViewModel(OrderService orderService)
		{
			this.orderService = orderService;
		}

		public override Task PreRender()
		{
			if (Orders.IsRefreshRequired)
			{
				IQueryable<OrderListDTO> orders = orderService.GetOrdersQuery();
				Orders.LoadFromQueryable(orders);
			}

			return base.PreRender();
		}

	}
}
