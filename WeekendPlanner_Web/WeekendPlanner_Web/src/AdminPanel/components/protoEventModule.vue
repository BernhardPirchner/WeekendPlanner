<template>
    <div v-if="data&&!editing" class="wrapper">
        <protoEventItem v-for="x in data.data" :ref="'childComponent' + x.eventId" v-bind:key=x.eventId :id=x.eventId :name=x.name :description=x.description :start=localTime(x.start) :end="localTime(x.end)" location:x.location @edit="editItem" @delete="deleteItem" @publish="publishItem"/>
    </div>

    <div v-if="editing">
        <p>Currently Editing</p>
        <protoEventItemEdit :id=eItem.eventId :name=eItem.name :description=eItem.description :start=localTime(eItem.start) :end="localTime(eItem.end)" :location=eItem.location @finished="editFinished" />
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data(){
        return{ 
            data: null,
            editing: false,
            eItem: null,
            selectedChild: null
        }
    },
    mounted(){
        this.fetchData()
    },
    methods:{
        async fetchData(){
            this.data=await axios.get("https://localhost:7002/api/protoEvent/allProtoEvents");
        },
        receiveEmit(id){
            alert("received by "+id)
        },
        async editItem(id){
            this.selectedChild=id
            const response= await axios.get("https://localhost:7002/api/protoEvent/oneProtoEvent", {
                params:{
                    id: id
                }
            })
            console.log(response.data)
            this.eItem=response.data
            this.editing=true
        },
        async deleteItem(id){
            try{
                const response=await axios.delete("https://localhost:7002/api/protoEvent/deleteProtoEvent",{
                withCredentials:true,
                params:{
                    id:id
                }})
                console.log(response.data.message)
                location.reload()
            }catch(error){
                console.log(error)
            }
        },
        editFinished(){
            this.editing=false
            location.reload()
        },
        localTime(time){
            const utc=new Date(time)
            const local=new Date(utc.getTime()-utc.getTimezoneOffset()*60000)
            return local.toISOString()
        },
        async publishItem(id){
            const response= await axios.get("https://localhost:7002/api/protoEvent/oneProtoEvent",{
                params:{
                    id:id
                }
            })

            axios.post("https://localhost:7002/api/event/createEvent", response.data)
            this.deleteItem(id)
        }
    }
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