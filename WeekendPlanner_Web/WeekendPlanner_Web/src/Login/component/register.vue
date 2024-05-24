<template>
    <h2>Register:</h2>
    <form @submit.prevent="addUser">
        <p>Username: <input type="text" required v-model="userName"></input></p>
        <p>E-Mail: <input type="email" required v-model="userEmail"></input></p>
        <p>Password: <input type="password" required v-model="userPassword"></p>
        <button type="submit">registrieren</button>
    </form>
</template>

<script>
import axios from 'axios'

export default{
    data(){
        return{
            userName:null,
            userEmail:null,
            userPassword:null
        }
    },
    methods:{
        async addUser(){
            await axios.post("https://localhost:7002/api/user", {
                name: this.userName,
                email: this.userEmail,
                password: this.userPassword
            })
            .then(function(response){
                console.log(response)
            })
            .catch(function(error){
                console.log(error)
            });

            this.reset();
        },
        reset(){
            this.userName=null
            this.userEmail=null
            this.userPassword=null
        }
    }
}
</script>

<style>

</style>