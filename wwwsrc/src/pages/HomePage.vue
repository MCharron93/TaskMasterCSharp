<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center bg-synth">
    <!-- NOTE Insert component for tasks here -->
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { accountService } from '../services/AccountService'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    onMounted(async() => {
      await accountService.getLists()
    })
    return {
      lists: computed(() => AppState.lists)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
.bg-synth{
  background-image: url('https://i.pinimg.com/originals/a3/b0/72/a3b072c9822be6e890b5758ce39f9e36.jpg');
  background-position: center;
}
.neon:hover {
  background-color: #f038ff;
  -webkit-box-shadow: 10px 10px 99px 6px rgba(240, 56, 255, 1);
  -moz-box-shadow: 10px 10px 99px 6px rgba(240, 56, 255, 1);
  box-shadow: 10px 10px 99px 6px rgba(240, 56, 255, 1);
}
</style>
