<template>
    <div class="header">
        <button class="button"><i class="fi fi-rr-arrow-left" @click="home"></i></button>
        <h1>Admin Panel:</h1>
    </div>

    <protoEventModule/>
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
    .header{
        background: #FFB7C5; 
    }
</style>