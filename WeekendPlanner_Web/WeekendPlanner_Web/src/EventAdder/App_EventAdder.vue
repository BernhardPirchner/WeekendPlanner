<template>
    <h1>Add an Event:</h1>

    <form @submit.prevent="addEvent">
        <p>Name: <input type="text" required v-model="eventName"></p>
        <p>Description: <input type="text" v-model="eventDesc" ></p>
        <p>Date: <input type="date" required v-model="eventDate"></p>
        <button type="submit">Add Event</button>
    </form>
    <button @click="home">return to Homepage</button>
    <p v-if="data">{{ data }}</p>
</template>

<script>
    import axios from 'axios'

    export default{
        data(){
            return {
                eventName: null,
                eventDesc: null,
                eventDate: null,
                data:null
            }
        },
        methods:{
            async addEvent(){
                let event={
                    name: this.eventName,
                    desc: this.eventDesc,
                    time: this.eventDate 
                }
                this.data=JSON.stringify(event)
                await axios.post("https://localhost:7002/api/event", {
                    name: this.eventName,
                    desc: this.eventDesc,
                    time: this.eventDate
                })
                .then(function(response){
                    console.log(response)
                })
                .catch(function(error){
                    console.log(error)
                });
                this.reset();
            },
            reset(){
                this.eventName=null
                this.eventDesc=null
                this.eventDate=null
                this.data=null
            },
            home(){
                window.open("../../index.html")
            }
        }
    }
</script>

<style>

</style>