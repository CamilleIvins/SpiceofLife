<template>
    <div v-if="recipe" class="container-fluid">
        <section class="row">
            <div class="col-12 frosted-card px-0">
                <div class="row">
                    <img :src="recipe.img" class="cover-img">
                </div>
            </div>

        </section>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { useRoute } from 'vue-router';

export default {
    setup() {
        const route = useRoute()


        return {

            recipe: computed(() => AppState.activeRecipe)
        }
    }
};
</script>


<style lang="scss" scoped>
.frosted-card {
    backdrop-filter: blur(7px);
    background-color: rgba(218, 218, 218, 0.455);
    border-radius: 15px;
}
</style>