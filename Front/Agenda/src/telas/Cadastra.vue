<template>
    <div>
        <div>
            <h1 class="center">Dados Cadastrais</h1>
        </div>
        <div class="row">
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s12">
                        <input id="nome" type="text" class="validate">
                        <label id="lblNome" for="nome">Nome do Contato</label>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col s12 l6">
                <div class="card" id="cardTelefone">
                    <div class="row">
                        <div class="input-field col s8 offset-s1">
                            <vue-mask id="telefone" mask="00 0000-00000"></vue-mask>
                            <label id="lblTelefone" for="telefone">Telefone</label>
                        </div>
                        <div class="col s2 btnAdd">
                            <a v-on:click="adicionaTelefone" class="btn-floating waves-effect waves-light blue right"><i class="material-icons">add</i></a>
                        </div>
                    </div>
                    <div class="card-content">
                        <minha-tabela v-on:alterar="editaTelefone" v-on:excluir="excluirTelefone" :titulos="titulosTelefone" :corpos="corposTelefone" :opcao="opcao"></minha-tabela>
                    </div>
                </div>
            </div>
            <div class="col s12 l6">
                <div class="card" id="cardEmail">
                    <div class="row">
                        <div class="input-field col s8 offset-s1">
                            <input id="email" type="email" class="validate">
                            <label id="lblEmail" for="email">E-mail</label>
                        </div>
                        <div class="col s2 btnAdd">
                            <a v-on:click="adicionaEmail" class="btn-floating waves-effect waves-light blue right"><i class="material-icons">add</i></a>
                        </div>
                    </div>
                    <div class="card-content">
                        <minha-tabela v-on:alterar="editaEmail" v-on:excluir="excluirEmail" :titulos="titulosEmail" :corpos="corposEmail" :opcao="opcao"></minha-tabela>
                    </div>
                </div>
            </div>
        </div>
        <div class="row right">
            <router-link to="/" class="waves-effect waves-light btn center grey darken-2">Voltar</router-link>
            <a href="#" v-on:click="adicionaContato" class="waves-effect waves-light btn center light-green">Salvar</a>
        </div>
    </div>
</template>

