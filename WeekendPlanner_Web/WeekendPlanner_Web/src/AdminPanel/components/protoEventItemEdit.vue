<template>
    <form @submit.prevent="edit" id="item">
        <h2>Editing Event {{ id }}</h2>
        <p>Name: <input type="text" v-model="newName"></p>
        <p>Description: <textarea v-model="newDescription"></textarea></p>
        <p>Start: <input type="datetime-local" v-model="newStart"></p>
        <p>End: <input type="datetime-local" v-model="newEnd"></p>
        <p>Location: <input type="text" v-model="newLocation"></p>
        <button type="submit">Submit Changes</button>
    </form>
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
        mode:Number
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
                if(this.mode===0)
                {
                    const response=await axios.put("https://localhost:7002/api/ProtoEvent/updateProtoEvent", {
                    name:this.newName,
                    description:this.newDescription,
                    start:this.newStart,
                    end:this.newEnd,
                    location:this.newLocation
                    },{
                        withCredentials:true,
                        params:{
                            id: this.id,
                        }
                    })
                    console.log(response.data.message)
                }else if(this.mode===1){
                    const response=await axios.put("https://localhost:7002/api/event/updateEvent", {
                    name:this.newName,
                    description:this.newDescription,
                    start:this.newStart,
                    end:this.newEnd,
                    location:this.newLocation
                    },{
                        withCredentials:true,
                        params:{
                            id: this.id,
                        }
                    })
                    console.log(response.data.message)
                } 
                this.$emit("finished")
            }catch(error){
                console.log(error)         
            }
        }
    }
}
</script>

<style>
#item{
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


#item > h2{
    text-decoration: underline;
}
</style>