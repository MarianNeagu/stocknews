import Cookies from 'universal-cookie';
import {useState} from 'react';

function NewsPage() {


    const cookies = new Cookies();

    let newsJSON;

    async function getNews() {

    
    const response = await fetch('https://localhost:5001/NewsController/', {  

        method: 'GET', 
        mode: 'cors', 
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': cookies.get('jwt')
        },
        
        
        
    });

    newsJSON = await response.json();
    return response;
  }    



  return (
    <>
        {newsJSON}
    </>
    
  );

}
  
export { NewsPage };