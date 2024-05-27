<template class="body">
    <div v-if="!data">
        <h1>Error: Service could not be reached</h1>
    </div>
    <div v-if="data && all" class="container">
        <eventItem v-for="x in data.data" v-bind:key=x.eventId :displayAll="true" :id=x.eventId :name=x.name :description=x.description :start=localTime(x.start) :end="localTime(x.end)" :location="x.location" @clicked="selectEvent"/>
    </div>
    <div v-if="!all">
        <button @click="back">Back</button>
        <eventItem :displayAll="false" :id="item.eventId" :name="item.name" :description="item.description" :start="localTime(item.start)" :end="localTime(item.end)" :location="item.location" />
    </div>

</template>

<script>
import axios from 'axios'

export default{
    data(){
        return{
            data: null,
            all: true,
            item: null,
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
.container{
    display: flex;
    flex-direction: row;
    align-items: flex-start;
    align-content: center;
    flex-wrap: wrap;
    margin: 3%
}

.container > div{
    margin: 0.8rem;
    padding: 0.5rem;
    transition: transform 0.3s cubic-bezier(0.25, 0.8, 0.25, 1), box-shadow 0.3s cubic-bezier(0.25, 0.8, 0.25, 1), background-color 0.3s ease-in-out, opacity 0.3s ease-in-out;
}

.container>div:hover{
    
    transform: scale(1.2);
}

.body{
    background-color: rgb(137, 43, 226);
}
</style>