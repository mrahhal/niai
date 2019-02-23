import { api } from '@/services/api';
import { Subject } from 'rxjs';
import { filter, throttleTime } from 'rxjs/operators';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Home extends Vue {
  private _subject = new Subject<string>();

  constructor() {
    super();

    this._subject.pipe(
      filter(value => !!value),
      throttleTime(500, undefined, { leading: true, trailing: true }))
      .subscribe(value => {
        api.search(value).then(x => console.log(x));
      });
  }

  onSearch = (value: string) => {
    this._subject.next(value);
  }
}
