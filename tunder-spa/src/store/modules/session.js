import { login } from "@/code/ApiService.js";


const state = {
  token: null
};

const actions = {
  login({ commit }, payload) {
    const { email, password } = payload; 
    const token = loginApi(email, password);

    commit('setToken', token);
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
