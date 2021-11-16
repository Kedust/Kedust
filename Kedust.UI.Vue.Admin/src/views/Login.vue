<template>
  <h1>Login</h1>
  <div class="input-field">
    <input id="password" type="password" v-model="password">
    <label for="password">Password</label>
  </div>
  <button class="btn" @click="login()">Login</button>
</template>

<script>
export default {
  name: "Login",
  data(){
    return{
      password:""
    }
  },
  methods:{
    login(){
      if(this.password === "Lekker")
        localStorage.setItem("loggedIn", "")
      else
        localStorage.removeItem("loggedIn")
    }
  }
}
</script>

<style scoped>

</style>