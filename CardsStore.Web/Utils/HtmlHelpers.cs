using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CardsStore.Web.Utils
{
	public static class HtmlHelpers
	{
		public static MvcHtmlString IncludeScript(this HtmlHelper html, string scriptUrl)
		{
			TagBuilder scriptBuilder = new TagBuilder("script");
			scriptBuilder.Attributes.Add("type", "text/javascript");
			var scriptPath = HttpContext.Current.Server.MapPath(scriptUrl);
			if (File.Exists(scriptPath))
			{
				var script = File.ReadAllText(scriptPath);
				scriptBuilder.InnerHtml = script;
			}
			
			return new MvcHtmlString(scriptBuilder.ToString());
		}

		public static MvcHtmlString CheckboxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
			IEnumerable<SelectListItem> selectList, object htmlAttributes = null)
		{
			var outputHtml = new StringBuilder("");
			foreach (var item in selectList)
			{
				outputHtml.Append(htmlHelper.CheckBox(item.Group.Name, item.Selected, new {value = item.Value, text = item.Text}).ToHtmlString());
			}
			
			return new MvcHtmlString(outputHtml.ToString());
		}
	}
}