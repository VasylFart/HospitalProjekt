/* eslint-disable no-unused-vars */

export const appName = 'V-Project';

export const baseApiUrl = '/api';

export type AppConfig = Readonly<{
  buildNumber: string;
  contactEmailAddress: string;
}>;

declare global {
  const Config: AppConfig;
}

export function resolveAppConfig(): AppConfig {
  return {
    ...Config
  };
}
