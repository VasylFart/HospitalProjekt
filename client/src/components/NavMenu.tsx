import { Component } from 'react';
import { Link } from 'react-router-dom';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';

import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props: any) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">
              V_Project.Server
            </NavbarBrand>
            <NavbarToggler className="mr-2" onClick={this.toggleNavbar} />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink className="text-dark" tag={Link} to="/">
                    Home
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="text-dark" tag={Link} to="/counter">
                    Counter
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink className="text-dark" tag={Link} to="/fetch-data">
                    Fetch data
                  </NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
