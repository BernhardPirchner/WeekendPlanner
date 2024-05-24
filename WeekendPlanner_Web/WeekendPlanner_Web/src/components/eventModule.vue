<template>
    <button v-on:click="fetchData">Load Data</button>
    <div v-if="data" class="wrapper">
        <eventItem v-for="x in data.data" v-bind:key=x.eventId :name=x.name :desc=x.desc :time=x.time />
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data(){
        return{
            data: null,
        };
    },
    methods:{
        async fetchData(){
            this.data=await axios.get("https://localhost:7002/api/event");
            console.log(data);
        },
        async fetchTest(){
            this.data=await axios.get("https://random-data-api.com/api/v2/users")
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