import type { NextPage } from "next";
import Head from "next/head";
import Contact from "../components/ContactUs";

const Home: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Contact us</title>
      </Head>
      <main>
        <section className="section is-medium">
          <div className="columns is-mobile is-centered">
            <div className="column is-half">
              <div className="content">
                <h1>Contact us</h1>
              </div>
              <Contact></Contact>
            </div>
          </div>
        </section>
      </main>
    </div>
  );
};

export default Home;
