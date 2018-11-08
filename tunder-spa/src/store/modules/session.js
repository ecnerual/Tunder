const axios = require('axios');

const state = {
  token: null
};

const actions = {
  login({ commit }, payload) {
    const { email, password } = payload; 
    axios.post('http://localhost:35396/api/session/login', {
      email,
      password
    })
    .then(res => {
      commit('setToken', res.data.token);
    })
    .catch(err => console.error(err));
  }
};

const getters = {};

const mutations = {
  setToken(state, newToken) {
    state.token = newToken;
  }
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
