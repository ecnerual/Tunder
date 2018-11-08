<template>
  <nav class="navbar is-widescreen is-light" role="navigation" aria-label="main navigation">

    <div class="navbar-brand">
      <router-link class="navbar-item" to="/">Logo</router-link>

      <a @click="toggleBurgerActive"
         :class="{'is-active': burgerActive}"
         role="button" 
         class="navbar-burger" 
         aria-label="menu"
         aria-expanded="false">
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
      </a>
    </div>

    <div class="navbar-menu"
         :class="{'is-active': burgerActive}">
      <div class="navbar-start">
        <router-link v-for="(link, i) in menuLinks" 
                     @click="toggleBurgerActive"
                     class="navbar-item" 
                     :key='i'
                     :to="link.to">{{ link.label }}</router-link>
      </div>

      <div class="navbar-end">
        <div class="navbar-item">
          <div class="buttons">
            <router-link class="button is-primary" to="/signup">Sign up</router-link>
            <router-link class="button is-light" to="/login">Login</router-link>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>

const menuLinks = [
  {
    to: '/',
    label: 'Home'
  }
];

export default {
  name: 'Header',
  data() {
    return { 
      burgerActive: false
    }
  },
  beforeCreate() {
    this.menuLinks = menuLinks;
  },
  methods: {
    toggleBurgerActive() {
      this.burgerActive = !this.burgerActive;
    }
  }
}
  
</script>


<style lang="scss">

.navbar {
  padding: 0px calc((100vw - 1152px) /2);
  @media screen and (min-width: 1280px) {
    padding: 0px calc((100vw - 1152px) /2);
  }
}
  
</style>