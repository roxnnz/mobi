import type { NextPage } from "next";
import Head from "next/head";
import LoginForm from "../components/login-form";

const Home: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Login Page</title>
      </Head>
      <main>
        {/* <div className="columns is-mobile">
          <div className="column">1</div>
          <div className="column">2</div>
          <div className="column">
            
          </div>
          <div className="column">4</div>
        </div> */}

        <div className="columns is-mobile">
          <div className="column is-three-fifths is-offset-one-fifth">
            <LoginForm></LoginForm>
          </div>
        </div>
      </main>
    </div>
  );
};

export default Home;
