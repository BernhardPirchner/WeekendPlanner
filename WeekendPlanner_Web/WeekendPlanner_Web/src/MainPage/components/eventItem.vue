<template>
    <div v-if="this.displayAll" @click="clicked" id="itemSmall" class="event">
        <h3>{{ name }}</h3>
        <p>{{ newStart }}</p>
        <p>{{ location }}</p>
    </div>
    <div v-else id="itemLarge" class="event">
        <h1>{{ name }}</h1>
        <p>{{ description }}</p>
        <p>{{ newStart }} - {{ newEnd }}</p>
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
            location:String,
            displayAll:Boolean
        },
        data(){
            return{
                newStart: this.convertTime(this.start),
                newEnd: this.convertTime(this.end)
            }
        },
        mounted(){

        },
        methods:{
            clicked(){
                this.$emit('clicked', this.id)
            },
            convertTime(time){
                const betterTime=new Date(time)
                return betterTime.toLocaleString()
            }
        }
    }
</script>

<style>
    .event{
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    #itemSmall{
        border: 3px solid rgb(160, 92, 249);
        border-radius: 15%;
        background-color: rgba(106, 54, 236, 0.325);
    }

    #itemLarge{
        border: 3px solid rgb(160, 92, 249);
        border-radius: 15%;
        background-color: rgba(106, 54, 236, 0.325);
        margin:3%;
        padding:5%;
    }
</style>