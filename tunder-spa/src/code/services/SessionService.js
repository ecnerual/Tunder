import axios from 'axios';
import { API_URL } from '@/Configs.js';

import notifications from "@/store/modules/notifications";


function LoginApi(state, { email, password }) {
  axios.post(`${API_URL}session/register`, {
    email,
    password
  })
  .then(({token}) => token)
  .catch(err => {
    const { types } = notifications; 
    state.commit(`notifications/types.ADD_ERROR`, { msg: "rip" });
  });
}