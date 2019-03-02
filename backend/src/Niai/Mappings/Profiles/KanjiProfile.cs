using AutoMapper;
using Niai.Models;
using Niai.Models.Dtos;

namespace Niai.Mappings.Profiles
{
	public class KanjiProfile : Profile
	{
		public KanjiProfile()
		{
			CreateMap<Kanji, KanjiDto>()
				.ForMember(x => x.Similar, c => c.Ignore())
				.ForMember(x => x.Tags, c => c.Ignore());
		}
	}
}
