﻿namespace Console.DataLayer.Contexts
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="FakeAsyncEnumerator{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FakeAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        /// <summary>
        /// Defines the _inner
        /// </summary>
        private readonly IEnumerator<T> _inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeAsyncEnumerator{T}"/> class.
        /// </summary>
        /// <param name="inner">The inner<see cref="System.Collections.Generic.IEnumerator{T}"/></param>
        public FakeAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeAsyncEnumerator{T}"/> class.
        /// </summary>
        public FakeAsyncEnumerator()
        {
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose()
        {
            _inner.Dispose();
        }

        /// <summary>
        /// The MoveNextAsync
        /// </summary>
        /// <param name="cancellationToken">The cancellationToken<see cref="System.Threading.CancellationToken"/></param>
        /// <returns>The <see cref="System.Threading.Tasks.Task{bool}"/></returns>
        public Task<bool> MoveNext(CancellationToken cancellationToken) => Task.FromResult(_inner.MoveNext());

        /// <summary>
        /// The Equals
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// The GetHashCode
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Gets the Current
        /// </summary>
        public T Current => _inner.Current;

        /// <summary>
        /// Gets the Current
        /// </summary>
        T IAsyncEnumerator<T>.Current => Current;
    }
}
