import { ReactNode } from 'react';

import { ChildrenProps } from '../../types';
import { Container } from './Container';

interface Props extends ChildrenProps {
  title: string;
  description?: string;
  actionsSlot?: ReactNode;
}

export const AppPage = ({ title, description, actionsSlot, children }: Props) => (
  <Container>
    <article>
      <>
        <div>
          <div>
            <h1>{title}</h1>
            {!!description && (
              <p>
                {description}
              </p>
            )}
          </div>
        </div>

        {!!children && (
          <div>
            {children}
          </div>
        )}
      </>
    </article>
  </Container>
);
