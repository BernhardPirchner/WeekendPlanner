<template>
    <h1>Add an Event:</h1>

    <form @submit.prevent="addEvent">
        <p>Name: <input type="text" required v-model="eventName"></p>
        <p>Description: <input type="text" required v-model="eventDescription" ></p>
        <p>Start Date & Time: <input type="datetime-local" required v-model="eventStart"></p>
        <p>End Date & Time <input type="datetime-local" required v-model="eventEnd"></p>
        <p>Location: <input type="text" required v-model="eventLocation"></p>
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
                eventDescription: null,
                eventStart: null,
                eventEnd: null,
                eventLocation:null,
                data:null
            }
        },
        mounted(){
            
        },
        methods:{
            async addEvent(){
                try{
                    const response=await axios.post("https://localhost:7002/api/protoEvent/createProtoEvent", {
                    name: this.eventName,
                    description: this.eventDescription,
                    start: this.eventStart,
                    end: this.eventEnd,
                    location: this.eventLocation
                    }, {
                        withCredentials:true
                    })
                    console.log(response)
                }catch(error){
                    console.log(error)
                }


                this.reset();
            },
            reset(){
                this.eventName=null
                this.eventDescription=null
                this.eventStart=null
                this.eventEnd=null
                this.location=null
                this.data=null
            },
            home(){
                window.open("../../index.html", "_self")
            }
        }
    }
</script>

<style>

</style>