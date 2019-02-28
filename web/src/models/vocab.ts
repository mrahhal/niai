import { Tag } from './tag';

export interface Vocab {
  kanji: string;

  kana: string;

  meanings: string[];

  tags: Tag[];

  frequency: number | null;
}
