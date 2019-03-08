namespace Console.DataLayer.Contexts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class FakeAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeAsyncEnumerable{T}"/> class.
        /// </summary>
        /// <param name="enumerable">The enumerable<see cref="System.Collections.Generic.IEnumerable{T}"/></param>
        public FakeAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeAsyncEnumerable{T}"/> class.
        /// </summary>
        /// <param name="expression">The expression<see cref="System.Linq.Expressions.Expression"/></param>
        public FakeAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        IAsyncEnumerator<T> IAsyncEnumerable<T>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public IAsyncEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        /*
        /// <summary>
        /// The GetAsyncEnumerator
        /// </summary>
        /// <returns>The <see cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerator{T}"/></returns>
        public System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        /// <summary>
        /// The GetAsyncEnumerator
        /// </summary>
        /// <returns>The <see cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerator"/></returns>
        System.Data.Entity.Infrastructure.IDbAsyncEnumerator System.Data.Entity.Infrastructure.IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }*/

        /// <summary>
        /// Gets the Provider
        /// </summary>
        IQueryProvider IQueryable.Provider => new FakeAsyncQueryProvider<T>(this);
    }
}
