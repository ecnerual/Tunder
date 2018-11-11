import store from '@/store/modules/session.js'
import { expect } from 'chai'

describe('@/store/modules/sessions', () => {
  let state;

  describe('Mutations', () => {
    const { mutations, types } = store;

    beforeEach(() => {
      state = store.state;
    });

    it('Set token should set token', () => {
      mutations[types.SET_TOKEN](state, 'madame');
      expect(state.token).to.equal('madame');
    })

    it('Set token should set isAuth', () => {
      mutations[types.SET_TOKEN](state, 'madame');
      expect(state.isAuth).to.equal(true);
    })
  })
});