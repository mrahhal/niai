import { Vocab } from '@/models';
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class VocabCard extends Vue {
  private showExtraMeanings = false;

  @Prop() vocab!: Vocab;

  private get shownCount() { return 3; }

  private get meanings() {
    return this.vocab.meanings.slice(0, this.shownCount);
  }

  private get extraMeanings() {
    return this.vocab.meanings.slice(this.shownCount);
  }

  private get jishoHref() {
    const c = this.vocab.kanji;
    return `https://jisho.org/search/${c}`;
  }
}