<script>    
    //Componentes
    import Tabela from '../componentes/Tabela.vue';

    //Serviços
    import AgendaServico from  '../classes/servicos/AgendaServico.js';

    export default{
        components: {
            'minha-tabela': Tabela
        },

        methods: {
            adicionaTelefone(){
                let numeroTelefone = document.getElementById("telefone");
                if(numeroTelefone.value != ""){
                    //Array telefones para apresentar na tabela
                    this.corposTelefone.push({"id": this.idTelefone, "valor": [numeroTelefone.value]});
                    //Array telefones que serão enviados para o back
                    this.telefonesEnviar.push({"TelefoneId": this.idTelefone, "TelefoneContato": numeroTelefone.value, "Ativo": true});

                    numeroTelefone.value = "";
                    this.idTelefone = 0;
                }
                else{
                    M.Toast.dismissAll();
                    M.toast({html: "Informe o telefone.", classes: 'rounded'});
                }
            },

            editaTelefone(obj){
                this.idTelefone = obj.id;
                let telefoneEdicao = obj.valor[0];
                let numeroTelefone = document.getElementById("telefone");
                numeroTelefone.value = telefoneEdicao;

                document.getElementById("lblTelefone").classList.add("active");

                this.excluirTelefone(obj, 2);
            },

            excluirTelefone(obj, tipo=1){
                let novaListaMostrar = this.corposTelefone.filter(telefone => {
                    return telefone.valor[0] != obj.valor[0];
                });

                this.corposTelefone = novaListaMostrar;

                let novaListaEnviar = this.telefonesEnviar.filter(telefone => {
                    return telefone.TelefoneContato != obj.valor[0];
                });

                this.telefonesEnviar = novaListaEnviar;

                if(tipo == 1 && obj.id != 0){
                    this.telefonesEnviar.push({"TelefoneId": obj.id, "TelefoneContato": obj.valor[0], "Ativo": false});
                }
            },

            adicionaEmail(){
                let email = document.getElementById("email");
                if(email.value != ""){
                    if(email.classList.length == 2 && email.classList[1] == "valid"){
                        //Array emails para apresentar na tabela
                        this.corposEmail.push({"id": this.idEmail, "valor": [email.value]});
                        //Array emails que serão enviados para o back
                        this.emailsEnviar.push({"EmailId": this.idEmail, "EmailContato": email.value, "Ativo": true});
                        
                        email.value = "";                
                        this.idEmail = 0;
                        email.classList.remove("valid");
                    }
                    else{
                        M.Toast.dismissAll();
                        M.toast({html: "E-mail inválido.", classes: 'rounded'});
                    }
                }
                else{
                    M.Toast.dismissAll();
                    M.toast({html: "Informe o e-mail.", classes: 'rounded'});
                }
            },

            editaEmail(obj){
                this.idEmail = obj.id;
                let emailEdicao = obj.valor[0];
                let email = document.getElementById("email");
                email.value = emailEdicao;

                document.getElementById("lblEmail").classList.add("active");

                this.excluirEmail(obj, 2)
            },

            excluirEmail(obj, tipo=1){
                let novaListaMostrar = this.corposEmail.filter(email => {
                    return email.valor[0] != obj.valor[0];
                });

                this.corposEmail = novaListaMostrar;

                let novaListaEnviar = this.emailsEnviar.filter(email => {
                    return email.EmailContato != obj.valor[0];
                });

                this.emailsEnviar = novaListaEnviar;

                if(tipo == 1 && obj.id != 0){
                    this.emailsEnviar.push({"EmailId": obj.id, "EmailContato": obj.valor[0], "Ativo": false});
                }
            },

            adicionaContato(){
                let rotas = this.$router;
                let agendaServico = new AgendaServico();

                let nome = document.getElementById("nome").value;

                if(nome != ""){
                    let contato = {
                        "ContatoId": 0,
                        "Nome": nome,
                        "Emails": this.emailsEnviar,
                        "Telefones": this.telefonesEnviar 
                    }
                    
                    if(this.idContato){
                        contato.ContatoId = this.idContato;     
                        agendaServico.put(contato)
                            .then(res => {
                                M.Toast.dismissAll();
                                M.toast({html: res, classes: 'rounded'});

                                rotas.push({ name: 'home' });
                            });
                    }
                    else{
                        agendaServico.post(contato)
                            .then(res => {
                                M.Toast.dismissAll();
                                M.toast({html: res, classes: 'rounded'});

                                rotas.push({ name: 'home' });
                            });
                    }
                }
                else{
                    M.Toast.dismissAll();
                    M.toast({html: "Informe o Nome do Contato.", classes: 'rounded'});
                }
            }
        },

        data(){
            return{
                idTelefone: 0,
                idEmail: 0,
                idContato: this.$route.params.id,
                emailsEnviar: [],
                telefonesEnviar: [],

                //Tabela Telefone
                titulosTelefone: ['Telefone'],
                corposTelefone: [],
                
                //Tabela Email
                titulosEmail: ['E-mail'],
                corposEmail: [],

                opcao: "Editar"
            }
        },

        created(){
            if(this.idContato){
                let agendaServico = new AgendaServico();
                agendaServico.getById(this.idContato)
                    .then(dados => {
                        dados.Emails.forEach(email => {
                            this.corposEmail.push({"id": email.EmailId, "valor": [email.EmailContato]});
                        });

                        dados.Telefones.forEach(telefone => {
                            this.corposTelefone.push({"id": telefone.TelefoneId, "valor": [telefone.TelefoneContato]});
                        });
                        document.getElementById("nome").value = dados.Nome;
                        document.getElementById("lblNome").classList.add("active");
                    });
            }
        }
    }
</script>

<style>
    #cardEmail{
       overflow-y:auto;
       overflow-x: hidden;
       height: 311px;
    }
    #cardTelefone{
       overflow-y:auto;
       overflow-x: hidden;
       height: 311px; 
    }
    .btnAdd{
        margin-top: 25px;
    }
    @media only screen and (min-width: 992px){
        #nome{
            font-size: 40px;
        }
    }
</style>