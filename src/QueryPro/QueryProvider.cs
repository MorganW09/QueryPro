using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace QueryPro
{
    public class QueryProvider : IQueryProvider
    {
        IQueryable<S> IQueryProvider.CreateQuery<S>(Expression expression) => new Query<S>(this, expression);

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            Type elementType = TypeSystem.GetElementType(expression.Type);

            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(Query<>)
                    .MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        S IQueryProvider.Execute<S>(Expression expression) => (S)Execute(expression);

        object IQueryProvider.Execute(Expression expression) => Execute(expression);

        public object Execute(Expression expression) => Translate(expression);

        public string GetQueryText(Expression expression) => Translate(expression);

        internal string Translate(Expression expression)
        {
            return new QueryTranslator().Translate(expression);
        }
    }
}
