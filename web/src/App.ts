import { Component, Prop, Vue } from 'vue-property-decorator';
import { getTheme, themeChanges } from './services/theme';

@Component
export default class App extends Vue {
  private theme = getTheme();

  constructor() {
    super();
    themeChanges.subscribe(theme => this.theme = theme);
  }
}
