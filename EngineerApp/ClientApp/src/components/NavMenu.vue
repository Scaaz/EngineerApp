<template>
  <header>
    <nav
      class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3"
    >
      <div class="container">
        <a class="navbar-brand"
          >Obliczanie współczynnika lepkości dynamicznej stopów metali lekkich w
          stanie stało-ciekłym</a
        >
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target=".navbar-collapse"
          aria-label="Toggle navigation"
          @click="toggle"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div
          class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse"
          v-bind:class="{ show: isExpanded }"
        >
          <ul class="navbar-nav flex-grow">
            
              <li class="nav-item">
                <router-link :to="{ name: 'Home' }" class="nav-link text-dark"
                  >Strona główna</router-link
                >
              </li>
           
          </ul>
        </div>
      </div>
    </nav>
  </header>
</template>

<style>

.nav-item
{
    
border-top:2px solid #777777;
border-right:2px solid #333333;
border-bottom:2px solid #444444;
border-left:2px solid #777777;
}
a.navbar-brand {
  white-space: normal;
  text-align: center;
  word-break: break-all;
}

html {
  font-size: 14px;
}

@media (min-width: 768px) {
  html {
    font-size: 16px;
  }
}

.box-shadow {
  box-shadow: 0 0.25rem 0.75rem rgba(0, 0, 0, 0.05);
}
</style>
<script>
export default {
  name: "NavMenu",
  data() {
    return {
      isExpanded: false,
    };
  },
  methods: {
    collapse() {
      this.isExpanded = false;
    },

    toggle() {
      this.isExpanded = !this.isExpanded;
    },
  },
};
</script>
