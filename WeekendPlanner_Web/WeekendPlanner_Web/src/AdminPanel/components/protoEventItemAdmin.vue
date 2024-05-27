<template>
    <div class="event">
        <h3>{{ name }}</h3>
        <p><br>{{ id }}<br></p>
        <p>{{ description }}</p>
        <p>{{ start }}</p>
        <p>{{ end }}</p>
        <p>{{ location }}</p>
        <button @click="edit">Edit</button>
        <button @click="del">Delete</button>
        <button @click="publish">Publish</button>
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
            location:String
        },
        methods:{
            edit(){
                this.$emit("edit", this.id)
            },
            del(){
                this.$emit("delete", this.id)
            },
            publish(){
                this.$emit("publish", this.id)
            }
        }
    }
</script>

<style>
.event{
    height: auto;
}
</style>