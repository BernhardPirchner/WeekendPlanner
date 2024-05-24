<template>
    <h1>WeekendPlanner</h1>
    <h2>Event Modul:</h2>
    <eventModule/>


    <button @click="addEvent">Add Event</button>




</template>

<script>
    export default{
        methods:{
            addEvent(){
                window.open("../../addEvent.html")
            }
        }
    }

</script>

<style>

</style>
