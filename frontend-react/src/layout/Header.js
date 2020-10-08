import React from "react";
import { Nav, Navbar } from "react-bootstrap";
import { Link } from "react-router-dom";

export default function Header() {
  return (
    <Navbar expand="lg">
      <Navbar.Brand>
        <Link to="/">
          <img
            src="/logo192.png"
            width="30"
            height="30"
            className="d-inline-block align-top"
            alt="Home"
          />
        </Link>
      </Navbar.Brand>
      <Nav className="mr-auto">
        <Nav.Item>
          <Link to="/arvore" className="nav-link">
            Àrvore
          </Link>
        </Nav.Item>
        <Nav.Item>
          <Link to="/link-2" className="nav-link">
            Colheita
          </Link>
        </Nav.Item>
      </Nav>
    </Navbar>
  );
}
