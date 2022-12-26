import { cleanup, render } from '@testing-library/react';
import { ReactElement } from 'react';

import { createApp } from '../../src/ApplicationFactory';
import { AppConfig } from '../../src/config';
import { HomePage } from './Application';
export default class ApplicationBuilder {
  async render(): Promise<HomePage> {
    const appConfig: AppConfig = {
      buildNumber: '12345',
      contactEmailAddress: 'test.local@dnv.com'
    };

    createApp(appConfig, function (rootComponent: ReactElement) {
      //ReactDOM.render() replaces the content of the container it is rendering into,
      //but render() creates a new container; calling cleanup() defeats this problem
      cleanup();
      render(rootComponent);
    });
    return Promise.resolve(new HomePage());
  }
}
