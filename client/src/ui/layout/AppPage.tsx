import { ReactNode } from 'react';

import { ChildrenProps } from '../../types';
import { Container } from './Container';

interface Props extends ChildrenProps {
  title: string;
  description?: string;
  actionsSlot?: ReactNode;
}

export const AppPage = ({ title, description, children }: Props) => (
  <Container>
    <article>
      <>
        <div style={{ display: 'block' }}>
          <div style={{ display: 'inline-block', marginTop: 4, marginLeft: 4, marginRight: 4, width: '100%' }}>
            <h1 style={{ fontSize: 70, fontWeight: 500 }}>{title}</h1>
            {!!description && <p style={{ fontSize: 20, fontWeight: 400 }}>{description}</p>}
          </div>
        </div>

        {!!children && <div style={{ display: 'block', marginTop: 1 }}>{children}</div>}
      </>
    </article>
  </Container>
);
