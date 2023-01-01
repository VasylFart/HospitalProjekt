export function toURLSearchParams(queryParams?: Object): URLSearchParams | undefined {
  if (!queryParams) {
    return undefined;
  }

  const params = Object.entries(queryParams).filter(p => {
    return p[1] !== undefined && p[1] !== '';
  });

  return new URLSearchParams(params);
}
