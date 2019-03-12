namespace Console.DataLayer.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="FakeDbSet{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FakeDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IAsyncEnumerable<TEntity> where TEntity : class
    {
        /// <summary>
        /// Defines the _primaryKeys
        /// </summary>
        private readonly PropertyInfo[] _primaryKeys;

        /// <summary>
        /// Defines the _data
        /// </summary>
        private readonly ObservableCollection<TEntity> _data;

        /// <summary>
        /// Defines the _query
        /// </summary>
        private readonly IQueryable _query;

        /// <summary>Initializes a new instance of the <see cref="FakeDbSet{TEntity}"/> class.</summary>
        public FakeDbSet()
        {
            this._data = new ObservableCollection<TEntity>();
            this._query = this._data.AsQueryable();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDbSet{TEntity}"/> class.
        /// </summary>
        /// <param name="primaryKeys">The primaryKeys<see cref="string[]"/></param>
        public FakeDbSet(params string[] primaryKeys)
        {
            this._primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            this._data = new ObservableCollection<TEntity>();
            this._query = this._data.AsQueryable();
        }

        /// <summary>
        /// The Find
        /// </summary>
        /// <param name="keyValues">The keyValues<see cref="object[]"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        public override TEntity Find(params object[] keyValues)
        {
            if (this._primaryKeys == null)
                throw new ArgumentException("No primary keys defined");
            if (keyValues.Length != this._primaryKeys.Length)
                throw new ArgumentException("Incorrect number of keys passed to Find method");

            IQueryable<TEntity> keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => this._primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }
        /*
        /// <summary>
        /// The FindAsync
        /// </summary>
        /// <param name="cancellationToken">The cancellationToken<see cref="System.Threading.CancellationToken"/></param>
        /// <param name="keyValues">The keyValues<see cref="object[]"/></param>
        /// <returns>The <see cref="System.Threading.Tasks.Task{TEntity}"/></returns>
        public override Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken);
        }
        */
        /// <summary>
        /// The FindAsync
        /// </summary>
        /// <param name="keyValues">The keyValues<see cref="object[]"/></param>
        /// <returns>The <see cref="System.Threading.Tasks.Task{TEntity}"/></returns>
        public override Task<TEntity> FindAsync(params object[] keyValues) => Task<TEntity>.Factory.StartNew(() => Find(keyValues));
        /*
        /// <summary>
        /// The AddRange
        /// </summary>
        /// <param name="entities">The entities<see cref="System.Collections.Generic.IEnumerable{TEntity}"/></param>
        /// <returns>The <see cref="System.Collections.Generic.IEnumerable{TEntity}"/></returns>
        public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");

            List<TEntity> items = entities.ToList();

            foreach (TEntity entity in items)
                this._data.Add(entity);

            return items;
        }
        *//*
        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="item">The item<see cref="TEntity"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        public override TEntity Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            this._data.Add(entity);

            return entity;
        }*/
         /*
        /// <summary>
        /// The RemoveRange
        /// </summary>
        /// <param name="entities">The entities<see cref="System.Collections.Generic.IEnumerable{TEntity}"/></param>
        /// <returns>The <see cref="System.Collections.Generic.IEnumerable{TEntity}"/></returns>
        public override IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");

            List<TEntity> items = entities.ToList();

            foreach (TEntity entity in items)
                this._data.Remove(entity);

            return items;
        }
        */ /*
        /// <summary>
        /// The Remove
        /// </summary>
        /// <param name="item">The item<see cref="TEntity"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        public override TEntity Remove(TEntity item)
        {
            if (item == null) throw new ArgumentNullException("item");

            this._data.Remove(item);

            return item;
        }
        */ /*
        /// <summary>
        /// The Attach
        /// </summary>
        /// <param name="item">The item<see cref="TEntity"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        public override TEntity Attach(TEntity item)
        {
            if (item == null) throw new ArgumentNullException("item");

            this._data.Add(item);

            return item;
        }
        */ /*
        /// <summary>
        /// The Create
        /// </summary>
        /// <returns>The <see cref="TEntity"/></returns>
        public override TEntity Create() => Activator.CreateInstance<TEntity>();

        /// <summary>
        /// The Create
        /// </summary>
        /// <typeparam name="TDerivedEntity"></typeparam>
        /// <returns>The <see cref="TDerivedEntity"/></returns>
        public override TDerivedEntity Create<TDerivedEntity>() => Activator.CreateInstance<TDerivedEntity>();
        */ /*
        /// <summary>
        /// Gets the Local
        /// </summary>
        public override ObservableCollection<TEntity> Local => _data;
        */
        /// <summary>
        /// Gets the ElementType
        /// </summary>
        Type IQueryable.ElementType => this._query.ElementType;

        /// <summary>
        /// Gets the Expression
        /// </summary>
        Expression IQueryable.Expression => this._query.Expression;

        /// <summary>
        /// Gets the Provider
        /// </summary>
        IQueryProvider IQueryable.Provider => new FakeDbQueryProvider<TEntity>(this._query.Provider);

        /// <summary>
        /// The GetEnumerator
        /// </summary>
        /// <returns>The <see cref="System.Collections.IEnumerator"/></returns>
        IEnumerator IEnumerable.GetEnumerator() => this._data.GetEnumerator();

        /// <summary>
        /// The GetEnumerator
        /// </summary>
        /// <returns>The <see cref="System.Collections.Generic.IEnumerator{TEntity}"/></returns>
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() => this._data.GetEnumerator();
        /*
        /// <summary>
        /// The GetAsyncEnumerator
        /// </summary>
        /// <returns>The <see cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerator{TEntity}"/></returns>
        IAsyncEnumerator<TEntity> IAsyncEnumerator<TEntity>.GetAsyncEnumerator() => new FakeDbEnumerator<TEntity>(_data.GetEnumerator());
        */
        public IAsyncEnumerator<TEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IAsyncEnumerator<TEntity> IAsyncEnumerable<TEntity>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
