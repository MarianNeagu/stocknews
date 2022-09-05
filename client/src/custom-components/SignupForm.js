import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import {useState} from 'react';
import '../style/Authentication.css';

function SignupForm() {
  const [email, setEmail] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');


  var jsonData = {
    "email": "",
    "username": "",
    "password": "",
    "roleId": "user"
    }

    async function handleSubmit() {
    jsonData.email = email;
    jsonData.username = username;
    jsonData.password = password;
    // console.log(JSON.stringify(jsonData));
    
    // Send data to the backend via POST
    const response = await fetch('https://localhost:5001/api/Authentication/sign-up/', {  // Enter your IP address here

      method: 'POST', 
      mode: 'cors', 
      body: JSON.stringify(jsonData),
      headers: {
          'Content-Type': 'application/json',
          Accept: 'application/json',
        }
    })


    setEmail("");
    setUsername("");
    setPassword("");
    return response.json();
  }    

  return (
    <div className='container d-flex justify-content-center mt-5'>
        <Form >
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <Form.Label>Email address</Form.Label>
            <Form.Control type="email" placeholder="Enter email" onChange={event => setEmail(event.target.value)} value={email} />
            <Form.Text className="text-muted">
              We'll never share your email with anyone else.
            </Form.Text>
          </Form.Group>

          <Form.Group className="mb-3" controlId="formBasicUsername">
            <Form.Label>User name</Form.Label>
            <Form.Control placeholder="Enter username" onChange={event => setUsername(event.target.value)} value={username} />
          </Form.Group>

          <Form.Group className="mb-3" controlId="formBasicPassword">
            <Form.Label>Password</Form.Label>
            <Form.Control type="password" placeholder="Password" onChange={event => setPassword(event.target.value)} value={password} />
          </Form.Group>
          <Button variant="primary" onClick={handleSubmit}>
            Sign Up
          </Button>
        </Form>
    </div>
    
  );

}
  
export { SignupForm };