import { Kanji, KanjiSummary } from '@/models/kanji';
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class KanjiCard extends Vue {
  @Prop() kanji!: KanjiSummary;

  private get isOriginal() {
    return !!(this.kanji as Kanji).similar;
  }

  private get waniKaniHref() {
    const c = this.kanji.character;
    return `http://wanikani.com/kanji/${c}`;
  }

  private get jishoHref() {
    const c = this.kanji.character;
    return `https://jisho.org/search/${c}%20%23kanji`;
  }
}
