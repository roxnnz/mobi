import type { NextPage } from 'next';
import Head from 'next/head';
import LoginForm from '../components/LoginForm';

const Home: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Mobi</title>
      </Head>
      <main>
        <section className="hero">
          <div className="hero-body">
            <p className="title">Mobi</p>
            <p className="subtitle">Your local stores</p>
          </div>
        </section>
      </main>
    </div>
  );
};

export default Home;
