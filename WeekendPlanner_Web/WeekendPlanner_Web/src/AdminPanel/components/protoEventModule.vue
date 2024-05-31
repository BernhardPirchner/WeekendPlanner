<template>
    <div v-if="data&&!editing" class="wrapper">
        <protoEventItem v-for="x in data.data" :ref="'childComponent' + x.eventId" v-bind:key=x.eventId :id=x.eventId :name=x.name :description=x.description :start=localTime(x.start) :end="localTime(x.end)" :location=x.location :createdBy="x.createdBy" :mode="this.mode" @edit="editItem" @delete="deleteItem" @publish="publishItem"/>
    </div>

    <div v-if="editing">
        <protoEventItemEdit :id=eItem.eventId :name=eItem.name :description=eItem.description :start=localTime(eItem.start) :end="localTime(eItem.end)" :location=eItem.location :mode="this.mode" @finished="editFinished" />
    </div>
</template>

<script>
import axios from 'axios'

export default{
    props:{
        mode:Number
    },
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
            try{
                if(this.mode===0)
                {
                    this.data=await axios.get("https://localhost:7002/api/protoEvent/allProtoEvents");
                }else if(this.mode===1){
                    this.data=await axios.get("https://localhost:7002/api/event/allEvents");
                }
            }catch(error){
                console.log(error)
            }
            
        },
        receiveEmit(id){
            alert("received by "+id)
        },
        async editItem(id){
            let response=null
                try{
                    this.selectedChild=id
                if(this.mode===0){
                    response= await axios.get("https://localhost:7002/api/protoEvent/oneProtoEvent", {
                        params:{
                            id: id
                        }
                    })
                }else if(this.mode===1){
                    response= await axios.get("https://localhost:7002/api/event/oneEvent", {
                        params:{
                            id: id
                        }
                    })
                }
                console.log(response.data)
                this.eItem=response.data
                this.editing=true
            }catch(error){
                console.log(error)
            }

        },
        async deleteItem(id, createdBy){
            try{
                if(this.mode===0){
                    const response=await axios.delete("https://localhost:7002/api/protoEvent/deleteProtoEvent",{
                    withCredentials:true,
                    params:{
                        id:id
                    }})

                    console.log(response.data.message)
                    const response2=await axios.delete("https://localhost:7002/api/user/removeMyEvent", {
                        withCredentials:true,
                        params:{
                            createdById:createdBy,
                            eventId:id
                        }
                    })
                    console.log(response2.data.message)
                }else if(this.mode===1){
                    const response=await axios.delete("https://localhost:7002/api/event/deleteEvent",{
                    withCredentials:true,
                    params:{
                        id:id
                    }})

                    console.log(response.data.message)
                    const response2=await axios.delete("https://localhost:7002/api/user/removeMyEvent", {
                        withCredentials:true,
                        params:{
                            createdById:createdBy,
                            eventId:id
                        }
                    })
                    console.log(response2.data.message)

                    const response3=await axios.delete("https://localhost:7002/api/user/removeSavedGlobal", {
                        withCredentials:true,
                        params:{
                            eventId:id
                        }
                    })
                    console.log(response3.data.message)
                }
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
            console.log(time)
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
        margin: 0.8rem;
        padding: 0.5rem;
        cursor: pointer;
        transition: transform 0.3s cubic-bezier(0.25, 0.8, 0.25, 1), box-shadow 0.3s cubic-bezier(0.25, 0.8, 0.25, 1), background-color 0.3s ease-in-out, opacity 0.3s ease-in-out;
    }

</style>