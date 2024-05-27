<template>
    <headerComponent @userStatus="changeUserStatus"/>
    <eventModule v-if="userStatus===0"/>
    

    <button @click="open('addEvent.html')">Add Event</button>
    <p v-if="message">{{ message }}</p>
    <p v-if="admin">Admin</p>
 


</template>

<script>

    export default{
        data(){
            return {
                message: null,
                userStatus:0
            }
        },
        mounted(){

        },
        methods:{
            test(text){
                console.log(text)
            },
            changeUserStatus(status){
                this.userStatus=status
            }
        }
    }

</script>

<style>

</style>
