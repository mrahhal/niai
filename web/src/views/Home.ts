import { Kanji } from '@/models/kanji';
import { api } from '@/services/api';
import { Subject } from 'rxjs';
import { filter, throttleTime } from 'rxjs/operators';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Home extends Vue {
  private subject = new Subject<string>();
  private kanjis: Kanji[] = [];

  created() {
    this.subject.pipe(
      filter(value => !!value),
      throttleTime(500, undefined, { leading: true, trailing: true }),
    ).subscribe(value => {
      api.search(value).then(kanjis => this.kanjis = kanjis);
    });
  }

  private onSearch = (value: string) => {
    this.subject.next(value);
  }
}
