import NiaiSearch from '@/components/niai-search';
import { Kanji } from '@/models/kanji';
import { api } from '@/services/api';
import { Subject } from 'rxjs';
import { throttleTime } from 'rxjs/operators';
import { Component, Vue, Watch } from 'vue-property-decorator';

@Component
export default class Home extends Vue {
  private subject = new Subject<string>();
  private kanjis: Kanji[] = [];

  private get qParam() { return this.$route.query.q as string; }

  created() {
    this.subject.pipe(
      throttleTime(500, undefined, { leading: true, trailing: true }),
    ).subscribe(value => {
      if (!value) {
        this.kanjis = [];
        return;
      }
      api.search(value).then(kanjis => this.kanjis = kanjis);
    });
  }

  mounted() {
    if (this.qParam) {
      this.setSearchValue(this.qParam);
    }
  }

  private setSearchValue(value: string) {
    (this.$refs.search as NiaiSearch).setValue(value);
  }

  private onSearch(value: string) {
    if (!value) {
      this.$router.replace({ query: {} });
    } else {
      this.$router.replace({ query: { q: value } });
    }

    this.subject.next(value);
  }

  @Watch('$route')
  private onRouteChange() {
    this.setSearchValue(this.qParam);
  }
}
