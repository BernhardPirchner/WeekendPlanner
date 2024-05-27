<template>
    <h2>Login:</h2>
    <form @submit.prevent="login">
        <p>E-Mail: <input type="email" required v-model="userEmail"></p>
        <p>Password: <input type="password" required v-model="userPassword"></p>
        <button type="submit">Login</button>
    </form>
    <p v-if="message">{{ message }}</p>
</template>

<script>
    import axios from 'axios';

    export default{
        data(){
            return {
                userEmail: null,
                userPassword: null,
                message: null
            }
        },
        methods:{
            async login(){
            try{
                    const response=await axios.post("https://localhost:7002/api/user/login", {
                        email: this.userEmail,
                        password: this.userPassword
                    },{
                        withCredentials:true
                    })
                this.message=response.data.message
                }catch(error){
                    console.log(error)
                    this.message=error.response.data.message
                }
                this.reset()
            },
            reset(){
                this.userEmail=null
                this.userPassword=null
            }
        }
    }

</script>

<style>

</style>