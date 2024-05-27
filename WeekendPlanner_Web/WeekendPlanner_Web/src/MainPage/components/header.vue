<template>
        <header v-if="isAdmin">
        <div class="headerContainer">
            <h1>WeekendPlanner</h1>
            <input type="search">
            <button @click="open('admin.html')">change to admin panel</button>
        </div>
    </header>
    <header v-else-if="isUser">
        <div class="headerContainer">
            <h1>WeekendPlanner</h1>
            <input type="search">
            <p>Profile Placeholder</p>
        </div>
    </header>
    <header v-else>
        <div class="headerContainer">
            <div class="item">
                <h1>WeekendPlanner</h1>
            </div>
            <div class="item">
                <input type="search">
            </div>
            <div class="item">
                <button @click="open('login.html')">Login</button>
            </div>
        </div>
    </header>
</template>

<script>
    import axios from 'axios';

    export default{
        data(){
            return{
                isUser:false,
                isAdmin:false
            }
        },
        mounted(){
            this.userStatus()
        },
        methods:{
            async userStatus(){
                try{
                    const response =await axios.get("https://localhost:7002/api/user/oneUser", {
                    withCredentials: true
                    })
                    this.isUser=response.data
                    this.checkAdmin()
                }catch(error){
                    console.log(error)
                }
            },
            async checkAdmin(){
                const response= await axios.get("https://localhost:7002/api/user/isAdmin", {
                    withCredentials: true
                })
                this.isAdmin=response.data
            },
            open(link){
                window.open('../../'+link, "_self")
            },
            }
        }
</script>

<style>
    .headerContainer{
        display: flex;
        justify-content: space-between;
        background-color:aqua;
        align-items: center;
        padding-left: 2%;
        padding-right: 2%;
    }

    .item{
        background-color:aqua;
    }
</style>