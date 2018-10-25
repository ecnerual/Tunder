import store from '@/store/modules/session.js'
import { expect } from 'chai'


describe('Describe session mutations', () => {
  const state = {
    token: null
  };

  const { mutations } = store;

  mutations.setToken(state, 'madame');

  it('Set the token', () => {
    expect(state.token).to.equal('madame');
  });
});