import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class NiaiSearch extends Vue {
  @Prop() loading: boolean = false;

  private get inputElement() { return this.$refs.input as HTMLInputElement; }

  mounted() {
    this.inputElement.focus();
  }

  setValue(value: string | null) {
    if (!value) {
      value = '';
    }

    this.inputElement.value = value;
    this.emitValue();

    this.inputElement.focus();
  }

  private emitValue() {
    this.$emit('input', this.inputElement.value);
  }
}
