<template>
  <div class="list card border border-primary shadow-lg">
    <div class="bg-dark text-secondary p-1 border border-bottom border-primary d-flex justify-content-between">
      <h3 class="mx-2">
        {{ listProp.title }}
      </h3>
      <span @click="deleteList()">&times;</span>
    </div>
    <div class="body bg-dark text-success p-2">
      {{ listProp.body }}
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { listService } from '../services/ListService'
export default {
  name: 'List',
  props: {
    listProp: Object
  },
  setup(props) {
    return {
      list: computed(() => props.listProp),
      deleteList() {
        listService.deleteList(props.listProp.id)
      }
    }
  }

}
</script>

<style>

</style>
