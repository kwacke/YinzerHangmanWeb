<template>
    <div class="user-guess">
      <form @submit.prevent="submitGuess">
        <input type="text" v-model="guess" placeholder="Enter a guess, ya jag">
        <button class="button" type="submit">Enter Your Guess!</button>
      </form>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        guess: '',
        incorrect: '',
      };
    },
    methods: {
      submitGuess() {
        if (this.guess.trim().toLower() === '') {
          alert('Please enter a guess!');
        } else {
          console.log('User guessed:', this.guess);
          this.guess = '';
        }
      }
    }
  };
  </script>
  
  <style>
  .user-guess {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    margin-left: 20px; 
  }
  
  .user-guess form {
    margin-top: 10px;
  }
  
  </style>
  