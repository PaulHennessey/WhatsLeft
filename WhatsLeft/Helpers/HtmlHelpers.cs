using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace WhatsLeft.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString OrdinalFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            int num = (int)ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model;

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return new MvcHtmlString(num + "th");
            }

            switch (num % 10)
            {
                case 1:
                    return new MvcHtmlString(num + "st");
                case 2:
                    return new MvcHtmlString(num + "nd");
                case 3:
                    return new MvcHtmlString(num + "rd");
                default:
                    return new MvcHtmlString(num + "th");
            }
        }
    }
}