import type { NextPage } from 'next';
import Head from 'next/head';

const LoginWithGoogleButton = () => {
  return (
    <div id="gSignInWrapper">
      <div id="customBtn" className="customGPlusSignIn">
        <span className="icon"></span>
        <span onClick={() => console.log('here')} className="buttonText">Google</span>
      </div>
      <style jsx>{`
        #customBtn {
          display: inline-block;
          background: white;
          color: #444;
          width: 190px;
          border-radius: 5px;
          border: thin solid #888;
          box-shadow: 1px 1px 1px grey;
          white-space: nowrap;
        }
        #customBtn:hover {
          cursor: pointer;
        }
        span.label {
          font-family: serif;
          font-weight: normal;
        }
        span.icon {
          background: url('/g-normal.png') transparent 5px 50% no-repeat;
          display: inline-block;
          vertical-align: middle;
          width: 42px;
          height: 42px;
        }
        span.buttonText {
          display: inline-block;
          vertical-align: middle;
          padding-left: 42px;
          padding-right: 42px;
          font-size: 14px;
          font-weight: bold;
          /* Use the Roboto font that is loaded in the <head> */
          font-family: 'Roboto', sans-serif;
        }
      `}</style>
    </div>
  )
}

const Login: NextPage = () => {
  return (
    <div>
      <Head>
        <title>Mobi - login</title>
        <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet" type="text/css"></link>
      </Head>
      <main>
        <section className="hero">
          <div className="hero-body">
            <p className="title">Mobi</p>
            <p className="subtitle">Login to your account</p>
            <section>
              <div className="columns">
                <div className="column is-4">
                  <div className="field">
                    <p className="control has-icons-left has-icons-right">
                      <input className="input" type="email" placeholder="Email" />
                    </p>
                  </div>
                  <div className="field">
                    <p className="control has-icons-left">
                      <input className="input" type="password" placeholder="Password" />
                    </p>
                  </div>

                  <div className="buttons">
                    <LoginWithGoogleButton />
                  </div>
                  <div className="buttons">
                    <button className="button is-primary">Login</button>
                    <button className="button is-text">Forgot password?</button>
                  </div>
                </div>
                <div id="name"></div>
              </div>
            </section>
          </div>
        </section>
      </main>
    </div>
  );
};

export default Login;
