<template>
    <button @click="home">return to Homepage</button>
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

</style>