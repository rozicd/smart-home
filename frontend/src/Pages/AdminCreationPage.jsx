import React from 'react';
import RegisterComponent from '../Components/BasicComponents/RegisterComponent';
import './register-page.css'
const AdminCreationPage = () => {

    return (
        <div className='register-page'>
            <RegisterComponent headerName='Create admin'></RegisterComponent>
        </div>
        
    )
}

export default AdminCreationPage;