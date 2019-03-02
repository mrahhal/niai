namespace Niai.Models.Dtos
{
	public class MetadataDto
	{
		public int KanjiCount { get; set; }

		public int VocabCount { get; set; }

		public int HomonymCount { get; set; }

		public int SynonymCount { get; set; }

		public int KanjiTagCount { get; set; }

		public int VocabTagCount { get; set; }

		public string Version { get; set; }
	}
}
