<template>
    <div class="event">
        <h3>{{ name }}</h3>
        <p><i class="fi fi-rr-id-badge"></i> {{ id }}</p>
        <p><i class="fi fi-rr-text"></i> {{ description }}</p>
        <p>{{ convertTime(start) }} - {{ convertTime(end) }}</p>
        <p><i class="fi fi-rr-marker"></i> {{ location }}</p>
        <p><i class="fi fi-rr-id-badge"></i> Created By: {{ createdBy }}</p>
        <button @click="edit" class="button"><i class="fi fi-rr-file-edit"></i> Edit</button>
        <button @click="del" class="button"><i class="fi fi-rr-trash"></i> Delete</button>
        <button v-if="mode!==1" @click="publish" class="button"><i class="fi fi-rr-enter"></i> Publish</button>
    </div>
</template>

<script>
    export default{
        props:{
            id:String,
            name:String,
            description:String,
            start:String,
            end:String,
            location:String,
            createdBy:String,
            mode:Number
        },
        methods:{
            edit(){
                this.$emit("edit", this.id)
            },
            del(){
                this.$emit("delete", this.id, this.createdBy)
            },
            publish(){
                this.$emit("publish", this.id)
            },            
            convertTime(time){
                const betterTime=new Date(time)
                return betterTime.toLocaleString()
            }
        }
    }
</script>

<style>
.event{
    height: auto;
    border: 3px solid #D8BFD8;
    border-radius: 5%;
    background-color: #98FF98;
    margin:3%;
    padding:5%;
}


.button{
        background-color: #FFEB3B;
    }
</style>