const LoginForm = () => {
  return (
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
            <button className="button is-primary">Login</button>
            <button className="button is-text">Forgot password?</button>
          </div>
        </div>
      </div>
    </section>
  );
};

export default LoginForm;
