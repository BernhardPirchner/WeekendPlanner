import {createApp} from 'vue'

import App from './App_Login.vue'
import Registry from './component/register.vue'
import Login from './component/login.vue'

const app=createApp(App)
app.component('registryModule', Registry)
app.component('loginModule', Login)
app.mount('#app')