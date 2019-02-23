import { Subject } from 'rxjs';

export const KEY = 'niai_theme';

export type Theme = 'light' | 'dark';

export const themeChanges = new Subject<Theme>();

export function getTheme(): Theme {
  const theme = localStorage.getItem(KEY) as Theme | null;
  if (!theme) {
    return 'light';
  } else {
    return theme;
  }
}

export function setTheme(theme: Theme) {
  localStorage.setItem(KEY, theme);
  themeChanges.next(theme);
}
