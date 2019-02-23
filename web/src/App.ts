import { Component, Vue } from 'vue-property-decorator';

import { getTheme, setTheme, themeChanges } from './services/theme';

@Component
export default class App extends Vue {
  private theme = getTheme();

  created() {
    themeChanges.subscribe(theme => {
      this.theme = theme;
    });
  }

  update() {
    this.theme = this.theme;
  }

  toggleTheme() {
    const newTheme = getTheme() === 'dark' ? 'light' : 'dark';
    setTheme(newTheme);
  }
}
