import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class NiaiSearch extends Vue {
  private q: string = '';

  @Prop() loading: boolean = false;

  private get inputElement() { return this.$refs.input as HTMLInputElement; }

  private get hasText() { return !!this.q; }

  mounted() {
    this.inputElement.focus();
  }

  setValue(value: string | null) {
    if (!value) {
      value = '';
    }

    if (this.q === value) {
      return;
    }

    this.q = value;
    this.emitValue();

    this.inputElement.focus();
  }

  clear() {
    this.setValue(null);
  }

  private emitValue() {
    this.$emit('input', this.q);
  }
}
