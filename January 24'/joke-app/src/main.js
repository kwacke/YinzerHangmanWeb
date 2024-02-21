import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import {createStore} from './store';
// create a const to run the createStore function
const store = createStore();

// create a const to create the App
const app = createApp(App); //this is where vue injects our app.vue in our index.html
// add the store to the app
app.use(store);
// mount the app means load it into my DOM, have it be displayed. There's more to it than that
app.mount('#app');