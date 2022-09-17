using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace API.CoreSystem.Manager.Domain.Helpers
{
    public static class PropertyUtils
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string property, bool ascending)
        {
            var propertyExists = GetProperty(source.ElementType, property) != null;
            if (!propertyExists) return source;

            var param = Expression.Parameter(typeof(TEntity), "p");
            var props = property.Split('.');

            var parent = props.Aggregate<string, Expression>(param, Expression.Property);
            var conversion = Expression.Convert(parent, typeof(object));
            var keySelector = Expression.Lambda<Func<TEntity, object>>(conversion, param);

            var selectorBody = keySelector.Body;

            var selector = Expression.Lambda(selectorBody, keySelector.Parameters);

            var queryBody = Expression.Call(typeof(Queryable),
                ascending ? "OrderBy" : "OrderByDescending",
                new Type[] { typeof(TEntity), selectorBody.Type },
                source.Expression, Expression.Quote(selector));

            return source.Provider.CreateQuery<TEntity>(queryBody);
        }

        private static PropertyInfo GetProperty(Type type, string propertyName)
        {
            if (propertyName.Contains("."))
            {
                var temp = propertyName.Split(new char[] { '.' }, 2);
                return GetProperty(GetProperty(type, temp[0])?.PropertyType, temp[1]);
            }
            else
            {
                return type?.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            }
        }
    }
}
