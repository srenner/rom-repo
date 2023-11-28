<script setup>
const props = defineProps({
  system: {
    type: Object,
    required: true
  }
})
</script>

<template>
    <div class="card mt-3 mb-3">
        <div class="card-header">
            <div class="d-flex">
                <div class="flex-grow-1">
                    <span>{{system.name}}</span>
                </div>
                <div>
                    
                </div>
            </div>
        </div>
        <div class="card-body">
            <span>832 roms, 732 verified</span>
        </div>
        <div class="card-footer">
            
            <div class="d-flex justify-content-between">

                <i class="bi bi-arrows-angle-expand"></i>

                <i class="bi bi-controller"></i>


                <i class="bi bi-heart heart"></i>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .heart {
        color: var(--highlight-color);
        opacity: 0.25;
    }
    .heart-fill {
        color: var(--highlight-color);
        opacity: 0.5;
    }
</style>