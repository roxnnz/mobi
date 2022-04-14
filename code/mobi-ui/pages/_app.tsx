import type { AppProps } from 'next/app';
import TopNavBar from '../components/TopNavBar';
import '../styles/globals.sass';

export default function MyApp({ Component, pageProps }: AppProps) {
  return (
    <div className="container is-fluid">
      <TopNavBar />
      <Component {...pageProps} />
    </div>
  );
}
