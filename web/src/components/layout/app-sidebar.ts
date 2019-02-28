import { Component, Vue } from 'vue-property-decorator';

import { getTheme, themeChanges } from '../../services/theme';

@Component
export default class AppSidebar extends Vue {
  private theme = getTheme();

  created() {
    themeChanges.subscribe(theme => {
      this.theme = theme;
    });
  }
}
