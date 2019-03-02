import NiaiSearch from '@/components/niai-search/niai-search';
import { SearchResult } from '@/models';
import { api } from '@/services/api';
import { BehaviorSubject } from 'rxjs';
import { debounceTime, switchMap, tap } from 'rxjs/operators';
import { Component, Vue, Watch } from 'vue-property-decorator';

import { getRecentSearches, updateRecentSearches } from '../services/recent-searches';

@Component
export default class Home extends Vue {
  private subject = new BehaviorSubject<string>('');
  private result: SearchResult | null = null;
  private recentSearches: string[] = getRecentSearches().reverse();
  private loading = false;

  private get qParam() { return this.$route.query.q as string; }

  private get kanjis() { return this.result && this.result.kanjis || []; }
  private get homonyms() { return this.result && this.result.homonyms || []; }
  private get synonyms() { return this.result && this.result.synonyms || []; }

  created() {
    this.subject.pipe(
      debounceTime(300),
      // throttleTime(500, undefined, { leading: true, trailing: true }),
      tap(() => this.loading = true),
      switchMap(value => value ? api.search(value).catch(() => null) : Promise.resolve(null)),
    ).subscribe(data => {
      const value = this.subject.value;
      if (!value) {
        this.$router.push({ query: {} });
      } else if (data && (data.kanjis.length || data.homonyms.length || data.synonyms.length)) {
        this.$router.push({ query: { q: value } });
        this.recentSearches = updateRecentSearches(value).reverse();
      }

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
    this.subject.next(value);
  }

  @Watch('$route')
  private onRouteChange() {
    this.setSearchValue(this.qParam);
  }
}
