export * from './restClient';
export * from './api';
export * from './getErrorMessage';

export const isLocalhost = () => window.location.hostname === 'localhost';

export const isLoading = (statusName: string) => statusName === 'loading';
export const isError = (statusName: string) => statusName === 'error';
export const isSuccess = (statusName: string) => statusName === 'success';

export const timeMinutes = (minutes: number) => minutes * 60 * 1000;
export const timeSeconds = (seconds: number) => seconds * 1000;

export const isTypescriptError = (err: unknown): err is Error => err instanceof Error;
