import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class NiaiSearch extends Vue {
  @Prop() private text!: string;
}
