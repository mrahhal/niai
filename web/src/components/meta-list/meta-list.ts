import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class MetaList extends Vue {
  @Prop() frequency!: number | null;
  @Prop() grade!: number | null;
}
