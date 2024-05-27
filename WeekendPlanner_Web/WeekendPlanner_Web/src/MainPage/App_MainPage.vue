<template>
    <header v-if="admin">
        <div>
            <h1>WeekendPlanner</h1>
            <input type="search">
            <button @click="open('admin.html')">change to admin panel</button>
        </div>
    </header>
    <header v-else-if="user">
        <div>
            <h1>WeekendPlanner</h1>
            <input type="search">
            <p>Profile Placeholder</p>
        </div>
    </header>
    <header v-else>
        <h1>WeekendPlanner</h1>
        <input type="search">
        <button @click="open('login.html')">Login</button>
    </header>

    <h2>Event Modul:</h2>
    <eventModule/>


    <button @click="open('addEvent.html')">Add Event</button>
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
                user:false,
                admin: false
            }
        },
        mounted(){
            this.fetchProfile()
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
                    this.user=response.data
                    this.isAdmin()
                }catch(error){
                    console.log(error)
                    this.user= false
                }
            },
            async isAdmin(){
                const response= await axios.get("https://localhost:7002/api/user/isAdmin", {
                    withCredentials: true
                })
                this.admin=response.data
            },
            test(text){
                console.log(text)
            }
        }
    }

</script>

<style>

</style>
