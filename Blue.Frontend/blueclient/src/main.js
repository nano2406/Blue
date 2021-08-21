import { createApp } from 'vue'
import App from './App.vue'

import PrimeVue from 'primevue/config'
// Importar os componentes Prime

import Button from 'primevue/button'
import InputText from 'primevue/inputtext'
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import ColumnGroup from 'primevue/columngroup'; 
import InputMask from 'primevue/inputmask'; 



// Importar os StyleCss necessários para os componentes Prime
import 'primevue/resources/themes/saga-blue/theme.css'       //theme
import 'primevue/resources/primevue.min.css'                 //core css
import 'primeicons/primeicons.css'                           //icons

const app = createApp(App);
app.use(PrimeVue);

//Utilizando os componentes Ex: app.component('primecomponente', <nomecomponente>)

app.component('Button', Button);
app.component('InputText', InputText);
app.component('DataTable', DataTable);
app.component('Column', Column);
app.component('ColumnGroup', ColumnGroup);
app.component('InputMask', InputMask);



app.mount('#app')


