import { KanjiSummary } from '@/models/kanji';
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class KanjiCardList extends Vue {
  @Prop() kanjis!: KanjiSummary[];
}
