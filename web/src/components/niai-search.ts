import { Component, Vue } from 'vue-property-decorator';

@Component
export default class NiaiSearch extends Vue {
  private get inputElement() { return this.$refs.input as HTMLInputElement; }

  mounted() {
    this.inputElement.focus();
  }

  setValue(value: string) {
    this.inputElement.value = value;
    this.emitValue();
  }

  private emitValue() {
    this.$emit('input', this.inputElement.value);
  }
}
