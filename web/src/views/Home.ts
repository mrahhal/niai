import NiaiSearch from '@/components/niai-search/niai-search';
import { SearchResult } from '@/models';
import { api } from '@/services/api';
import { Subject } from 'rxjs';
import { switchMap, tap, throttleTime } from 'rxjs/operators';
import { Component, Vue, Watch } from 'vue-property-decorator';

@Component
export default class Home extends Vue {
  private subject = new Subject<string>();
  private result: SearchResult | null = null;
  private loading = false;

  private get qParam() { return this.$route.query.q as string; }

  private get kanjis() { return this.result && this.result.kanjis || []; }
  private get homonyms() { return this.result && this.result.homonyms || []; }
  private get synonyms() { return this.result && this.result.synonyms || []; }

  created() {
    this.subject.pipe(
      throttleTime(500, undefined, { leading: true, trailing: true }),
      tap(() => this.loading = true),
      switchMap(value => value ? api.search(value).catch(() => null) : Promise.resolve(null)),
    ).subscribe(data => {
      this.loading = false;
      this.result = data;
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
