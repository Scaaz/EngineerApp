<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
        <img src="../assets/logo.png" />
        <p>
           Chad praca in¿ynierka, ju¿ niemal¿e gotowa
        </p>
        <p>
            Tutaj bêdzie solidny opis co wgl ta apka robi
        </p>
        <h3>Tutaj bêdzie pole do wrzucenia pliku</h3>
        
    </div>
</template>

<script>
export default {
  name: 'Home',
  props: {
    msg: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
