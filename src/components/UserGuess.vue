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
  props: ['answer', 'hidden', 'maxIncorrect'],
  data() {
    return {
      guess: '',
      incorrect: 0,
    };
  },
  methods: {
    submitGuess() {
      if (this.guess.trim().toLowerCase() === '') {
        alert('Please enter a guess!');
      } else {
        if (this.isSingleLetterGuess(this.guess)) {
          this.handleSingleLetterGuess();
        } else {
          if (this.isFullwordGuess(this.guess, this.answer)) {
            this.handleFullWordGuess();
          }
        }
        return this.guess;
      }
    },
    isSingleLetterGuess(guess) {
      return guess.length === 1;
    },
    isFullwordGuess(guess, answer) {
      return guess.length > 1 || guess.length === answer.length;
    },
    handleFullWordGuess() {
      if (this.guess.toLowerCase() === this.answer.toLowerCase()) {
        console.log('Yinz won the game!');
        this.$emit('gameWon');
      } else {
        console.log("I'm sorry, that was an incorrect guess!");
        this.incorrect++;
        if (this.incorrect === this.maxIncorrect) {
          console.log('Game Over');
          this.$emit('gameOver');
        }
      }
    },
    handleSingleLetterGuess(guess, answer) {
      guess = this.guess.toLowerCase();
      answer = this.answer.toLowerCase();

      console.log('Guess',guess)
      console.log('Answer', answer)
      console.log('Hidden', this.Hidden)

      if (!answer.includes(guess)) {
        // Handle incorrect guess logic
        this.incorrect++;
        if (this.incorrect === this.maxIncorrect) {
          console.log('Game over');
          this.$emit('gameOver');
        }
      } else {
        // Update hidden word with correctly guessed letters
        const newHidden = this.answer.split('').map((char, index) => {
          if (char.toLowerCase() === guess.toLowerCase()) {
            return char;
          } else {
            return this.hidden[index];
          }
        }).join('');

        this.$emit('updateHidden', newHidden);

        if (!newHidden.includes('_')) {
          console.log('Yinz win!');
          this.$emit('gameWon');
        }
      }
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
