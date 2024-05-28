<template>
    <div v-if="this.displayAll" id="itemSmall" class="event">
        <div v-if="this.userStatus">
            <i v-if="!isSaved" @click="funcIsSaved" class="fi fi-rr-star"></i>
            <i v-else @click="funcIsSaved" class="fi fi-sr-star"></i>
        </div>
        <div  @click="clicked">
            <h3>{{ name }}</h3>
            <p>{{ newStart }}</p>
            <p><i class="fi fi-rr-marker"></i> {{ location }}</p>
        </div>
    </div>
    <div v-else id="itemLarge" class="event">
        <div>
            <h1>{{ name }}</h1>
            <div v-if="this.userStatus">
            <i v-if="!isSaved" @click="funcIsSaved" class="fi fi-rr-star"></i>
            <i v-else @click="funcIsSaved" class="fi fi-sr-star"></i>
        </div>
        </div>
        <p>{{ description }}</p>
        <p>{{ newStart }} - {{ newEnd }}</p>
        <p><i class="fi fi-rr-marker"></i> {{ location }}</p>
    </div>
</template>

<script>
import axios from 'axios';

    export default{
        props:{
            id:String,
            name:String,
            description:String,
            start:String,
            end:String,
            location:String,
            displayAll:Boolean,
            userStatus:Boolean,
            saved:Boolean
        },
        data(){
            return{
                newStart: this.convertTime(this.start),
                newEnd: this.convertTime(this.end),
                isSaved:this.saved
            }
        },
        mounted(){

        },
        methods:{
            clicked(){
                this.$emit('clicked', this.id)
            },
            convertTime(time){
                const betterTime=new Date(time)
                return betterTime.toLocaleString()
            },
            async funcIsSaved(){
                try{
                    let response=null
                    if (this.saved) {
                        this.response=await axios.delete("https://localhost:7002/api/user/removeSavedEvent", {
                            params:{
                                eventId:this.id
                            },
                            withCredentials:true
                        })
                    } else {
                        this.response=await axios.post("https://localhost:7002/api/user/addSavedEvent",null ,{
                            params:{
                                eventId:this.id
                            },
                            withCredentials:true
                        })
                    }
                    this.isSaved=!this.isSaved
                    console.log(response)
                }catch(error){
                    console.log(error)
                }

            }
        }
    }
</script>

<style>
    .event{
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    #itemSmall{
        border: 3px solid #D8BFD8;
        border-radius: 15%;
        background-color: #98FF98;
    }

    #itemLarge{
        border: 3px solid #D8BFD8;
        border-radius: 5%;
        background-color: #98FF98;
        margin:3%;
        padding:5%;
    }
</style>