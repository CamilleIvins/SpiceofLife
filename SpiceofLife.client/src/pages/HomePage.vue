<template>
  <section class="container-fluid">
    <section class="row">
      <div class="">
        <img class="banner elevation-4"
          src="https://images.unsplash.com/photo-1596040033229-a9821ebd058d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80">
      </div>
    </section>
    <div>
      <NewRecipeForm />
    </div>
    <section class="row my-3 justify-content-around">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4 col-12 px-4">
        <!-- {{ recipe }} -->
        <RecipeCard :recipe="recipe" />
      </div>
    </section>

  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { recipesService } from '../services/RecipesService.js'
import RecipeCard from '../components/RecipeCard.vue';
import NewRecipeForm from '../components/NewRecipeForm.vue';


export default {
  setup() {
    onMounted(() => {
      getRecipes();
    });
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
        logger.log("HomePage recipe Get");
      }
      catch (error) {
        Pop.error(error);
      }
    }
    return {
      // this will look like Tower when filters are added
      recipes: computed(() => AppState.recipes),
    };
  },
  components: { RecipeCard, NewRecipeForm }
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
  height: 15vh;
  width: 100%;
  object-fit: cover;
  object-position: center;
  // elevation-2 settings
  box-shadow: 0 3px 3px -1px rgba(205, 205, 205, 0.2),
    0 5px 6px 0 rgba(205, 205, 205, 0.14),
    0 1px 8px 0 rgba(205, 205, 205, 0.12);
}

@media screen and (min-width: 768px) {
  img.banner {
    height: 35vh;
    width: 100%;
    object-fit: cover;
    object-position: center;
    // elevation-2 settings
    box-shadow: 0 3px 3px -1px rgba(205, 205, 205, 0.2),
      0 5px 6px 0 rgba(205, 205, 205, 0.14),
      0 1px 8px 0 rgba(205, 205, 205, 0.12);
  }
}
</style>
