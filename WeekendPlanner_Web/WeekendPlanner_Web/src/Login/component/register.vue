<template>
    <div>
        <h2>Register:</h2>
        <form v-if="!check" @submit.prevent="addUser">
            <p>Firstname: <input type="text" required v-model="userFirstname"></input></p>
            <p>Lastname: <input type="text" required v-model="userLastname"></input></p>
            <p>Username: <input type="text" required v-model="userUserName"></input></p>
            <p>E-Mail: <input type="email" required v-model="userEmail"></input></p>
            <p>Password: <input type="password" required v-model="userPassword"></p>
            <button type="submit" class="button">register</button>
        </form>
        <button @click="change" class="button">Already have an Account?</button>
        <p v-if="check">An Account with this E-Mail already exists!</p>
    </div>
</template>

<script>
import axios from 'axios'

export default{
    data(){
        return{
            userFirstname:null,
            userLastname:null,
            userUserName:null,
            userEmail:null,
            userPassword:null,
            check:false
        }
    },
    methods:{
        async addUser(){
            const response=await axios.get("https://localhost:7002/api/user/checkEmail", {
                params:{
                    email:this.userEmail
                }
            })
            try{
                if(!response.data){
                    const response=await axios.post("https://localhost:7002/api/user/createUser", {
                        firstname: this.userFirstname,
                        lastname:this.userLastname,
                        username: this.userUserName,
                        email: this.userEmail,
                        password: this.userPassword
                    },{
                        withCredentials:true
                    })
                    console.log(response)
                    this.$emit('registered')
                }else{
                    this.check=true;
                }
            }catch(error){
                console.log(error)
            }
            this.reset()
        },
        reset(){
            this.userFirstname=null
            this.userLastname=null
            this.userUserName=null
            this.userEmail=null
            this.userPassword=null
        },
        change(){
            this.$emit("changeComponent")
        }
    }
}
</script>

<style>
    .container{
        display: flex;
        flex-direction: column;
        align-items: center;
        align-content: center;
        border: 3px solid #D8BFD8;
        border-radius: 15%;
        background-color: #98FF98 ;
        margin-left: 20%;
        margin-right: 20%;
        padding-bottom: 5%;
    }

    .button{
        background-color: #FFEB3B;
    }
</style>