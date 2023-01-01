import { rest } from 'msw';

import weatherForecastsResponse from './../mocks/weather-forecasts.json';

export const handlers = [
  rest.get('*/api/weather-forecasts', (req, res, ctx) => {
    return res(ctx.status(200), ctx.json(weatherForecastsResponse));
  })
];
