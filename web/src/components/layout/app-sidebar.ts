import { Component, Vue } from 'vue-property-decorator';

import { getAppTheme, themeChanges } from '../../services/theme';

@Component
export default class AppSidebar extends Vue {
  private theme = getAppTheme();

  created() {
    themeChanges.subscribe(theme => {
      this.theme = theme;
    });
  }
}
