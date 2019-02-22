using System;

namespace Aggregator
{
	[Serializable]
	public class ErrorException : Exception
	{
		public ErrorException(string message) : base(message)
		{
		}
	}
}
