
import {  createBrowserRouter } from 'react-router-dom'
import {  RouterProvider } from 'react-router'
import IndexElement from './Pages/IndexElement'
import Register from './Pages/Register';
import SingleBlog from './Pages/SingleBlog';
import UploadBlogPage from './Pages/UploadBlogPage';



function App() {
  const router = createBrowserRouter([
    {
      path:"",
      element: <IndexElement />,
    },
    {
      path:"/register",
      element: <Register />
    },
    {
      path:"blog/:slug",
      element: <SingleBlog />
    },
    {
      path:"blog/upload",
      element: <UploadBlogPage />
    } 

  ])

  return <RouterProvider router={router} />;
}
export default App
