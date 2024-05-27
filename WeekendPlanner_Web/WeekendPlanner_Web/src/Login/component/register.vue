<template>
    <h2>Register:</h2>
    <form v-if="!check" @submit.prevent="addUser">
        <p>Firstname: <input type="text" required v-model="userFirstname"></input></p>
        <p>Lastname: <input type="text" required v-model="userLastname"></input></p>
        <p>Username: <input type="text" required v-model="userUserName"></input></p>
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
            userUserName:null,
            userEmail:null,
            userPassword:null,
            check:false
        }
    },
    methods:{
        async addUser(){
            const response=await axios.get("https://localhost:7002/api/user/checkEmail", {
                params:{
                    email:this.userEmail
                }
            })
            if(!response.data){
                await axios.post("https://localhost:7002/api/user/createUser", {
                firstname: this.userFirstname,
                lastname:this.userLastname,
                username: this.userUserName,
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
            this.userFirstname=null
            this.userLastname=null
            this.userUserName=null
            this.userEmail=null
            this.userPassword=null
        }
    }
}
</script>

<style>

</style>