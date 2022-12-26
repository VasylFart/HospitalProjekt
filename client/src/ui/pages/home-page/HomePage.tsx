import { useReadWeatherForecast } from '../../../apiQueryHooks';
import { appName } from '../../../config';

export const HomePage = () => {
  const { data: weatherForecast } = useReadWeatherForecast();

  return (
    <>
      {appName}
      <div>
        {weatherForecast?.map(w => (
          <li key={w.date.toString()}>{`${w.date} ${w.summary} ${w.temperatureC}`}</li>
        ))}
      </div>
    </>
  );
};
