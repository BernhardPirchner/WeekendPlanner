<template>
    <headerComponent @changeUserStatus="changeUserStatus"/>
    <eventModule v-if="!userStatus" :type="0" :user="this.userStatus"/>
    <div>
        <h3>All Events</h3>
        <eventModule v-if="userStatus" :type="0" :user="this.userStatus"/>
    </div>
    <div>
        <h3>Saved Events</h3>
        <eventModule v-if="userStatus" :type="1" :user="this.userStatus"/>
    </div>
    <div>
        <h3>My Events</h3>
        <eventModule v-if="userStatus" :type="2" :user="this.userStatus"/>
    </div>
    

    <button @click="open('addEvent.html')">Add Event</button>
    <p v-if="message">{{ message }}</p>
 


</template>

<script>

export default{
    data(){
        return {
            message: null,
            userStatus:false
        }
    },
    mounted(){

    },
    methods:{
        test(text){
            console.log(text)
        },
        changeUserStatus(status){
            this.userStatus=status
            console.log("Main User Status = "+this.userStatus)
        }
    }
}

</script>

<style>

</style>
