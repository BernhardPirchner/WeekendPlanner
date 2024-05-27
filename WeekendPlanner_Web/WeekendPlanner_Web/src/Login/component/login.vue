<template>
    <div class="container">
        <h2>Login:</h2>
        <form v-if="!check" @submit.prevent="login">
            <p>E-Mail: <input type="email" required v-model="userEmail"></p>
            <p>Password: <input type="password" required v-model="userPassword"></p>
            <button type="submit">Login</button>
        </form>
        <p v-if="message">{{ message }}</p>
        <button @click="change">Don't have an Account?</button>
    </div>
</template>

<script>
    import axios from 'axios';

    export default{
        data(){
            return {
                userEmail: null,
                userPassword: null,
                message: null,
                check:false
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
                this.$emit("loggedIn")
                }catch(error){
                    console.log(error)
                    this.check=true
                    this.message=error.response.data.message
                }
                this.reset()
            },
            reset(){
                this.userEmail=null
                this.userPassword=null
            },
            change(){
                this.$emit("changeComponent")
            }
        }
    }

</script>

<style>
    .container{
        display: flex;
        flex-direction: column;
        align-content: center;
        border: 3px solid rgb(160, 92, 249);
        border-radius: 15%;
        background-color: rgba(106, 54, 236, 0.325);
        margin-left: 20%;
        margin-right: 20%;
        padding-bottom: 5%;
    }
</style>