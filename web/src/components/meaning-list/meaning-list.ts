import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class MeaningList extends Vue {
  @Prop() meanings!: string[];
}
