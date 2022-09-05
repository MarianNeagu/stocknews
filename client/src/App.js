import './App.css';
import { SignupForm } from './custom-components/SignupForm';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { LoginForm } from './custom-components/LoginForm';
import { NewsPage } from './custom-components/NewsPage';
import { ProfilePage } from './custom-components/ProfilePage';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/sign-up" element={<SignupForm />} />
        <Route path="/login" element={<LoginForm />} />
        {/* <Route path="/news" element={<NewsPage />} /> */}
        <Route path="/profile" element={<ProfilePage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
