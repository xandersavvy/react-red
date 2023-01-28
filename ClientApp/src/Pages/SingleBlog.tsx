import { useParams } from "react-router-dom";

 const SingleBlog = ({}) => {
    let {slug} = useParams();
    let post ;
    return <h1>Hello {slug}</h1>
}


export default SingleBlog;