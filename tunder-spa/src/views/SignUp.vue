<template>
  <div class="signup__container columns is-centered">
    <form class="column is-half" 
          @submit="onSubmit">
      <div class="field">
        <p class="control has-icons-left has-icons-right">
          <input v-model="email" class="input" type="email" placeholder="Email">
          <span class="icon is-small is-left">
            <i class="fas fa-envelope"></i>
          </span>
          <span class="icon is-small is-right">
            <i class="fas fa-check"></i>
          </span>
        </p>
      </div>
      <div class="field">
        <p class="control has-icons-left has-icons-right">
          <input v-model="password" class="input" type="password" placeholder="Password">
          <span class="icon is-small is-left">
            <i class="fas fa-lock"></i>
          </span>
        </p>
      </div>
      <div class="field is-grouped is-right">
        <div class="control">
          <button :class="{ 'is-loading': submitting }"  class="button is-link">Sign up</button>
        </div>
        <div class="control">
          <button class="button is-text">Cancel</button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>

export default {
  name: 'signUp',
  data() {
    return {
      email: '',
      password: '',
      submitting: false
    }
  },
  methods: {
    onSubmit() {
      const { email, password } = this;
      this.$store.dispatch('session/login', { email, password });
    }
  }
}

</script>

<style lang="scss">

</style>