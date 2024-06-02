<template>
    <div class="headerContainer">
        <h1>Event Adder</h1>
    </div>
    <button  @click="home" class="button"><i class="fi fi-rr-arrow-left"></i> Back</button>
    <div class="container">
        <div class="item">
            <form @submit.prevent="addEvent">
                <p><i class="fi fi-rr-id-badge"></i> Name: <input type="text" required v-model="eventName"></p>
                <p><i class="fi fi-rr-text"></i> Description: <textarea id="description" required v-model="eventDescription"></textarea></p>
                <p><i class="fi fi-rr-calendar-clock"></i> Start Date & Time: <input type="datetime-local" required v-model="eventStart"></p>
                <p><i class="fi fi-rr-calendar-clock"></i> End Date & Time <input type="datetime-local" required v-model="eventEnd"></p>
                <p><i class="fi fi-rr-marker"></i> Location: <input type="text" required v-model="eventLocation"></p>
                <button type="submit" class="button"><i class="fi fi-rr-plus"></i> Add</button>
            </form>
            <p v-if="data">{{ data }}</p>
        </div>
    </div>
</template>

<script>
    import axios from 'axios'

    export default{
        data(){
            return {
                eventName: "Event",
                eventDescription: "Description of the Event",
                eventStart: null,
                eventEnd: null,
                eventLocation:"Location of the Event",
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
                    const response2=await axios.post("https://localhost:7002/api/user/addMyEvent", null, {
                        withCredentials:true,
                        params:{
                            eventId: response.data.eventId
                        }
                    })
                }catch(error){
                    console.log(error)
                }
                this.reset()
            },
            reset(){
                this.eventName= "Event"
                this.eventDescription= "Description of the Event"
                this.eventStart= null
                this.eventEnd= null 
                this.eventLocation="Location of the Event"
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

    .button{
        background-color: #FFEB3B; 
    }

    .headerContainer{
        display: flex;
        justify-content: space-between;
        background-color:#FFB7C5;
        align-items: center;
        padding-left: 2%;
        padding-right: 2%;
        margin-bottom: 2%
    }

    .headerContainer > h1{
        text-decoration: underline;
    }
</style>