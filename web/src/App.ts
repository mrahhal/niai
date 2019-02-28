import { Component, Vue } from 'vue-property-decorator';

import { getTheme, setTheme, themeChanges } from './services/theme';

@Component
export default class App extends Vue {
  private theme = getTheme();
  private expanded = false;

  created() {
    themeChanges.subscribe(theme => {
      this.theme = theme;
    });
  }

  toggleTheme() {
    const newTheme = getTheme() === 'dark' ? 'light' : 'dark';
    setTheme(newTheme);
  }

  toggleExpansion() {
    this.expanded = !this.expanded;
  }
}
