<template>
    <div v-if="data" class="wrapper">
        <protoEventItem v-for="x in data.data" v-bind:key=x.eventId :id=x.eventId :name=x.name :desc=x.desc :time=x.time @edit="editItem" @delete="receiveEmit"/>
    </div>

    <div v-if="editing">
        <p>Currently Editing</p>
        <protoEventItemEdit  :id=eItem.eventId :name=eItem.name :desc=eItem.desc :time=eItem.time />
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data(){
        return{
            data: null,
            editing: false,
            eItem: null
        };
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
            console.log(id)
            const response= await axios.get("https://localhost:7002/api/protoEvent/oneProtoEvent", {
                params:{
                    id: id
                }
            })
            console.log(response.data)
            this.eItem=response.data
            this.editing=true
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