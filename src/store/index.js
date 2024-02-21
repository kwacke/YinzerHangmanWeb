import { createStore as _createStore } from 'vuex';

export function createStore() {
    return _createStore({
        state: {
            wordDictionary: { "Yinz": "Pittsburghese pronoun",
            "Clahdy": "Weather-related term",
            "Jagoff": "Pittsburgh insult",
            "Dahntahn": "Downtown",
            "Grahnd bees": "Yellow jacket bees in the ground",
            "Rahn-da-baht": "Song by the group yes or slang for a long way of getting to your destination",
            "Slippy": "Icy",
            "Gumband": "Rubber band",
            "Seent": "Seen it",
            "Cousint": "Cousin",
            "Friggin": "Vulgar slang",
            "Crick": "Small stream or creek",
            "Irn": "Short for Iron City Beer",
            "Worsh": "Wash",
            "Sweeper":"Vacuum cleaner",
            "Spickett": "Outdoor water faucet",
            "Prolly": "Probably",
            "Zak same": "Exactly the same",
            "Lahsy": "Lousy",
            "Jagger bush": "Thorny bush or plant",
            "Up air": "Up there",
            "Da-Boat-a-ya": "The both of you",
            "Nebby": "Nosy",
            "N'at": "And that",
            "Gutchies":"Underwear",
            "Buggy": "Shopping cart",
            "Jumbo": "Bologna",
            "Chipped-Chopped ham": "Isaly's was famous for this!",
            "Red Up": "Clean up",
            "Jeet Jet?": "Did you eat yet?",
            "Dippy Eggs": "Sunny-side-up eggs",
            "Pop": "Soda",
            "Canipshun": "Conniption",
            "Sammitches": "Sandwiches",
            "Ahnno-dat": "I don't know that",
            "A whole nother": "A whole other",
            "Airyago": "There you go",
            "Apost tu":"Supposed too",
            "Back'air": "Back there",
            "Bo fuss": "Both of us",
            "Bowchyins": "Both of you",
            "Buy Sam a drink and get his dog one too!": "Mike Lang Slang",
            "Can a corn": "Easy catch in baseball",
            "Choobinuptoo": "What have you been up to?",
            "Cole-daht-dare": "It's cold outside",
            "Come mere": "Come here",
            "Dahn nair": "Down there",
            "Daht'et": "That it",
            "Don't go err wit me": "Don't argue with me",
            "Dooder Jobs": "Do their jobs",
            "Elvis has left the building": "The show is over",
            "Hafta": "Have to",
            "Hauscome": "How has it come",
            "Hay Bir Here": "Hey beer here",
            "How's come?": "Why is that?",
            "Ize": "I am",
            "Ja Wanna": "Do you want to",
            "Jano?": "Do you know?",
            "Jeez-o-man": "Expression of surprise",
            "Kennywood's Open": "The zipper on your pants is open",
            "Lassnite": "Last night",
            "Like iss": "Like this",
            "Like 'at": "Like that",
            "Nuh-uh!!": "No",
            "Oh call Arnold Slick from Turtle Crick!": "Expression of surprise",
            "Oh mah gersh!": "Oh my gosh!",
            "Ovaderr": "Over there",
            "Same difference": "No difference",
            "Scratch my back with a hacksaw!": "Mike Lang Slang",
            "Sick'n tard": "Sick and tired",
            "Sposda": "Supposed to",
            "bungals": "Slang for Cincinatti's football team",
            "brahns": "Slang for Cleveland's NFL team" ,
            "Ya Gatta Regatta!": "You have to attend the regatta",
            "Renegade": "Unofficial Pittsburgh Steelers anthem" 
        },           
            word: '',
            guesses: [],
            incorrectGuesses: 0,
            maxIncorrectGuesses: 5,
            gameOver: false
        },
        mutations: {
            GET_RANDOM_WORD(state) {
                const entries = Object.entries(state.wordDictionary);
                const randomIndex = Math.floor(Math.random() * entries.length);
                const selectedEntry = entries[randomIndex];
                return selectedEntry[0]; // Return the key (the word)
            },
            ADD_GUESS(state, guess) {
                state.guesses.push(guess);
            },
            INCREMENT_INCORRECT_GUESSES(state) {
                state.incorrectGuesses++;
                if (state.incorrectGuesses >= state.maxIncorrectGuesses) {
                    state.gameOver = true;
                }
            },
            RESET_GAME(state) {
                state.word = '';
                state.guesses = [];
                state.incorrectGuesses = 0;
                state.gameOver = false;
            }
        },
        strict: true
    })
}
