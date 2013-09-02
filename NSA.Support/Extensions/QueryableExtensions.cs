using System;
using System.Linq;
using System.Linq.Expressions;

namespace NSA.Support.Extensions
{
    public static class QueryableEntityExtensions
    {
        public static object GetById(this IQueryable source, Guid id, Type type)
        {
            var parameterExpression = Expression.Parameter(type, "x");
            var propertyExpression = Expression.PropertyOrField(parameterExpression, "Id");
            var compareExpression = Expression.Equal(propertyExpression, Expression.Constant(id));
            var predicate = Expression.Lambda(compareExpression);

            var methodCall = Expression.Call(
                typeof (Queryable),
                "Where",
                new[] {source.ElementType},
                source.Expression,
                predicate);

            return source.Provider.CreateQuery(methodCall);
        }
    }
}