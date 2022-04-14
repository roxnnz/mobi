//import { providers, getSession } from 'next-auth/client'

export default function LoginForm() {
  return (
    <>
      <div className="field">
        <p className="control has-icons-left has-icons-right">
          <input className="input" type="email" placeholder="Email" />
          <span className="icon is-small">
            <i className="fas fa-envelope"></i>
          </span>
          <span className="icon is-small is-right">
            <i className="fas fa-check"></i>
          </span>
        </p>
      </div>

      <div className="field">
        <p className="control has-icons-left">
          <input className="input" type="password" placeholder="Password" />
          <span className="icon is-small is-left">
            <i className="fas fa-lock"></i>
          </span>
        </p>
      </div>

      <label className="checkbox mb-2">
        <input type="checkbox" />
        Remember me
      </label>

      <div className="field">
        <p className="control">
          <button className="button is-success mb-2">Login</button>
          <button className="button is-white">Login with Google</button>
          <p className="mb-2">
            New Customer? <a href="">Create account</a>
          </p>

          <a href="" className="mb-2">
            Forgot your password?
          </a>
        </p>
      </div>
    </>
  );
}
