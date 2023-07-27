import {Routes, Route, Navigate, BrowserRouter} from 'react-router-dom'
import CreateUserPage from '../pages/CreateUserPage'
import HomePage from '../pages/HomePage'
import EditUserPage from '../pages/EditUserPage'

export const AppRoutes: React.FC = () => {

    return(
        <BrowserRouter>
        <Routes>
            <Route path='/' element={<HomePage />} />
            <Route path='/create' element={<CreateUserPage />} />
            <Route path='/edit/:id' element={<EditUserPage />} />
            <Route path='*' element={<Navigate to='/'/>} /> 
        </Routes>
        </BrowserRouter>
    )
}