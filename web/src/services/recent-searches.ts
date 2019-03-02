export const KEY = 'recent_searches';
export const MAX_SEARCHES = 5;

export function getRecentSearches(): string[] {
  const searches = localStorage.getItem(KEY) as string | null;
  if (!searches) {
    return [];
  } else {
    return JSON.parse(searches);
  }
}

export function updateRecentSearches(search: string): string[] {
  const searches = getRecentSearches();
  const index = searches.indexOf(search);

  if (index >= 0) {
    searches.splice(index, 1);
    searches.unshift(search);
  } else if (searches.length < MAX_SEARCHES) {
    searches.unshift(search);
  } else {
    searches.pop();
    searches.unshift(search);
  }

  localStorage.setItem(KEY, JSON.stringify(searches));
  return searches;
}
