<template>
  <div id="app">
    <Header/>
    <div class="container is-widescreen">
      <router-view/>
    </div>
  </div>
</template>

<script>
import Header from '@/components/layout/Header.vue'

export default {
  name: 'App',
  components: {
    Header
  }
}
  
</script>

<style lang="scss">

.container, #app, .view__container, html, body {
  height: 100%;
}

.button { 
  min-width: 90px;
}
</style>
