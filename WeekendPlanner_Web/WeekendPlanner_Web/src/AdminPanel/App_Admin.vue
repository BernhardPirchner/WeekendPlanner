<template>
    <header>
        <h1>Admin Dashboard</h1>
    </header>

    <button class="button"><i class="fi fi-rr-arrow-left" @click="home"></i></button>
    <h2>Unpublished Events:</h2>
    <protoEventModule :mode="0"/>

    <h2>Published Events</h2>
    <protoEventModule :mode="1"/>
</template>

<script>
    export default{
        methods:{
            home(){
                window.open('../../index.html')
            }
        }
    }

</script>

<style>
    .button{
        background-color: #FFEB3B;
    }

    header{
        display: flex;
        justify-content: space-between;
        background-color:#FFB7C5;
        align-items: center;
        padding-left: 2%;
        padding-right: 2%;
        margin-bottom: 2%;
    }

    header > h1{
        text-decoration: underline;
    }
</style>