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
          <a href="/" className="navbar-item">
            Home
          </a>
          <a href="/stores" className="navbar-item">
            Stores
          </a>
          <a href="/products" className="navbar-item">
            Products
          </a>
          <a href="/login" className="navbar-item">
            Login
          </a>
        </div>
      </div>
    </nav>
  );
};

export default TopNavBar;
