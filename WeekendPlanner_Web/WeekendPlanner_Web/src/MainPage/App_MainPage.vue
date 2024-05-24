<template>
    <h1>WeekendPlanner</h1>
    <h2>Event Modul:</h2>
    <eventModule/>


    <button @click="open('addEvent.html')">Add Event</button>
    <button @click="open('login.html')">Login</button>



</template>

<script>
    export default{
        methods:{
            open(link){
                window.open('../../'+link, "_self")
            }
        }
    }

</script>

<style>

</style>
