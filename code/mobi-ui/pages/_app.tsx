import type { AppProps } from 'next/app';
import TopNavBar from '../components/TopNavBar';
import '../styles/globals.sass';

export default function MyApp({ Component, pageProps }: AppProps) {
  return (
    <>
      <TopNavBar />
      <Component {...pageProps} />
    </>
  );
}
