<template>
  <div id="app">
    <nav class="navbar">
      <ul>
        <li><router-link to="/">Home</router-link></li>
        <li><router-link to="/about">About</router-link></li>
        <li><router-link to="/contact">Contact</router-link></li>
      </ul>
    </nav>
    <user-game />
  </div>
</template>

<script>
import UserGame from './components/UserGame.vue';

export default {
  name: 'App',
  components: {
    UserGame
  }
};
</script>

<style>
#app {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.navbar {
  background-color: black;
  color: gold;
  width: 100vh;
}

.navbar ul {
  list-style-type: none;
  padding: 0;
  margin: 0;
  display: flex;
  justify-content: center;
}

.navbar ul li {
  margin: 0 10px;
}

.navbar ul li a {
  color: white;
  text-decoration: none;
}
</style>
