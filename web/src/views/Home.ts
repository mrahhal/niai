import NiaiSearch from '@/components/niai-search';
import { Kanji } from '@/models/kanji';
import { api } from '@/services/api';
import { Subject } from 'rxjs';
import { throttleTime } from 'rxjs/operators';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Home extends Vue {
  private subject = new Subject<string>();
  private kanjis: Kanji[] = [];

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

  private onSampleClick(value: string) {
    (this.$refs.search as NiaiSearch).setValue(value);
  }

  private onSearch(value: string) {
    this.subject.next(value);
  }
}
