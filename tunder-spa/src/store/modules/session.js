const axios = require('axios');

export const LOGIN = 'ACTON_LOGIN';

export const SET_TOKEN = 'SET_TOKEN';

const types = {
  SET_TOKEN,
  LOGIN
}

const state = {
  token: null,
  isAuth: false
};

const actions = {
  [LOGIN]({ commit }, payload) {
    const { email, password } = payload; 
    axios.post('http://localhost:35396/api/session/login', {
      email,
      password
    })
    .then(res => {
      commit(types.SET_TOKEN, res.data.token);
    })
    .catch(err => console.error(err));
  }
};

const getters = {};

const mutations = {
  [SET_TOKEN](state, newToken) {
    state.token = newToken;
    state.isAuth = true;
  }
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
  types
};
