import { Kanji } from './kanji';
import { Vocab } from './vocab';

export interface SearchResult {
  kanjis: Kanji[];

  homonyms: Vocab[];

  synonyms: Vocab[];
}
