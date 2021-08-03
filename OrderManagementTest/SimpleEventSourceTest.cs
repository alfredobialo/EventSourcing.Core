using System;
using System.Linq.Expressions;
using Xunit;

namespace OrderManagementTest
{
    public class SimpleEventSourceTest
    {
        [Fact]
        public void ExpressionTreeDemo()
        {
            // create a function that adds two numbers
            var num1 = Expression.Parameter(typeof(int), "num1");
            var num2 = Expression.Parameter(typeof(int), "num2");

            var plus = Expression.Add(num1, num2);
        }
    }
}
