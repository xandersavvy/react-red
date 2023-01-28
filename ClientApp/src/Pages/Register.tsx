import { useEffect, useRef, useState } from "react";
import validator from "validator";
import Loading from "../components/Loading";

const changeError = (el: HTMLElement, error: boolean) => {
  el.style.border = error ? "solid red 2px" : "solid black 1px";
};

const RegisterComp = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const nameRef = useRef<HTMLInputElement>(null);
  const emailRef = useRef<HTMLInputElement>(null);
  const passwordRef = useRef<HTMLInputElement>(null);
  const handleSubmit = (e: { preventDefault: () => void }) => {
    changeError(nameRef.current as HTMLElement, false);
    changeError(emailRef.current as HTMLElement, false);
    changeError(passwordRef.current as HTMLElement, false);
    
    e.preventDefault();
    if (name.length < 2 || !validator.isAlpha(name))
      return changeError(nameRef.current as HTMLElement, true);
    if (!validator.isEmail(email))
      return changeError(emailRef.current as HTMLElement, true);
    if (!validator.isStrongPassword(password))
    return changeError(passwordRef.current as HTMLElement, true);
    console.log("submitting");
  };
  return (
    <form onSubmit={handleSubmit} className="container">
      <h3>Register 😁 </h3>
      <label htmlFor="name">
        Enter email
        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          id="email"
          name="email"
          className="email"
          ref={emailRef}
        />
      </label>
      <label htmlFor="">
        Enter Name
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          id="name"
          name="name"
          className="name"
          ref={nameRef}
        />
      </label>
      <label htmlFor="">
        Enter password
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          id="password"
          name="password"
          className="password"
          ref={passwordRef}
        />
      </label>
      <button type="submit">🪶 Register</button>
      <a href="./" style={{ margin: "20px" }}>
        Login
      </a>
    </form>
  );
};

const Register = () => {
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    if (localStorage.getItem("token")) window.location.href = "/";
    setLoading(false);
  }, []);

  return <>{loading ? <Loading /> : <RegisterComp />}</>;
};

export default Register;
