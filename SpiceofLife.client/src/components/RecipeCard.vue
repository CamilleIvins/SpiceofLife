<template>
    <div v-if="recipe.archived == false" class="component my-2">
        <div class="recipe-teaser position-relative elevation-4 rounded">
            <img :src="recipe.img" alt="">
            <div class="frosted-card text-light p-1">
                <p class="fs-3 my-0 ps-1"> {{ recipe.title }} </p>
                <p class="my-0 ps-1">{{ recipe.instructions }}</p>
                <p class="my-0 pe-1 text-end">{{ recipe.category }}</p>
                <!-- ⬆️ this will be moved elsewhere -->
            </div>

        </div>
    </div>
    <!-- ARCHIVED VIEW -->
    <div v-else class="component my-2">
        <div class="recipe-archived position-relative">
            <img :src="recipe.img" alt="">
            <div class="frosted-card text-dark p-1">

                <p v-if="recipe.archived == true" class="bg-danger ps-2">OWNER VIEW ONLY</p>
            </div>

        </div>
    </div>
</template>


<script>
import { Recipe } from '../models/Recipe.js';

export default {
    props: { recipe: { type: Recipe || Object, required: true } },

    setup() {
        return {}
    }
};
</script>


<style lang="scss" scoped>
.recipe-teaser {
    img {
        border-radius: 5px;
        height: 35vh;
        width: 100%;
        object-fit: cover;
        object-position: center;
    }
}

.frosted-card {
    backdrop-filter: blur(5px);
    background-color: rgba(145, 147, 150, 0.455);
    border-bottom-left-radius: 5px;
    border-bottom-right-radius: 5px;
    bottom: 0;
    position: absolute;
    width: 100%;
}



// for archived
.recipe-archived {
    img {
        border-radius: 5px;
        height: 30vh;
        width: 100%;
        object-fit: cover;
        object-position: center;
        filter: grayscale(90%)
    }
}
</style>