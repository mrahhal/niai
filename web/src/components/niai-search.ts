import { Component, Vue } from 'vue-property-decorator';

@Component
export default class NiaiSearch extends Vue {
  mounted() {
    (this.$refs.input as HTMLElement).focus();
  }
}
