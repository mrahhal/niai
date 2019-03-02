import { Tag } from './tag';

export interface Vocab {
  kanji: string;

  frequency: number | null;

  meanings: VocabContextualMeaning[];
}

export interface VocabContextualMeaning {
  kanji: string;

  kana: string;

  meanings: string[];

  tags: Tag[];
}
