<template>
  <section class="container">
    <section class="row">
      <div class="">
        <img class="banner"
          src="https://images.unsplash.com/photo-1596040033229-a9821ebd058d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80">
      </div>
    </section>

  </section>
</template>

<script>
export default {
  setup() {
    return {}
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: cover;
      object-position: center;
    }
  }
}

img.banner {
  height: 35%;
  width: 100%;
  object-fit: cover;
  object-position: center;
}
</style>
