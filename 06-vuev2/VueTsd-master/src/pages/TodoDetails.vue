<template>
  <div>
      details: <br><br>
      name:  
    <strong>{{$route.params.todo}}</strong>
    <br>
    todo_id: <strong>{{$route.params.id}}</strong>
    <br><br>
    <button @click="goBack" class="button">Back to List</button>
  </div>
</template>
<script>
export default {
    props: ["todo"],
  data() {
    return {
     
    };
  },
  methods:{
      goBack(){
          this.$router.push({name:'mainPage'})
      }
  }
};
</script>
<style scoped>
.button{
  background: green;
  color: white;
}
</style>