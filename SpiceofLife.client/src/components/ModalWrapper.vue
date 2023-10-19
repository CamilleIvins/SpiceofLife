<template>
    <!-- Modal trigger button -->
    <button v-if="showButton" type="button" class="btn btn-outline-light frosted-card btn-lg" data-bs-toggle="modal"
        :data-bs-target="`#${id}`">
        <slot name="button">
            open {{ id }} modal
        </slot>
    </button>

    <!-- Modal Body -->
    <!-- if you want to close by clicking outside the modal, delete the last endpoint:data-bs-backdrop and data-bs-keyboard -->
    <div class="modal " :id="id" tabindex="-1" data-bs-backdrop="static" data-bs-keyboard="false" role="dialog"
        aria-labelledby="modalTitleId" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <slot name="header">
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </slot>
                </div>
                <div class="modal-body text-dark">
                    <slot name="body">

                    </slot>
                </div>
            </div>
        </div>
    </div>
</template>

<!-- Optional: Place to the bottom of scripts -->
<script>


export default {
    props: { id: { type: String, required: true }, showButton: { type: Boolean, default: true }, btnColor: { type: String, default: 'primary' } },
    setup() {

        return {}
    }
};
</script>
<!-- // const myModal = new bootstrap.Modal(document.getElementById('modalId'), options) -->

<style lang="scss" scoped>
.frosted-card {
    backdrop-filter: blur(3px);
    background-color: rgba(145, 147, 150, 0.455);
}

.frosted-card:hover {
    backdrop-filter: blur(3px);
    background-color: rgba(218, 218, 218, 0.925);
    border: 0;
    box-shadow: 0 0 10px 2px rgb(218, 218, 218);
    transition: .35s ease;
}
</style>