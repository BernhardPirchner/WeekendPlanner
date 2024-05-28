<template class="body">    
    <div v-if="!data">
        <h1>Error: Service could not be reached</h1>
    </div>
    <div v-if="data && all" class="container">
        <eventItem v-for="x in data.data" v-bind:key=x.eventId :saved="x.saved" :userStatus="this.user" :displayAll="true" :id=x.eventId :name=x.name :description=x.description :start=localTime(x.start) :end="localTime(x.end)" :location="x.location" @clicked="selectEvent"/>
    </div>
    <div v-if="!all">
        <button @click="back" class="button"><i class="fi fi-rr-arrow-left"></i></button>
        <eventItem :displayAll="false" :id="item.eventId" :saved="item.saved" :userStatus="this.user" :name="item.name" :description="item.description" :start="localTime(item.start)" :end="localTime(item.end)" :location="item.location" />
    </div>

</template>

<script>
import axios from 'axios'

export default{

    props:{
        type:Number,
        user:Boolean
    },
    data(){
        return{
            data: null,
            all: true,
            item: null,
            type:this.type,
        }
    },
    computed:{

    },
    mounted(){
        switch(this.type){
            case 0: this.fetchAll(); break;
            case 1: this.fetchSaved(); break;
            case 2: this.fetchMy(); break
            default: this.fetchAll(); break;
        }

    },
    methods:{
        async fetchAll(){
            try{
                const tempData= await axios.get("https://localhost:7002/api/user/savedEvents", {
                    withCredentials:true
                });
                const tempData2=await axios.get("https://localhost:7002/api/event/allEvents");

                console.log(tempData)
                console.log(tempData2)
                tempData2.data.forEach(element => {
                    if (tempData.data.includes(element.eventId)) {
                        element["saved"]=true
                    } else {
                        element["saved"]=false
                    }
                this.data=tempData2
                });
            }catch(error){
                console.log(error)
            }
        },
        async fetchSaved(){
            try{
                const response=await axios.get("https://localhost:7002/api/user/savedEvents", {
                    withCredentials:true
                })
                console.log(response.data)
                const response2=await axios.get("https://localhost:7002/api/event/someEvents", {
                    params:{
                        eventIds:response.data
                    },
                    paramsSerializer:{
                        indexes:true
                    }
                })
                response2.data.forEach(element => {
                    element["saved"]=true
                });
                this.data=response2
            }catch(error){
                console.log(error)
            }
        },
        async fetchMy(){
            try{
                const response=await axios.get("https://localhost:7002/api/user/MyEvents", {
                    withCredentials:true
                })
                console.log(response.data)
                const response2=await axios.get("https://localhost:7002/api/event/someEvents", {
                    params:{
                        eventIds:response.data
                    },
                    paramsSerializer:{
                        indexes:true
                    }
                })
                console.log(response2)
                console.log(this.data)
            }catch(error){
                console.log(error)
            }
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
}
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
    cursor: pointer;
    transition: transform 0.3s cubic-bezier(0.25, 0.8, 0.25, 1), box-shadow 0.3s cubic-bezier(0.25, 0.8, 0.25, 1), background-color 0.3s ease-in-out, opacity 0.3s ease-in-out;
}

.container>div:hover{
    
    transform: scale(1.2);
}
</style>