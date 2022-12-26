import { QueryKey, UseQueryOptions } from 'react-query';

import { getErrorMessage, timeMinutes, timeSeconds } from '../utils';

export function useDefaultOptions<T>(
  queryKey: string
): Omit<UseQueryOptions<T, unknown, T, QueryKey>, 'queryKey' | 'queryFn'> {
  return {
    cacheTime: timeMinutes(30),
    staleTime: timeMinutes(30),
    retry: 0,
    onError: (err: unknown) => {
      throw getErrorMessage(err);
    }
  };
}

export function useQueryOptions<T>(
  queryKey: string
): Omit<UseQueryOptions<T, unknown, T, QueryKey>, 'queryKey' | 'queryFn'> {
  return {
    ...useDefaultOptions<T>(queryKey),
    cacheTime: timeMinutes(5),
    staleTime: timeSeconds(20)
  };
}
