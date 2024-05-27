<template>
    <h2>Editing Event {{ id }}</h2>
    <form @submit.prevent="edit">
        <input type="text" v-model="newName">
        <input type="text" v-model="newDescription">
        <input type="datetime-local" v-model="newStart" >
        <input type="datetime-local" v-model="newEnd" >
        <input type="text" v-model="newLocation">
        <button type="submit">Submit Changes</button>
    </form>

    <h2>Preview:</h2>
    <protoEventItem :id="this.id" :name="this.newName" :description="this.newDescription" :start="this.newStart" :end="this.newEnd" :location="this.newLocation"/>

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
        location:String
    },
    data(){
        return{
            newName: this.name,
            newDescription: this.description,
            newStart: this.start.split('Z')[0],
            newEnd:this.end.split('Z')[0],
            newLocation:this.location,
            protoEvent:null
        }
    },
    mounted(){
    },
    methods:{
        async edit(){
            try{
                const response=await axios.put("https://localhost:7002/api/ProtoEvent/updateProtoEvent", {
                name:this.newName,
                description:this.newDescription,
                start:this.newStart,
                end:this.newEnd,
                location:this.newLocation
                },{
                    params:{
                        id: this.id,
                    }
                })
                console.log(response.data.message)
                this.$emit("finished")
            }catch(error){
                console.log(error)         }
        }
    }
}
</script>

<style>

</style>