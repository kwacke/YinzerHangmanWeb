import {createStore as _createStore} from 'vuex';

export function createStore(){
    return _createStore({
        state: {
            word: 'hello'
        },
        mutations: {

        },
        strict: true //forces you to modify any data in the state
    })
}