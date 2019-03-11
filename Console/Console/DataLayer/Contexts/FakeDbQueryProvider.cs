namespace Console.DataLayer.Contexts
{
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public class FakeDbQueryProvider<TEntity> : IAsyncQueryProvider
    {
        /// <summary>
        /// Defines the _inner
        /// </summary>
        private readonly IQueryProvider _inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDbQueryProvider{TEntity}"/> class.
        /// </summary>
        /// <param name="inner">The inner<see cref="IQueryProvider"/></param>
        public FakeDbQueryProvider(IQueryProvider inner) => this._inner = inner;

        /// <summary>
        /// The CreateQuery
        /// </summary>
        /// <param name="expression">The expression<see cref="System.Linq.Expressions.Expression"/></param>
        /// <returns>The <see cref="IQueryable"/></returns>
        public IQueryable CreateQuery(Expression expression)
        {
            MethodCallExpression m = expression as MethodCallExpression;

            if (m != null)
            {
                Type resultType = m.Method.ReturnType; // it shoud be IQueryable<T>
                Type tElement = resultType.GetGenericArguments()[0];
                Type queryType = typeof(FakeDbEnumerable<>).MakeGenericType(tElement);

                return (IQueryable)Activator.CreateInstance(queryType, expression);
            }

            return new FakeDbEnumerable<TEntity>(expression);
        }

        /// <summary>
        /// The CreateQuery
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="expression">The expression<see cref="System.Linq.Expressions.Expression"/></param>
        /// <returns>The <see cref="IQueryable{TElement}"/></returns>
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            Type queryType = typeof(FakeDbEnumerable<>).MakeGenericType(typeof(TElement));

            return (IQueryable<TElement>)Activator.CreateInstance(queryType, expression);
        }

        /// <summary>
        /// The Execute
        /// </summary>
        /// <param name="expression">The expression<see cref="System.Linq.Expressions.Expression"/></param>
        /// <returns>The <see cref="object"/></returns>
        public object Execute(Expression expression) => this._inner.Execute(expression);

        /// <summary>
        /// The Execute
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression">The expression<see cref="System.Linq.Expressions.Expression"/></param>
        /// <returns>The <see cref="TResult"/></returns>
        public TResult Execute<TResult>(Expression expression) => this._inner.Execute<TResult>(expression);

        /// <summary>
        /// The ExecuteAsync
        /// </summary>
        /// <param name="expression">The expression<see cref="System.Linq.Expressions.Expression"/></param>
        /// <param name="cancellationToken">The cancellationToken<see cref="System.Threading.CancellationToken"/></param>
        /// <returns>The <see cref="System.Threading.Tasks.Task{object}"/></returns>
        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken) => Task.FromResult(Execute(expression));

        /// <summary>
        /// The ExecuteAsync
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression">The expression<see cref="System.Linq.Expressions.Expression"/></param>
        /// <param name="cancellationToken">The cancellationToken<see cref="System.Threading.CancellationToken"/></param>
        /// <returns>The <see cref="System.Threading.Tasks.Task{TResult}"/></returns>
        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken) => Task.FromResult(Execute<TResult>(expression));

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
