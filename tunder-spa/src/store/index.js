import Vue from 'vue'
import Vuex from 'vuex'
import session from './modules/session';
import notifications from './modules/notifications';
Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  modules: {
    session,
    notifications
  },
  strict: debug
});