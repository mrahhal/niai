using Autofac;
using Aggregator.Services;
using IContainer = Autofac.IContainer;

namespace Aggregator
{
	public static class ContainerAccessor
	{
		static ContainerAccessor()
		{
			Container = ConfigureServices();
		}

		public static IContainer Container { get; private set; }

		private static IContainer ConfigureServices()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<Program>().AsSelf().SingleInstance();
			builder.RegisterType<DictionaryProvider>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<WaniKaniService>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<FrequencyDictionaryService>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<KanjiDictionaryService>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<VocabDictionaryService>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<WaniKaniDictionaryService>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<SimilarKeiseiDictionaryService>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<SimilarNotoDictionaryService>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<AggregatorService>().AsImplementedInterfaces().SingleInstance();
			builder.RegisterType<ExportService>().AsImplementedInterfaces().SingleInstance();

			return builder.Build();
		}
	}
}
