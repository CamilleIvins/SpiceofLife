<template>
    <div class="component container-fluid">
        <!-- <button @click.prevent="createRecipe">
            Press to test
        </button> -->

        <form @submit.prevent="createRecipe" class="row">

            <div class="mb-1 col-6">
                <label for="recipe-title">Recipe Name</label>
                <input v-model="recipeData.name" id="recipe-name" class="form-control" type="text" minlength="5"
                    maxlength="55" placeholder="Recipe Name" required>

            </div>
            <div class="mb-1 col-6">
                <label for="recipe-title">Recipe Category</label>
                <input v-model="recipeData.category" id="recipe-category" class="form-control" type="text" minlength="3"
                    maxlength="55" placeholder="Category Name" required>

            </div>
            <div class="mb-1 col-12">
                <label class="text-dark" for="recipe-cover">Cover Image</label>
                <input v-model="recipeData.img" type="url" id="recipe-cover" class="form-control" minlength="5"
                    maxlength="250" placeholder="Recipe image URL">
            </div>
            <div class="mb-1 col-12">
                <label for="recipe-instructions" class="text-dark">Recipe Instructions</label>
                <textarea v-model="recipeData.instructions" type="number" id="recipe-instructions" class="form-control"
                    maxlength="1000" cols="30" rows="10" placeholder="Recipe Instructions"></textarea>
            </div>

        </form>

    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { logger } from '../utils/Logger.js';
export default {
    setup() {
        return {

            async createRecipe() {
                logger.log("Create button works")
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>