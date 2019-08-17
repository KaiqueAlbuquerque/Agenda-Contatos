<template>
    <table class="highlight centered">
        <thead>
            <tr>
                <th v-for="titulo of titulos" :key="titulo">{{ titulo }}</th>
                <th>Ações</th>
            </tr>
        </thead>

        <tbody>
            <tr v-for="corpo of corpos" :key="corpo.id">
                <td v-for="valor of corpo.valor" :key="valor">{{ valor }}</td>
                <td>
                    <span class="link" v-on:click="alterar(corpo)">{{opcao}}</span>
                    <span id="divisor">|</span>
                    <span class="link" v-on:click="excluir(corpo)">Excluir</span>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<script>
export default {
    props: ['titulos', 'corpos', 'opcao'],

    methods:{
        alterar (obj) {
            this.$emit('alterar', obj);
        },

        excluir(obj){
            this.$emit('excluir', obj);
        }
    }
}
</script>

<style scoped>
    .link{
        color: #039be5;
        cursor: pointer;
    }

    @media(max-width: 600px){
        #divisor{
            display: none;
        }
    }
</style>
