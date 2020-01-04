import { getTheme, initializeTheming, setTheme } from 'css-theming';
import { Subject } from 'rxjs';

export const KEY = 'niai_theme';

export type AppTheme = 'light' | 'dark';

export const themeChanges = new Subject<AppTheme>();

function getThemeName(theme: AppTheme) {
  switch (theme) {
    case 'light': return 'default';
    case 'dark': return 'default-dark';
  }
}

export function initializeAppTheming() {
  const appTheme = getAppTheme();
  initializeTheming(getTheme(getThemeName(appTheme)));
}

export function getAppTheme(): AppTheme {
  const theme = localStorage.getItem(KEY) as AppTheme | null;
  if (!theme) {
    return 'light';
  } else {
    return theme;
  }
}

export function setAppTheme(appTheme: AppTheme) {
  localStorage.setItem(KEY, appTheme);
  themeChanges.next(appTheme);
  setTheme(getTheme(getThemeName(appTheme)));
}
