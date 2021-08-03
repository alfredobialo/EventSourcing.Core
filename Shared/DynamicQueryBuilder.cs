using System;
using System.Linq.Expressions;

namespace Shared
{
    /// <summary>
    /// Using Expression Trees to Build Queries
    /// </summary>
    public class DynamicQueryBuilder
    {
        public void TestExpression()
        {
            var val1  = Expression.Parameter(typeof(int),"x");
            var val2  = Expression.Parameter(typeof(int),"y");

            var addOperator = Expression.Add(val1, val2);
            var sum = Expression.Variable(typeof(int),"sum");
            var equals = Expression.Assign(sum, addOperator);

            Expression<Func<int, int,int>> sumExpression  = (x,y) => x+y;

            var sumCompiled = sumExpression.Compile()(40,90);
        }
    }
}
