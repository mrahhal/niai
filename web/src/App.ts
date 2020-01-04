import { Component, Vue } from 'vue-property-decorator';

import { getAppTheme, initializeAppTheming, setAppTheme } from './services/theme';

@Component
export default class App extends Vue {
  private expanded = false;

  created() {
    initializeAppTheming();
  }

  toggleTheme() {
    const newTheme = getAppTheme() === 'dark' ? 'light' : 'dark';
    setAppTheme(newTheme);
  }

  toggleExpansion() {
    this.expanded = !this.expanded;
  }
}
