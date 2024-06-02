import {createApp} from 'vue'

import App from './App_EventAdder.vue'
import EventItem from '@/MainPage/components/eventItem.vue'

const app=createApp(App)
app.component("eventItem", EventItem)
app.mount('#app')