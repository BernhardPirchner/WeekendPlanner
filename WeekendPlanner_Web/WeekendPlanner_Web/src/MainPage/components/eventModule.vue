<template>
    <div v-if="data && all" class="wrapper">
        <eventItem v-for="x in data.data" v-bind:key=x.eventId :id=x.eventId :name=x.name :desc=x.description :start=localTime(x.start) :end="localTime(x.end)" :location="x.loc" @clicked="selectEvent"/>
    </div>
    <div v-if="!all">
        <button @click="back">Back</button>
        <eventItem :id="item.eventId" :name="item.name" :description="item.desc" :start="localTime(item.start)" :end="localTime(item.end)" :location="item.loc" />
    </div>

</template>

<script>
import axios from 'axios'

export default{
    data(){
        return{
            data: null,
            all: true,
            item: null
        };
    },
    mounted(){
        this.fetchData()
    },
    methods:{
        async fetchData(){
            this.data=await axios.get("https://localhost:7002/api/event/allEvents");
        },
        localTime(time){
        const utc=new Date(time)
        const local=new Date(utc.getTime()-utc.getTimezoneOffset()*60000)
        return local.toISOString()
        },
        async selectEvent(id){
            console.log(id)
            try{
                const response=await axios.get("https://localhost:7002/api/event/oneEvent", {
                    params:{
                        id:id
                    }
                })
                this.all=false
                this.item=response.data
                console.log(response)
            }catch(error){
                console.log(error)
            }
        },
        back(){
            this.all=true
            this.item=null
        }
    },
};
</script>

<style>
.wrapper{
    display: flex;
    flex-wrap: wrap;
}

.wrapper > div{
    border: 3px solid blue;
    flex-basis: 120px;
    margin: 5%;
    padding: 5%;
    background-color: aliceblue;
}
</style>