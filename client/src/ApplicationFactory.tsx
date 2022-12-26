import { ReactElement, StrictMode } from 'react';
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';

import { AppConfig } from './config';
import { Providers } from './providers/Providers';
import { AppMain } from './ui/layout/AppMain';
import { AppPage } from './ui/layout/AppPage';
import { ErrorBoundary, HomePage } from './ui/pages';

const App = ({ appConfig }: { appConfig: AppConfig }) => {
  return (
    <BrowserRouter>
      <AppMain>
        <Routes>
          <Route element={<HomePage />} path="home" />
          <Route element={<Navigate replace to="home" />} path="/" />
          <Route element={<AppPage title="Page Not Found" />} path="*" />
        </Routes>
      </AppMain>
    </BrowserRouter>
  );
};

export function createApp(appConfig: AppConfig, renderFn: (_rootComponent: ReactElement) => void) {
  return (() => {
    return renderFn(
      <ErrorBoundary>
        <StrictMode>
          <Providers>
            <App appConfig={appConfig} />
          </Providers>
        </StrictMode>
      </ErrorBoundary>
    );
  })();
}
