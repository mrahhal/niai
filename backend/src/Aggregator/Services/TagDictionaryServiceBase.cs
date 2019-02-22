using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Aggregator.Services
{
	public abstract class TagDictionaryServiceBase
	{
		public SafeMap<TagModel> Tags { get; private set; }

		protected void ProcessTagBanks(List<FileInfo> fileInfoes)
		{
			var serialzer = new JsonSerializer();
			var map = new SafeMap<TagModel>();

			foreach (var fileInfo in fileInfoes)
			{
				using (var fs = fileInfo.OpenRead())
				using (var sr = new StreamReader(fs))
				using (var jtr = new JsonTextReader(sr))
				{
					var raw = serialzer.Deserialize<TagModelRaw>(jtr);
					var models = raw.Select(l =>
					{
						var key = (string)l[0];
						var order = Convert.ToInt32(l[2]);
						var value = (string)l[3];

						return new TagModel { Key = key, Value = value, Order = order };
					});

					foreach (var model in models)
					{
						map[model.Key] = model;
					}
				}
			}

			Tags = map;
		}
	}
}
