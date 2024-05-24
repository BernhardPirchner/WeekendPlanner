<template>
    <h2>Login:</h2>
    <form @submit.prevent="login">
        <p>E-Mail: <input type="email" required v-model="userEmail"></p>
        <p>Password: <input type="password" required v-model="userPassword"></p>
        <button type="submit"></button>
    </form>
</template>

<script>
    export default{
        data(){
            return {
                userEmail: null,
                userPassword: null
            }
        },
        login(){

        },
        reset(){
            this.userEmail=null
            this.userPassword=null
        }
    }

</script>

<style>

</style>