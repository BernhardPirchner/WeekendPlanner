<template>
    <div class="event">
        <h3>{{ name }}</h3>
        <p>{{ desc }}</p>
        <p>{{ time }}</p>
    </div>
</template>

<script>
    export default{
        props:{
            name:String,
            desc:String,
            time:String
        }
    }
</script>

<style>
.event{
    height: auto;
}
</style>