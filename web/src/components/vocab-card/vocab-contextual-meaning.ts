import { VocabContextualMeaning } from '@/models';
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class VocabContextualMeaningComponent extends Vue {
  @Prop() meaning!: VocabContextualMeaning;
  @Prop() index!: number;
}
