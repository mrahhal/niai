import { KanjiSummary } from '@/models/kanji';
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class KanjiCard extends Vue {
  @Prop() kanji!: KanjiSummary;

  private get href() {
    const c = this.kanji.character;
    return this.kanji.waniKaniLevel ? `http://wanikani.com/kanji/${c}` : `https://jisho.org/search/${c}`;
  }
}
