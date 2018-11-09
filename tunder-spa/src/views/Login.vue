<template>
  <div class="view__container login__container">
    <div class="box is-half">
      <form  @submit="onSubmit">
        <div class="field">
          <p class="control has-icons-left has-icons-right">
            <input v-model="form.email" 
                   v-validate="'required|email'" 
                   class="input" 
                   type="text" 
                   name="email"
                   placeholder="Email"
                   :class="{ 'is-danger': errors.has('email'), 'is-success': fields.email && fields.email.valid }">
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
            <input v-model="form.password" class="input" type="password" placeholder="Password">
            <span class="icon is-small is-left">
              <i class="fas fa-lock"></i>
            </span>
          </p>
        </div>
        <div class="field is-grouped login__btn-group">
          <div class="control is-right">
            <button :class="{ 'is-loading': submitting }"  class="button is-primary">Login</button>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>

export default {
  name: 'signUp',
  data: () => ({
    form: {
      email: '',
      password: ''
    },
    submitting: false
  }),
  methods: {
    onSubmit() {
      const { email, password } = this;

      this.$store.dispatch('session/login', { 
        email, password 
      });
    }
  }
}

</script>

<style lang="scss">

.field.is-grouped.login__btn-group {
  justify-content: flex-end;

}

.login__container {
  display: flex;
  align-items: center;
  justify-content: center;

  .is-half {
    transform: translatey(-26px);
    height: 250px;
    width: 50%;
    display: flex;
    align-items: center;
    justify-content: center;

    @media screen and (max-width: 1024px) {
      width: 88%;
    }

    form {
      width: 86%;
      @media screen and (max-width: 1024px) {
        width: 94%;
      }
    }
  }
}

</style>