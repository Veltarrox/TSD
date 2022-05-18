<template>
  <div>
    <form>
      <input v-model="todo.name" placeholder="Task's name" /><br><br>
      <button @click="validate" class="button">Add Task To Do</button>
    </form>
    <button @click="goBack" class="button">Back to List</button>
    <br>
    <br>
    <div v-show="!valid" class="validation">Task must have a name!</div>
  </div>
  
</template>
<script>
export default {
  data() {
    return {
      todo: {
        name: null,
      },
      valid: true,
    };
  },
  methods: {
    validate() {
      this.valid = true;
      if (this.todo.name != null) {
        this.$router.push({name:'mainPage', params:{newTodoName: this.todo.name}})
      } else {
        this.valid = false;
        setTimeout(() => {
          this.valid = true;
        }, 5000);
      }
    },
          goBack(){
          this.$router.push({name:'mainPage'})
      }
  },
};
</script>
<style scoped>
.button{
  background-color: rgb(229, 255, 0);
  color: rgb(0, 0, 0);
  margin: 1px;
}
.validation{
  color: red;
}
</style>