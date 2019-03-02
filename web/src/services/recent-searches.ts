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
  const searches = getRecentSearches().reverse();
  const index = searches.indexOf(search);

  if (index >= 0) {
    searches.splice(index, 1);
    searches.push(search);
  } else if (searches.length < MAX_SEARCHES) {
    searches.push(search);
  } else {
    searches.shift();
    searches.push(search);
  }

  localStorage.setItem(KEY, JSON.stringify(searches.reverse()));
  return searches;
}
