<template>
  <div class="notification">
    <button class="delete"></button>
    {{ msg }}
  </div>
</template>

<script>
  export default {
    props: {
      msg: String
    }
    
  }
</script>

<style lang="scss" scoped>

</style>