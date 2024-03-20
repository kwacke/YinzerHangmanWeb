<template>
  <div id="app">
    <nav class="navbar">
      <ul>
        <li><router-link to="/"><button class="btn">Home</button></router-link></li>
        <li><router-link to="/about"><button class="btn">About</button></router-link></li>
        <li><router-link to="/contact"><button class="btn">Contact</button></router-link></li>
      </ul>
    </nav>
    <div>
      <user-game :correctWord="correctWord" :hidden="hidden" :maxIncorrect="maxIncorrect" />
      
    </div>
  </div>
</template>

<script>
import UserGame from './components/UserGame.vue';

export default {
  name: 'App',
  components: {
    UserGame,
  }
};
</script>

<style>
#app {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  background: linear-gradient(white, gold);
}

.navbar {
  background-color: black;
  color: gold;
  width: 100vw;
  font-family: fantasy;
  margin-left: 2px;
  margin-right: 2px;
}

.navbar ul {
  list-style-type: none;
  padding: 0;
  margin: 0;
  display: flex;
  justify-content: left;
}

.navbar ul li {
  margin: 0 10px;
}

.navbar ul li a {
  color: white;
  text-decoration: none;
}

.btn {
  padding-top: 1px;
  padding-bottom: 1px;
  color: gold;
  background: linear-gradient(grey, black);
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  cursor: pointer;
}

.btn:hover {
  background: white;
  /* Change background color on hover */
}
</style>
