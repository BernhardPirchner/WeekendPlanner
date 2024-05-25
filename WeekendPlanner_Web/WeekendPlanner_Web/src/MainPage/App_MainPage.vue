<template>
    <header>
        <button @click="open('admin.html')">change to admin panel</button>
    </header>
    <h1>WeekendPlanner</h1>
    <h2>Event Modul:</h2>
    <eventModule/>


    <button @click="open('addEvent.html')">Add Event</button>
    <button @click="open('login.html')">Login</button>
    <button @click="fetchProfile">Check Admin</button>
    <p v-if="message">{{ message }}</p>
    <p v-if="admin">Admin</p>



</template>

<script>
import axios from 'axios';

    export default{
        data(){
            return {
                message: null,
                admin: null
            }
        },
        mounted(){
            this.admin=this.isAdmin()
            console.log(this.admin)
        },
        methods:{
            open(link){
                window.open('../../'+link, "_self")
            },
            async fetchProfile(){
                try{
                    const response =await axios.get("https://localhost:7002/api/user/oneUser", {
                    withCredentials: true
                    })
                    console.log(response)
                    this.message=response.data.message
                }catch(error){
                    console.log(error)
                    this.message=error.response.data.message
                }
            },
            async isAdmin(){
                const response= await axios.get("https://localhost:7002/api/user/isAdmin", {
                    withCredentials: true
                })
                this.admin=response.data
            }
        }
    }

</script>

<style>

</style>
