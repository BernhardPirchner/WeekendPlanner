import {createApp} from 'vue'

import App from './App_Admin.vue'
import ProtoEventItem from './components/protoEventItemAdmin.vue'
import ProtoEventModule from './components/protoEventModule.vue'
import ProtoEventItemEdit from './components/protoEventItemEdit.vue'

const app=createApp(App)
app.component('protoEventItem', ProtoEventItem)
app.component('protoEventModule', ProtoEventModule)
app.component('protoEventItemEdit', ProtoEventItemEdit)
app.mount('#app')