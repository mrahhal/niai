using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MR.AttributeDI;
using Niai.Models;
using Niai.Models.Dtos;

namespace Niai.Services
{
	[AddToServices(Lifetime.Singleton, AsImplementedInterface = true)]
	public class ModelMapper : IModelMapper
	{
		private readonly IMapper _mapper;
		private readonly IDataProvider _dataProvider;

		public ModelMapper(
			IMapper mapper,
			IDataProvider dataProvider)
		{
			_mapper = mapper;
			_dataProvider = dataProvider;
		}

		public List<KanjiDto> Map(IEnumerable<Kanji> kanjis)
		{
			var dbKanjis = _dataProvider.Kanjis;
			var dbKanjiTags = _dataProvider.KanjiTags;

			return kanjis.Select(kanji =>
			{
				var similar = kanji.Similar
					.Select(x => (Kanji: dbKanjis[x.Kanji], x.Score))
					.Where(x => x.Kanji != null);

				var dto = _mapper.Map<KanjiDto>(kanji);

				dto.Similar = similar.Select(x =>
				{
					var similarDto = _mapper.Map<KanjiSimilarDto>(x.Kanji);
					similarDto.Score = x.Score;
					similarDto.Tags = x.Kanji.Tags.Select(tag => dbKanjiTags[tag]).ToList();
					return similarDto;
				}).OrderByDescending(x => x.Score).ToList();

				dto.Tags = kanji.Tags.Select(tag => dbKanjiTags[tag]).ToList();

				return dto;
			}).ToList();
		}

		public List<VocabDto> Map(IEnumerable<Vocab> vocabs)
		{
			var dbVocabs = _dataProvider.Vocabs;
			var dbVocabTags = _dataProvider.VocabTags;

			return vocabs.Select(vocab =>
			{
				var dto = _mapper.Map<VocabDto>(vocab);

				dto.Meanings = vocab.Meanings.Select(cm =>
				{
					var mDto = _mapper.Map<VocabContextualMeaningDto>(cm);
					mDto.Tags = cm.Tags.Select(tag => dbVocabTags[tag]).ToList();
					return mDto;
				}).ToList();

				return dto;
			}).ToList();
		}
	}
}
