﻿using System;
using System.ComponentModel;

namespace MetroRadiance.Internal
{
	[Obsolete]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal class Disposable
	{
		public static IDisposable Create(Action dispose)
		{
			return new AnonymousDisposable(dispose);
		}

		private class AnonymousDisposable : IDisposable
		{
			private bool _isDisposed;
			private readonly Action _dispose;

			public AnonymousDisposable(Action dispose)
			{
				this._dispose = dispose;
			}

			public void Dispose()
			{
				if (this._isDisposed) return;

				this._isDisposed = true;
				this._dispose();
			}
		}
	}
}
