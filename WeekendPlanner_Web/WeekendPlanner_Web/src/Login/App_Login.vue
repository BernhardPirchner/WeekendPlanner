<template>
    <header>
        <h1 v-if="hasAccount">Login</h1>
        <h1 v-else>Register</h1>
    </header>
    <button @click="home" class="button"><i class="fi fi-rr-arrow-left"></i></button>
    <registryComponent v-if="!hasAccount" @changeComponent="change" @registered="finish" class="container"/>
    <loginComponent v-else @changeComponent="change" @loggedIn="finish" class="container"/>
</template>

<script>
    export default{
        data(){
            return {
                hasAccount:true 
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
            },
            finish(){
                console.log("Hello")
                this.home()
            },
            change(){
                this.hasAccount=!this.hasAccount
            }
        }
    }
</script>

<style>
    .button{
        background-color: #FFEB3B ;
    }

    header{
        display: flex;
        justify-content: space-between;
        background-color:#FFB7C5;
        align-items: center;
        padding-left: 2%;
        padding-right: 2%;
        margin-bottom: 2%;
    }

    header > h1{
        text-decoration: underline;
    }
</style>