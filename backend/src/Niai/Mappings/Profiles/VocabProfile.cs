using AutoMapper;
using Niai.Models;
using Niai.Models.Dtos;

namespace Niai.Mappings.Profiles
{
	public class VocabProfile : Profile
	{
		public VocabProfile()
		{
			CreateMap<Vocab, VocabDto>()
				.ForMember(x => x.Meanings, c => c.Ignore());

			CreateMap<VocabContextualMeaning, VocabContextualMeaningDto>()
				.ForMember(x => x.Tags, c => c.Ignore());
		}
	}
}
