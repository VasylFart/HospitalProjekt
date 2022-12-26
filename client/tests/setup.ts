import { configure } from '@testing-library/dom';
import expect from 'expect.js';
import { setupServer } from 'msw/node';

import { handlers } from './_support/requestHandlers';

import '@testing-library/jest-dom/extend-expect';
import 'whatwg-fetch';

export const server = setupServer(...handlers);

global.expect = expect;

const originalError = console.error;
const originalWarn = console.warn;

beforeAll(() => {
  // this is here to silence a warning temporarily
  sileceThirdPartyErrors();

  // Establish API mocking before all tests.
  server.listen();
});

beforeEach(() => {
  // reset url
  global.window.history.pushState({}, 'Home page', '/');
});

// Reset any request handlers that we may add during the tests,
// so they don't affect other tests.
afterEach(() => server.resetHandlers());
// Clean up after the tests are finished.
afterAll(() => server.close());

configure({
  //turn off automatic DOM logging because it's too noisy
  //if you want to see the DOM, comment the function below
  //or log it manually with screen.debug(undefined, Number.MAX_VALUE)
  getElementError: function (message: string | null) {
    return new Error(message ?? 'Could not get element');
  }
});

function sileceThirdPartyErrors() {
  jest.spyOn(console, 'error').mockImplementation((...args) => {
    if (typeof args[0] === 'string' && args[0].includes('a test was not wrapped in act')) {
      return;
    }
    if (typeof args[0] === 'object' && args[0].message.includes('Expected key descriptor but found')) {
      return;
    }
    return originalError.call(console, args[0]);
  });
  jest.spyOn(console, 'warn').mockImplementation((...args) => {
    if (typeof args[0] === 'string' && args[0].includes('tippy.js')) {
      return;
    }
    return originalWarn.call(console, args);
  });
}
