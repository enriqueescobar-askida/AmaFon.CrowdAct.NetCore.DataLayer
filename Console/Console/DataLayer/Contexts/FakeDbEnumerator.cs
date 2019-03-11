namespace Console.DataLayer.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="FakeDbEnumerator{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FakeDbEnumerator<T> : IAsyncEnumerator<T>
    {
        /// <summary>
        /// Defines the _inner
        /// </summary>
        private readonly IEnumerator<T> _inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDbEnumerator{T}"/> class.
        /// </summary>
        public FakeDbEnumerator() => this._inner = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDbEnumerator{T}"/> class.
        /// </summary>
        /// <param name="inner">The inner<see cref="System.Collections.Generic.IEnumerator{T}"/></param>
        public FakeDbEnumerator(IEnumerator<T> inner) => this._inner = inner ?? throw new ArgumentNullException(nameof(inner));

        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose() => this._inner.Dispose();

        /// <summary>
        /// The MoveNextAsync
        /// </summary>
        /// <param name="cancellationToken">The cancellationToken<see cref="System.Threading.CancellationToken"/></param>
        /// <returns>The <see cref="System.Threading.Tasks.Task{bool}"/></returns>
        public Task<bool> MoveNext(CancellationToken cancellationToken) => Task.FromResult(this._inner.MoveNext());

        /// <summary>
        /// The Equals
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// The GetHashCode
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString() => base.ToString();

        /// <summary>
        /// Gets the Current
        /// </summary>
        public T Current => this._inner.Current;

        /// <summary>
        /// Gets the Current
        /// </summary>
        T IAsyncEnumerator<T>.Current => Current;
    }
}
