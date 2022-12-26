import { ChildrenProps } from '../../types';

export const Container = ({ children }: ChildrenProps) => (
  <div
    style={{
      backgroundColor: 'rgb(241, 243, 245)',
      maxWidth: 1200,
      width: '100%',
      display: 'flex',
      flexDirection: 'column'
    }}
  >
    {children}
  </div>
);
