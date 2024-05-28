<template>
    <headerComponent @changeUserStatus="changeUserStatus"/>
    <eventModule v-if="!userStatus" :type="0" :user="this.userStatus"/>
    <div v-if="userStatus">
        <form>
            <p>Choose which Events should be shown</p>
            <input type="radio" @click="show(1)" id="1" name="eventModule" checked="true">
            <label for="1">Show All Events</label><br>
            <input type="radio" @click="show(2)" id="2" name="eventModule">
            <label for="2">Show Saved Events</label><br>
            <input type="radio" @click="show(3)" id="3" name="eventModule">
            <label for="3">Show My Events</label>
        </form>
        <div v-if="showMy">
            <h3>My Events</h3>
            <eventModule :type="2" :user="this.userStatus"/>
        </div>
        <div v-if="showSaved">
            <h3>Saved Events:</h3>
            <eventModule :type="1" :user="this.userStatus"/>
        </div>
        <div v-if="showAll">
            <h3>All Events:</h3>
            <eventModule :type="0" :user="this.userStatus"/>
        </div>
    </div>
</template>

<script>

export default{
    data(){
        return {
            message: null,
            userStatus:false,
            showAll:true,
            showSaved:false,
            showMy:false
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
        },
        show(number){
            switch(number){
                case 1: this.showAll=true; this.showSaved=false; this.showMy=false; break;
                case 2: this.showAll=false; this.showSaved=true; this.showMy=false; break;
                case 3: this.showAll=false; this.showSaved=false; this.showMy=true; break;
                default: this.showAll=true; this.showSaved=false; this.showMy=false; break;
            }
        }
    }
}
</script>

<style>

</style>
