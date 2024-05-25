import { createApp } from 'vue'

import App from './App_MainPage.vue'
import EventItem from './components/eventItem.vue'
import EventModule from './components/eventModule.vue'

const app=createApp(App)
app.component('eventItem', EventItem)
app.component('eventModule', EventModule)
app.mount('#app')
