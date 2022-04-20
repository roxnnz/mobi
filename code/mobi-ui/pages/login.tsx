import type { NextPage } from 'next';
import Head from 'next/head';
import LoginForm from '../components/LoginForm';

const Login: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Mobi - login</title>
      </Head>
      <main>
        <section className="hero">
          <div className="hero-body">
            <p className="title">Mobi</p>
            <p className="subtitle">Login to your account</p>
            <LoginForm />
          </div>
        </section>
      </main>
    </div>
  );
};

export default Login;
