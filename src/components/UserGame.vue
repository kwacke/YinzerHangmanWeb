<template>
  <div class="container">
    <div class="img">
      <img class="hangmanImage" :src="img" alt="Hangman Image">
    </div>
    <div class="clue">
      <div>
        <p class="hidden" style="letter-spacing: 5px;">{{ hidden }}</p>
        <br><br>
        <p class="hint">Hint: {{ hint }}</p>
      </div>
      <user-guess />
    </div>
  </div>
</template>

<script>
import UserGuess from '../components/UserGuess.vue';

export default {
  components: {
    UserGuess
  },
  data() {
    return {
      correctWord: '',
      hint: '',
      img: './YinzerHangman.jpg',
      hidden: '',
      incorrect: 0,
      guess: ''
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
    },
    submitGuess() {
      if (this.guess.trim().toLowerCase() === '') {
        alert('Please enter a guess!');
        return;
      }
    },
    displayGameOutcome() {
      if (this.hidden.includes('_') && this.incorrect == 5 || this.hidden != this.user.answer) {
        console.log('Game over, ya Jag!')
      }
    },
    askToPlayAgain() {
      const response = prompt("Yinz wanna play again?\nJus' type in Y or Yes if yinz wanna play again, 'n if yinz had enough, type N or No to exit, y'know");
      if (response && (response.toLowerCase() == 'n') || response.toLowerCase() == 'no') {
        console.log("See Yinz again next time!")
      }
      else if (response && (response.toLowerCase() == 'y') || response.toLowerCase() == 'yes') {
        //handle if yes
      } else {
        console.log("I'm sorry 'n'at, but could yinz please enter a Y to play again or an N to exit, jagoff")
        this.askToPlayAgain();
      }
    },
    handleInvalidPlayAgainInput() {
      console.log("I'm sorry 'n'at, but could yinz please enter a Y to play again or an N to exit, jagoff")
      this.askToPlayAgain();
    },
    resetGameVariables() {
      this.user.correct = 0;
      this.user.incorrect = 0;
      this.user.hasLetter = false;
      this.user.answer = "";
      this.user.userGuess = "";
    }
  }
};

</script>
<style>
.container {
  display: flex;
  overflow: hidden;
}

.img {
  flex: 1;
  margin: 2rem;
  margin-right: 20px;
  /* Added some space between image and clue */
  height: 70vh;
  padding: 10px;
}

.hangmanImage {
  height: 75vh;
}

.clue {
  flex: 2px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: flex-start;
  padding-top: 2px;
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  font-size: large;
}

.hint {
  padding-left: 25px;
}
</style>