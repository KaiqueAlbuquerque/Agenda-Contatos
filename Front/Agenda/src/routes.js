import Cadastra from './telas/Cadastra.vue';
import Home from './telas/Home.vue';

export const routes = [
    {path: '', name: 'home', component: Home},
    {path: '/cadastro', name: 'cadastro', component: Cadastra},
    {path: '/alterar/:id', name: 'altera', component: Cadastra},
    {path: '*', component: Home}
];