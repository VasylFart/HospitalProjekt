import { useReadWeatherForecast } from '../../../apiQueryHooks';
import { appName } from '../../../config';
import { AppPage } from '../../layout/AppPage';

export const HomePage = () => {
  const { data: weatherForecast } = useReadWeatherForecast();

  return (
    <AppPage title={appName}>
      <div style={{ marginTop: 24 }}>
        {weatherForecast?.map(w => (
          <li key={w.date.toString()} style={{ marginBottom: 12 }}>{`${w.date} ${w.summary} ${w.temperatureC}`}</li>
        ))}
      </div>
    </AppPage>
  );
};
