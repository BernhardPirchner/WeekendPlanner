<template>
    <div class="event" @click="clicked">
        <h3>{{ name }}</h3>
        <p>{{ description }}</p>
        <p>{{ start }}</p>
        <p>{{ end }}</p>
        <p>{{ location }}</p>
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
            clicked(){
                this.$emit('clicked', this.id)
            }
        }
    }
</script>

<style>
.event{
    height: auto;
}
</style>