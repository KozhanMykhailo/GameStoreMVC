using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.WebUI.Models
{
	public class PagingInfo
	{
		/// <summary>
		/// Количество товаров
		/// </summary>
		public int TotalItems { get; set; }
		/// <summary>
		/// Количество товаров на одной странице
		/// </summary>
		public int ItemsPerPage { get; set; }
		/// <summary>
		/// Номер текущей страницы
		/// </summary>
		public int CurrentPage { get; set; }
		/// <summary>
		/// Общее количество страниц
		/// </summary>
		public int TotalPages 
		{
			get	{ return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);}
			//get { return 4; }
		}
	}
}