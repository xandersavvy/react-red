import { useState } from "react";
import validator from "validator";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const handleSubmit = (e: { preventDefault: () => void }) => {
    e.preventDefault();
    if (validator.isEmail(email) && validator.isStrongPassword(password))
      console.log("action");
    else {
      setError("Information Not correct");
    }
    setEmail("");
    setPassword("");
  };
  return (
    <form className="container" onSubmit={handleSubmit}>
      <h3>Login</h3>
      <label htmlFor="email">
        Enter Email address
        <input
          type="email"
          name="email"
          className="email"
          id="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </label>
      <label htmlFor="">
        Enter Password
        <input
          type="password"
          name="password"
          className="pasword"
          id="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </label>
      <button type="submit">Submit</button>
      <a href="./register" style={{ margin: "10px" }}>
        Register
      </a>
      <p style={{ color: "red" }}>{error}</p>
    </form>
  );
};

export default Login;
