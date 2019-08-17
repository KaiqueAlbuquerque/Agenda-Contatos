<template>
  <div class="container">
    <transition name="pagina">
      <router-view></router-view>  
    </transition> 
  </div>
</template>

<script>

</script>

<style>
.pagina-enter, .pagina-leave-to{
  opacity: 0;
}
.pagina-leave-active{
  transition: opacity .2s;
}
.pagina-enter-active{
  transition: opacity 2s;
}
</style>
