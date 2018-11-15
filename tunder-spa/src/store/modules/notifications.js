const ADD_ERROR = 'ADD_ERROR';
const ADD_SUCCESS = 'ADD_SUCCESS';
const REMOVE_NOTIFICATION = 'REMOVE_NOTIFICATION';

const NOTIFICATION_TYPES = {
  error: 'error',
  success: 'success'
};

const types = {
  ADD_ERROR,
  ADD_SUCCESS,
  REMOVE_NOTIFICATION
};

const state = {
  notifications: [],
  notificationCount: 0
};

const mutations = {
  [REMOVE_NOTIFICATION](id) {
    this.state.notifications = this.state.notifications.filter(n => n.id !== id);
  },
  [ADD_SUCCESS](state, payload) {
    const { msg } = payload;

    this.notifications.add({
      id: this.state.notificationCount++,
      msg,
      type: NOTIFICATION_TYPES.success
    })
  },
  [ADD_ERROR](state, payload) {
    const { msg } = payload;

    this.notifications.add({
      id: this.state.notificationCount++,
      msg,
      type: NOTIFICATION_TYPES.error
    })
  }
};

const getters = {};

const actions = {};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  types,
  getters,
  NOTIFICATION_TYPES
};
