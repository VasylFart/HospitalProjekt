/* eslint-disable no-unused-vars */

export const appName = 'Template';

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
