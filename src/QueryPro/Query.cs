using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QueryPro
{
    public class Query<T> : IQueryable<T>, IQueryable, IEnumerable<T>, IEnumerable, IOrderedQueryable<T>, IOrderedQueryable
    {
        QueryProvider provider;
        Expression expression;

        public Query(QueryProvider provider)
        {
            this.provider = provider;
            this.expression = Expression.Constant(this);
        }

        public Query(QueryProvider provider, Expression expression)
        {
            this.provider = provider;
            this.expression = expression;
        }

        Type IQueryable.ElementType => typeof(T);
        Expression IQueryable.Expression => expression;
        IQueryProvider IQueryable.Provider => provider;

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)provider.Execute(expression)).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)provider.Execute(expression)).GetEnumerator();

        public override string ToString() => provider.GetQueryText(expression);
    }
}
