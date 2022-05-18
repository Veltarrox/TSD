
import TodoList from "../pages/TodoList"
import TodoDetails from "../pages/TodoDetails"
import TodoAdd from "../pages/TodoAdd"

import { createRouter, createWebHashHistory } from "vue-router";

const routes = [
    {
        path: '/',
        name: 'mainPage',
        component: TodoList,
        props: true 
      },
      {
        path: '/add',
        name: 'add',
        component: TodoAdd
      },  {
        path: '/details/:id',
        name: 'details',
        component: TodoDetails
      }

  ]

  const router = createRouter({
    history: createWebHashHistory(),
    routes,
  });

  export {router};