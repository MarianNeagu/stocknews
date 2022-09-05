import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import {useState} from 'react';
import '../style/Authentication.css';
import Cookies from 'universal-cookie';

function LoginForm() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');


  var jsonData = {
    "email": "",
    "password": ""
    }

    const cookies = new Cookies();

    

    async function handleSubmit() {
    jsonData.email = email;
    jsonData.password = password;
    // console.log(JSON.stringify(jsonData));
    
    const response = await fetch('https://localhost:5001/api/Authentication/login/', {  

      method: 'POST', 
      mode: 'cors', 
      body: JSON.stringify(jsonData),
      headers: {
          'Content-Type': 'application/json',
          Accept: 'application/json',
        }
    })

    let jwtCookie = await response.json();

    cookies.set('jwt', jwtCookie.token, { path: '/' });
    console.log('Bearer ' + cookies.get('jwt'));

    setEmail("");
    setPassword("");
    return response;
  }    



  return (
    <div className='container d-flex justify-content-center mt-5'>
        <Form >
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <Form.Label>Email address</Form.Label>
            <Form.Control type="email" placeholder="Enter email" onChange={event => setEmail(event.target.value)} value={email} />
          </Form.Group>

          <Form.Group className="mb-3" controlId="formBasicPassword">
            <Form.Label>Password</Form.Label>
            <Form.Control type="password" placeholder="Password" onChange={event => setPassword(event.target.value)} value={password} />
          </Form.Group>
          <Button variant="primary" onClick={handleSubmit} >
            Login
          </Button>
        </Form>
    </div>
    
  );

}
  
export { LoginForm };