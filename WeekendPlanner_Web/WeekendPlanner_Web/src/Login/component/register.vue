<template>
    <h2>Register:</h2>
    <form v-if="!check" @submit.prevent="addUser">
        <p>Firstname: <input type="text" required v-model="userFirstname"></input></p>
        <p>Lastname: <input type="text" required v-model="userLastname"></input></p>
        <p>Username: <input type="text" required v-model="userName"></input></p>
        <p>E-Mail: <input type="email" required v-model="userEmail"></input></p>
        <p>Password: <input type="password" required v-model="userPassword"></p>
        <button type="submit">registrieren</button>
    </form>
    <p v-if="check">Ein Account mit dieser Email existiert bereits!</p>
</template>

<script>
import axios from 'axios'

export default{
    data(){
        return{
            userFirstname:null,
            userLastname:null,
            userName:null,
            userEmail:null,
            userPassword:null,
            check:false
        }
    },
    methods:{
        async addUser(){
            if(!await axios.get("https://localhost:7002/api/user/checkUser", {
                params:{
                    email:this.userEmail  
                }
            })){
                await axios.post("https://localhost:7002/api/user/createUser", {
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

            }else{
                this.check=true;
            }
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