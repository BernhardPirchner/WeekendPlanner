<template>
    <div class="event">
        <h3>{{ name }}</h3>
        <p><br>{{ id }}<br></p>
        <p>{{ desc }}</p>
        <p>{{ time }}</p>
        <button @click="edit">Edit</button>
        <button @click="del">Delete</button>
    </div>
</template>

<script>
    export default{
        props:{
            id:String,
            name:String,
            desc:String,
            time:String
        },
        methods:{
            edit(){
                this.$emit("edit", this.id)
            },
            del(){
                this.$emit("delete", this.id)
            }
        }
    }
</script>

<style>
.event{
    height: auto;
}
</style>