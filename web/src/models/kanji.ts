export interface Tag {
  key: string;

  value: string;
}

export interface KanjiSummary {
  character: string;

  meanings: string[];

  onyomi: string;

  kunyomi: string;

  waniKaniLevel: number | null;

  tags: Tag[];

  frequency: number | null;
}

export interface Kanji extends KanjiSummary {
  similar: KanjiSummary[];
}
