<template>
    <h2>Editing Event {{ id }}</h2>
    <protoEventItemAdmin :is=protoEvent />
    <form @submit.prevent="edit">
        <input type="text" v-model=newName>
        <input type="text" v-model=newDesc>
        <input type="date" v-model=newTime >
        <button type="submit">Submit Changes</button>
    </form>


</template>

<script>
import axios from 'axios';

export default{
    props:{
        protoEvent:Object,
        id:String,
        name:String,
        desc:String,
        time:String
    },
    data(){
        return{
            newName: this.name,
            newDesc: this.desc,
            newTime: this.time.split('T').at(0)
        }
    },
    methods:{
        async edit(){
            let newProtoEvent={
                name:this.newName,
                desc:this.newDesc,
                time:this.newTime
            }
            await axios.put("https://localhost:7002/api/ProtoEvent/updateProtoEvent", {
                name:this.newName,
                desc:this.newDesc,
                time:this.newTime
            } ,{
                params:{
                    id: this.id,
                }
            })
        }
    }
}
</script>

<style>

</style>