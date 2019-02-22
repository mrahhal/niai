using System;
using System.Collections.Generic;

namespace Aggregator.Helpers
{
	public static class TagHelper
	{
		public static List<string> SplitTags(string tags, string tags2 = null)
		{
			var list = new List<string>();

			AddRange(tags);
			AddRange(tags2);

			return list;

			void AddRange(string t)
			{
				if (!string.IsNullOrWhiteSpace(t))
				{
					list.AddRange(t.Split(' '));
				}
			}
		}
	}
}
