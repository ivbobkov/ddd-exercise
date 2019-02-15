using System;
using Microsoft.AspNetCore.Html;

namespace MoneyTracker.Web.Infrastructure
{
    public static class ViewExtensions
    {
        public static HtmlString AsFormatted(this DateTime dateTime)
        {
            return new HtmlString(dateTime.ToString(ViewConstants.DefaultDateTime));
        }
    }
}