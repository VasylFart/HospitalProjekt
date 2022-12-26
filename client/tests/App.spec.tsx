import { waitFor } from '@testing-library/react';

import { Page } from './_support/Application';
import ApplicationBuilder from './_support/ApplicationBuilder';

describe('Application', function () {
  it('renders without crashing', async () => {
    await waitFor<Page>(async (): Promise<Page> => {
      return new ApplicationBuilder().render();
    });
  });
});
