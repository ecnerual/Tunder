const state = {
  token: null
};

const actions = {};

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
