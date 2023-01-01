import { useQuery } from 'react-query';

import { baseApiUrl } from '../config';
import { WeatherForecastDto } from '../types';
import { get } from '../utils';
import { useDefaultOptions } from './optionHooks';

export const useReadWeatherForecast = () =>
  useQuery<WeatherForecastDto[]>(
    'weather-forecast',
    () => get(`${baseApiUrl}/weather-forecast`),
    useDefaultOptions<WeatherForecastDto[]>('weather-forecast')
  );
