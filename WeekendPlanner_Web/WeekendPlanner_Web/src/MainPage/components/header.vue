<template>
        <header v-if="isAdmin">
        <div class="headerContainer">
            <h1>WeekendPlanner</h1>
            <form>
                <i class="fi fi-rr-search"></i>
                <input type="search" placeholder="Search...">
            </form>
            <div>
                <button class="button" @click="open('addEvent.html')"><i class="fi fi-rr-plus"></i></button>
                <button class="button" @click="open('admin.html')"><i class="fi fi-rr-admin-alt"></i></button>
                <button class="button" @click=""><i class="fi fi-rr-circle-user"></i></button>
            </div>
        </div>
    </header>
    <header v-else-if="isUser">
        <div class="headerContainer">
            <h1>WeekendPlanner</h1>
            <form>
                <i class="fi fi-rr-search"></i>
                <input type="search" placeholder="Search...">
            </form>
            <div>
                <button class="button" @click="open('addEvent.html')"><i class="fi fi-rr-plus"></i></button>
                <button class="button" @click=""><i class="fi fi-rr-circle-user"></i></button>
            </div>
        </div>
    </header>
    <header v-else>
        <div class="headerContainer">
            <div>
                <h1>WeekendPlanner</h1>
            </div>
            <form>
                <i class="fi fi-rr-search"></i>
                <input type="search" placeholder="Search...">
            </form>
            <div>
                <button class="button" @click="open('login.html')">Login <i class="fi fi-rr-sign-in-alt"></i></button>
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
                    this.$emit("changeUserStatus", this.isUser)
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
        background-color:#FFB7C5;
        align-items: center;
        padding-left: 2%;
        padding-right: 2%;
    }

    .button{
        background-color: #FFEB3B;
        border: none;
        border: 1px solid black;
        border-radius: 25%;
    }
</style>