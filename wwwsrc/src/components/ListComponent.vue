<template>
  <div class="list text-light">
    {{ listProp.title }}
  </div>
</template>

<script>
import { computed } from 'vue'

export default {
  name: 'List',
  props: {
    listProp: Object
  },
  setup(props) {
    return {
      list: computed(() => props.listProp)
    }
  }

}
</script>

<style>

</style>
