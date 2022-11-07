import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './Home';
import Login from "./Login/Login"
import LoginSignUp from './Login/LoginSignUp';
function App() {
  return (
    <div>
      <nav>

      </nav>
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home/>}/>
        <Route path="/login" element={<Login />} />
          <Route path="/Signup" element={<LoginSignUp />} />
      </Routes>
    </BrowserRouter>

  </div>
  );
}

export default App;
