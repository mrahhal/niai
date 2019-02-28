import { Tag } from './tag';

export interface KanjiSummary {
  character: string;

  meanings: string[];

  onyomi: string;

  kunyomi: string;

  waniKaniLevel: number | null;

  tags: Tag[];

  frequency: number | null;

  strokes: number;

  jlpt: number | null;

  grade: number | null;
}

export interface Kanji extends KanjiSummary {
  similar: KanjiSummary[];
}
