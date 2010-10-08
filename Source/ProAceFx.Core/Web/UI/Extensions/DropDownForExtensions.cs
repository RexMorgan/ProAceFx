using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using FubuMVC.Core.View;
using HtmlTags;

namespace ProAceFx.Core.Web.UI.Extensions
{
    public static class DropDownForExtensions
    {
        public static HtmlTag DropDownFor<TInputModel>(this IFubuPage page, Expression<Func<TInputModel, object>> expression, IDictionary<int, string> options, bool includeDefault)
               where TInputModel : class
        {
            return DropDownFor(page, null, expression, options, includeDefault);
        }

        public static HtmlTag DropDownFor<TInputModel>(this IFubuPage<TInputModel> page, Expression<Func<TInputModel, object>> expression, IDictionary<int, string> options, bool includeDefault)
            where TInputModel : class
        {
            return DropDownFor(page, page.Model, expression, options, includeDefault);
        }

        public static HtmlTag DropDownFor<TInputModel>(this IFubuPage page, TInputModel inputModel, Expression<Func<TInputModel, object>> expression, IDictionary<int, string> options, bool includeDefault)
               where TInputModel : class
        {
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression == null)
            {
                throw new ArgumentException("Invalid expression - not a unary access.", "expression");
            }

            var memberExpression = unaryExpression.Operand as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Invalid express - not a member access", "expression");
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {

                throw new ArgumentException("Invalid express - not a member access", "expression");
            }

            var compiledExpression = expression.Compile();
            var selectedKey = inputModel != null ? (int)compiledExpression(inputModel) : 0;

            var tag = new HtmlTag("select")
                .Id(propertyInfo.Name)
                .Attr("name", propertyInfo.Name);


            if (includeDefault)
            {
                var defaultOption = new HtmlTag("option").Attr("value", -1).Text("");
                if (selectedKey <= 0)
                {
                    defaultOption.Attr("selected", "selected");
                }
                tag.Child(defaultOption);
            }

            foreach (var b in options)
            {
                var option = new HtmlTag("option").Attr("value", b.Key).Text(b.Value);
                if (selectedKey == b.Key)
                {
                    option.Attr("selected", "selected");
                }
                tag.Child(option);
            }

            return tag;
        }
    }
}