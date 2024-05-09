<script setup>
const props = defineProps({
  system: {
    type: Object,
    required: true
  }
})
</script>

<template>
    <div>
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

                    <a class="icon-link" data-bs-toggle="modal" data-bs-target="#exampleModal">
                        <i class="bi bi-arrows-angle-expand"></i>

                    </a>

                    <i class="bi bi-controller"></i>


                    <i class="bi bi-heart heart"></i>
                </div>
            </div>
        </div>


<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-fullscreen">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
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