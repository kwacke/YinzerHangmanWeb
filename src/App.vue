<template>
  <div id="app">
    <user-game/>
  </div>
</template>

<script>
import UserGame from './components/UserGame.vue'

export default {
  name: 'App',
  components: {
    UserGame
  }
}
</script>

<style>
#app {
  font-family: Arial, Helvetica, sans-serif;
  text-align: center;
}
</style>
