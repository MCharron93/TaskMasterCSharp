<template>
  <div class="account text-center bg-synth container-fluid">
    <div class="row flex-column p-4 justify-content-center text-light">
      <h1 class="">
        Welcome {{ account.name }}
      </h1>
      <div class="my-4">
        <img class="rounded m-3" :src="account.picture" alt="" />
        <p class="m-1">
          {{ account.email }}
        </p>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Account',
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
.bg-synth{
  background-image: url('https://i.pinimg.com/originals/a3/b0/72/a3b072c9822be6e890b5758ce39f9e36.jpg');
  background-position: center;
}
</style>
