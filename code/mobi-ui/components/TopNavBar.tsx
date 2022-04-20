import type { NextPage } from "next";

const TopNavBar: NextPage = () => {
  return (
    <nav className="navbar" role="navigation" aria-label="main navigation">
      <div className="navbar-brand">
        <a className="navbar-item" href="https://bulma.io">
          <img
            src="https://bulma.io/images/bulma-logo.png"
            alt="Mobi online store SaaS"
            width="112"
            height="28"
          />
        </a>

        <a
          role="button"
          className="navbar-burger"
          aria-label="menu"
          aria-expanded="false"
        >
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
        </a>
      </div>
      <div id="navbarBasicExample" className="navbar-menu">
        <div className="navbar-start">
          <a href="http://localhost:3000/" className="navbar-item">
            Home
          </a>
          <a href="http://localhost:3000/contact" className="navbar-item">
            Contact us
          </a>
          <a href="http://localhost:3000/login" className="navbar-item">
            Login
          </a>
        </div>
      </div>
    </nav>
  );
};

export default TopNavBar;
