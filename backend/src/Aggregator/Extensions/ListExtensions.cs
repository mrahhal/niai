using System.Collections.Generic;
using System.Linq;
using Aggregator.Services;

namespace Aggregator
{
	public static class ListExtensions
	{
		public static string Join(this IEnumerable<TagModel> list)
		{
			return string.Join(" ", list.Select(x => x.Key));
		}
	}
}
