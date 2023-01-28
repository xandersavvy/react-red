
import {  createBrowserRouter } from 'react-router-dom'
import {  RouterProvider } from 'react-router'
import IndexElement from './Pages/IndexElement'
import Register from './Pages/Register';



function App() {
  const router = createBrowserRouter([
    {
      path:"",
      element: <IndexElement />,
    },
    {
      path:"/register",
      element: <Register />
    }

  ])

  return <RouterProvider router={router} />;
}
export default App
