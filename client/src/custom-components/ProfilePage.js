import {useState} from 'react';
import '../style/Authentication.css';
import Cookies from 'universal-cookie';
import jwt_decode from "jwt-decode";

function ProfilePage() {

    const cookies = new Cookies();
    var decodedJwt = jwt_decode(cookies.get('jwt'));

    let username = decodedJwt.username;

    return (
        <span>Hello, {username}</span>
    );
    

}
  
export { ProfilePage };