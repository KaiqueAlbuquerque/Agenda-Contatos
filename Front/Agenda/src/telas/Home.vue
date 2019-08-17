<template>
    <div class="row">
        <div class="col s12">
            <div class="card">
                <div class="row">
                    <div class="col s7 l4 offset-l1">
                        <h2>Contatos</h2>
                    </div>
                    <div class="col s3 l1 offset-s2" style="margin-top: 40px;">
                        <router-link to="/cadastro" class="btn-floating waves-effect waves-light blue right btn-large"><i class="material-icons">add</i></router-link>
                    </div>
                    <div class="nav-wrapper col s12 l5 offset-l1" style="margin-top: 50px;">
                        <form>
                            <div class="input-field">
                                <input id="search" placeholder="Digite o nome..." type="search" v-on:input="filtro = $event.target.value">
                                <label class="label-icon" for="search"><i class="material-icons">search</i></label>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="card-content">
                     <minha-tabela v-on:alterar="detalhes" v-on:excluir="excluir" :titulos="titulos" :corpos="contatosComFiltro" :opcao="opcao"></minha-tabela>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    //Componentes
    import Tabela from '../componentes/Tabela.vue';
    
    //Serviços
    import AgendaServico from  '../classes/servicos/AgendaServico.js';

    export default {
        components: {
            'minha-tabela': Tabela
        },

        computed: {
            contatosComFiltro(){
                if(this.filtro){
                    let exp = new RegExp(this.filtro.trim(), 'i');
                    return this.corpos.filter(contato => exp.test(contato.valor[0]));
                }
                else{
                    this.corpos = this.corposSemFiltro;
                    return this.corpos;
                }
            }
        },

        methods: {
            detalhes(obj){
                let rotas = this.$router;
                rotas.push({ name: 'altera', params: { id: obj.id }  });
            },

            excluir(obj){
                let agendaServico = new AgendaServico();
                agendaServico.delete(obj.id)
                    .then(res => {
                        if(res.status == 200)
                        {
                            let novaLista = this.corpos.filter(contato => {
                                return contato.id != obj.id;
                            });

                            this.corposSemFiltro = novaLista;
                            this.contatosComFiltro;

                            M.Toast.dismissAll();
                            M.toast({html: 'Excluido com sucesso.', classes: 'rounded'});
                        }
                    })  
            }
        },

        data(){
            return{
                //Tabela
                titulos: ['Nome'],
                corpos: [],
                corposSemFiltro: [],
                opcao: "Detalhes",

                filtro: ""
            }
        },
        
        created(){
            let agendaServico = new AgendaServico();
            agendaServico.get()
                .then(dados => 
                {
                    dados.forEach(dado => {
                        this.corpos.push({"id": dado.ContatoId, "valor": [dado.Nome]});
                    });
                })
                this.corposSemFiltro = this.corpos;
        }
    }
</script>

<style>
    .toast{ background-color: #2196f3; }

    #toast-container {
        min-width: 10%;
        top: auto !important;
        bottom: 10%;
        right: 50%;
        transform: translateX(50%) translateY(50%);
    }
</style>