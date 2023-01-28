import { useEffect, useState } from "react";
import Loading from "../components/Loading";
import BlogIndex from "../Layouts/BlogIndex";
import Login from "../Layouts/LogIn";

const IndexElement=()=>{
    const [loading, setLoading] = useState(true);
    const [loggedIn, setLoggedIn] = useState(false)
    useEffect(() => {
        if(localStorage.getItem("token")) setLoggedIn(true);
        setLoading(false);
    }, [])
    
    if(loading) return <Loading />;
    else if(loggedIn) return <BlogIndex />

    return <Login />
}

export default IndexElement;