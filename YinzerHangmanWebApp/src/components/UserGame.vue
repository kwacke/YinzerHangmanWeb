<template>
  <div>
    <h1>{{ correctWord }}</h1>
  </div>
</template>
<script>
export default {
  data(){
    return {
      correctWord:'',
    }
  },
  created(){
Object.keys(this.correctWord) = this.$store.commit("GET_RANDOM_WORD")
Object.value(this.correctWord) = this.$store.commit("GET_RANDOM_WORD")

  }
}
</script>
<style></style>