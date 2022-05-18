import { createApp } from 'vue'
import App from './App.vue'
import { createStore } from 'vuex'

import {router} from "./router/index"

const store = createStore({
    state () {
      return {
        todoList: [{
            id:0,
            name: "First Thing",
          },
          {
            id: 1,
            name: "Second Thing",
          }]
      }
    },
    mutations: {
      addTodo (state, todo) {
        state.todoList.push({id: state.todoList.length, name: todo})
        console.log(state.todoList)
      }
    }
  })

createApp(App).use(router).use(store).mount('#app')
