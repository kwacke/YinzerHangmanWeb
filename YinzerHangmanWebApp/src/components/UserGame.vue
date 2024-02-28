<template>
  <div>
    <p>{{ hidden }} </p>
    <p>{{ hint }}</p>
    <p>  <img :src="imgURL"></p>
  </div>
</template>

<script>
export default {
  data() {
    return {
      correctWord: '',
      hint: '',
      imgURL: './YinzerHangman.jpg'
    };
  },
  created() {
    this.$store.commit("GET_RANDOM_WORD");
    this.currentWord = this.$store.state.word;
    this.hint = this.$store.state.hint;
  // Initialize hidden with underscores
  this.hideWord();
  },
  methods: {
    hideWord() {
      // Mask the characters of the currentWord with underscores
      this.hidden = this.currentWord.replace(/\w/g, '_ ').trim();
    }
  }
};
</script>
