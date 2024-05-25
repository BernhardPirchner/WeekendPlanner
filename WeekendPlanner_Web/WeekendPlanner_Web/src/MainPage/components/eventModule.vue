<template>
    <div @load.once="fetchData">
        <button @click="fetchData">Load Data</button>
    </div>
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
    mounted(){
        this.fetchData()
    },
    methods:{
        async fetchData(){
            this.data=await axios.get("https://localhost:7002/api/event/allEvents");
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