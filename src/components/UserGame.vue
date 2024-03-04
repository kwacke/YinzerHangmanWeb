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
      <user-guess @submit-guess="handleGuess" :answer="correctWord" :hidden="hidden" :maxIncorrect="maxIncorrect"/>
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
      maxIncorrect: 5, //Max number of incorrect guesses
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
      this.hidden = this.currentWord.replace(/\w/g, '_').trim();
    },
    handleGuess() {
      // This method will be called by the UserGuess component when a guess is submitted.
    },
    displayGameOutcome() {
      if (this.hidden.includes('_') && this.incorrect === this.maxIncorrect) {
        console.log('Game over, ya Jag!');
        this.askToPlayAgain();
      } else if (!this.hidden.includes('_')) {
        console.log('Yinz win!');
        this.askToPlayAgain();
      }
    },
    askToPlayAgain() {
      const response = prompt("Yinz wanna play again?\nJus' type in Y or Yes if yinz wanna play again, 'n if yinz had enough, type N or No to exit, y'know");
      if (response && (response.toLowerCase() === 'n' || response.toLowerCase() === 'no')) {
        console.log("See Yinz again next time!");
      } else if (response && (response.toLowerCase() === 'y' || response.toLowerCase() === 'yes')) {
        this.resetGameVariables();
      } else {
        this.handleInvalidPlayAgainInput();
      }
    },
    handleInvalidPlayAgainInput() {
      console.log("I'm sorry 'n'at, but could yinz please enter a Y to play again or an N to exit, jagoff");
      this.askToPlayAgain();
    },
    resetGameVariables() {
      this.correctWord = '';
      this.hint = '';
      this.incorrect = 0;
      this.$store.commit("GET_RANDOM_WORD");
      this.currentWord = this.$store.state.word;
      this.hint = this.$store.state.hint;
      this.hideWord();
    },
    updateHidden(newHidden){
      this.hidden = newHidden;
    },
    gameWon(){
      console.log('Congratulations! You won the game!')
      this.resetGameVariables();
      this.askToPlayAgain();
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