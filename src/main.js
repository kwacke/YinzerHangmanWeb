import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import {createStore} from './store'

const store = createStore();

const app = createApp(App);
app.use(store);
app.mount('#app');

