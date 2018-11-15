import axios from 'axios';
import { API_URL } from '@/Configs.js';


function LoginApi(email, password) {
  axios.post(`${API_URL}session/register`, {
    email,
    password
  })
  .then(({token}) => token)
  .catch(err => console.log(err));
}