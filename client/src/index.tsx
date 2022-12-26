import ReactDOM from 'react-dom/client';

import { createApp } from './ApplicationFactory';
import { resolveAppConfig } from './config';

const appConfig = resolveAppConfig();
const root = ReactDOM.createRoot(document.getElementById('root') as HTMLElement);

createApp(appConfig, function (rootComponent) {
  root.render(rootComponent);
});
