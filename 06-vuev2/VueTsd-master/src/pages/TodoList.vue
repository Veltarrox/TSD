<template>
  <div>
    <div class="header">Todo List:</div><br>


    <div v-for="todo in $store.state.todoList"
    :key="todo.id">
    
    <router-link :to= "{name: 'details' , params:{id: todo.id, todo: todo.name}}" class="todoElement">{{todo.name}}</router-link>
    <br><br>
    </div>


  <button @click="$router.push('add')" class="button">Add new task</button>

  </div>
</template>
<script>
import todoList from "../data/todoList.js"
export default {
  data() {
    return {
    todoList: todoList

    };
  },
  mounted(){
    console.log(todoList);
  },
  beforeRouteEnter (to, from, next) {
  next(vm => {
    if(to.params.newTodoName){
      console.log(vm)
    vm.$store.commit("addTodo",to.params.newTodoName)
    }
  })
}
};
</script>
<style>
.button{
  background-color: blue;
  color: azure;
  margin: 1px;
}
.todoElement{
  color: rgb(24, 215, 174);

  border: rgb(94, 15, 89);
  border-style: dotted;

}
.header{
  color: brown;
}

</style>
