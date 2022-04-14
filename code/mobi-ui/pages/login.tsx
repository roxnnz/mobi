import type { NextPage } from "next";
import Head from "next/head";
import LoginForm from "../components/LoginForm";

const Home: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Login Page</title>
      </Head>
      <main>
        <section className="section is-medium">
          <div className="columns is-mobile is-centered">
            <div className="column is-half">
              <div className="content">
                <h1>Login</h1>
              </div>
              <LoginForm></LoginForm>
            </div>
          </div>
        </section>
      </main>
    </div>
  );
};

export default Home;
