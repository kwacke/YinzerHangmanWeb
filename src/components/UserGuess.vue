<template>
  <div class="user-guess">
    <form @submit.prevent="submitGuess">
      <input type="text" v-model="guess" @keyup.enter="submitGuess" placeholder="Enter a guess, ya jag">
      <button class="button" type="submit">Enter Your Guess!</button>
    </form>
  </div>
</template>

<script>


export default {
  props: ['answer', 'hidden', 'maxIncorrect'],
  data() {
    return {
      guess: '',
      incorrect: 0,
    };
  },
  methods: {
    submitGuess(event) {
      event.preventDefault();
      if (this.guess.trim().toLowerCase() === '') {
        alert('Please enter a guess!');
      } else {
        if (this.isSingleLetterGuess(this.guess)) {
          this.handleSingleLetterGuess(this.guess, this.correctWord); // Pass guess and correctWord as parameters
        } else {
          if (this.isFullwordGuess(this.guess, this.correctWord)) {
            this.handleFullWordGuess(); // No need to pass guess and correctWord here, as it's already available in the component
          }
        }
        
        //this.guess = '';

        return this.$emit('submit-guess', this.guess);
      }
    },
    isSingleLetterGuess(guess) {
      return guess.length === 1;
    },
    isFullwordGuess(guess, answer) {
      return guess.length > 1 || guess.length === answer.length;
    },
    handleFullWordGuess() {
  const guess = this.guess.toLowerCase();
  const answer = this.correctWord.toLowerCase();

  if (guess === answer) {
    // Handle correct guess logic here
    console.log('Correct guess!');
    this.$emit('submit-guess', this.guess);
  } else {
    // Handle incorrect guess logic
    this.incorrect++;
    if (this.incorrect === this.maxIncorrect) {
      console.log('Game over');
      this.askToPlayAgain();
    }
  }
  this.displayGameOutcome();
},
    handleSingleLetterGuess() {
      const guess = this.guess.toLowerCase();
      const answer = this.correctWord.toLowerCase();

      if (answer.includes(guess)) {
        // Update hidden word with correctly guessed letters
        const newHidden = this.hidden.split('').map((char, index) => {
          if (answer[index] === guess) {
            return guess;
          } else {
            return char;
          }
        }).join('');
      
        this.updateHidden(newHidden);
      } else {
        // Handle incorrect guess logic
        this.incorrect++;
        if (this.incorrect === this.maxIncorrect) {
          console.log('Game over');
          this.askToPlayAgain();
        }
      }
      this.displayGameOutcome();

      this.$emit('submit-guess', this.guess);
    },
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
