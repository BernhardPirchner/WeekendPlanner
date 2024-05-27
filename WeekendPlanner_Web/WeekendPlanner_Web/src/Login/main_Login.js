import {createApp} from 'vue'

import App from './App_Login.vue'
import Registry from './component/register.vue'
import Login from './component/login.vue'

const app=createApp(App)
app.component('registryComponent', Registry)
app.component('loginComponent', Login)
app.mount('#app')