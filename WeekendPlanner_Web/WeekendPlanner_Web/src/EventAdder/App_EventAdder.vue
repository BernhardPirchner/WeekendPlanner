<template>
    <i class="fi fi-rr-arrow-left" @click="home()"></i>
    <div class="container">
        <div class="item">
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
        </div>
        <div>
            <h3>Preview</h3>
            <eventItem :name="eventName" :description="eventDescription" :start="eventStart" :end="eventEnd" :location="eventLocation"/>
        </div>
    </div>
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
                    const response2=await axios.post('https://localhost:7002/api/user/addMyEvent',null,{
                        params:{
                            eventId:response.data.eventId
                        },
                        withCredentials:true
                    })

                    console.log(response2)
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
                this.evetnLocation=null
                this.data=null
            },
            home(){
                window.open("../../index.html", "_self")
            }
        }
    }
</script>

<style>
    .item{
        display: flex;
        flex-direction: column;
        align-items: center;
        align-content: center;
        border: 3px solid #D8BFD8;
        border-radius: 15%;
        background-color: #98FF98 ;
        margin-left: 20%;
        margin-right: 20%;
        padding-bottom: 5%;
    }

    .container{
        display: flex;
        flex-direction: column;
    }
</style>