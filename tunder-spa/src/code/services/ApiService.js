const axios = require('axios');

const loginApi = (login, password) => {
  axios.post('/api/session/login', {
    login,
    password
  })
  .then(res => {
    console.log(res)
  })
  .then(res => {
    return "token";
  })
  .catch(err => console.error(err));
}

export default {
  loginApi
}