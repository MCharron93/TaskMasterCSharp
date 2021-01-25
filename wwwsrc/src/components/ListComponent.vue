<template>
  <div class="list card border border-primary shadow-lg">
    <div class="bg-dark text-secondary p-1 border border-bottom border-primary d-flex justify-content-between">
      <h3 class="mx-2">
        {{ listProp.title }}
      </h3>
      <span @click="deleteList()">&times;</span>
    </div>
    <div class="body bg-dark text-success p-2 d-flex">
      <!-- NOTE Insert tasks here -->
      <input type="text" placeholder="Create new task" class="form-control bg-dark text-success border border-success">
      <button class="btn btn-outline-success neon-two" type="button" id="button-addon2">
        &#43;
      </button>
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
.neon-two:hover {
  background-color: #b9e769;
  -webkit-box-shadow: 10px 10px 99px 6px rgba(185, 231, 105, 1);
  -moz-box-shadow: 10px 10px 99px 6px rgba(185, 231, 105, 1);
  box-shadow: 10px 10px 99px 6px rgba(185, 231, 105, 1);
}
</style>
