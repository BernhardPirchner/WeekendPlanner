<template>
    <h1>Login</h1>
    <div v-if="!data">
        <button @click="option('register')">registrieren</button>
        <button @click="option('login')">anmelden</button>
    </div>
    <button @click="back" v-if="data">Back</button>
    <div v-if="data">
        <registryModule v-if="data==='register'"/>
        <loginModule v-else-if="data==='login'"/>
    </div>


    <button @click="home">return to Homepage</button>
</template>

<script>
    export default{
        data(){
            return {
                data: null
            }
        },
        methods:{
            home(){
                window.open("../../index.html", "_self")
            },
            option(opt){
                this.data=opt
            },
            back(){
                this.data=null;
            }
        }
    }
</script>

<style>

</style>