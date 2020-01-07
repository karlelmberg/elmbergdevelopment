<template>
    <div id="app">
        {{ message }}
    </div>
</template>

<script>
   
 export default {
  data() {
    return {
      message: 'App component',
    };
  },
};
</script>

<style>
    #app {
        font-size: 30px;
        font-family: 'Roboto', sans-serif;
        color: red;
    }
</style>
