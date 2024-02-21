<template>
  <div>
<h1>{{ joke }}</h1>
  </div>
</template>

<script>
import jokeService from '../services/jokeService'
export default {
  data() {
    return {
      joke: ''
    }
  },
  created() {
    jokeService.getRandomJoke()
      .then((response) => {
        console.log(response);
        this.joke = response.data;
      })
  }
}

</script>

