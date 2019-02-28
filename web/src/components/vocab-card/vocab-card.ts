import { Vocab } from '@/models';
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class VocabCard extends Vue {
  @Prop() vocab!: Vocab;

  private get jishoHref() {
    const c = this.vocab.kanji;
    return `https://jisho.org/search/${c}`;
  }
}
