import { Container } from './Container';

export const AppMain = ({ children }: any) => (
  <main
    style={{
      backgroundColor: 'rgb(225, 230, 233)',
      flex: 1,
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center'
    }}
  >
    <Container>{children}</Container>
  </main>
);
