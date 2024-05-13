<script setup>
const props = defineProps({
  setting: {
    type: Object,
    required: true
  }
})
</script>

<template>
    <div>
        <div>{{ setting.name }}</div>
    </div>
</template>

<style scoped>

</style>