import { get } from './restClient';

function addParams(address: string, urlSearchParams?: URLSearchParams) {
  if (urlSearchParams) {
    return address.concat(`?${urlSearchParams}`);
  }

  return address;
}

export async function getExtended(address: string, urlSearchParams?: URLSearchParams) {
  const resultAddress = addParams(address, urlSearchParams);

  return get(resultAddress);
}
