<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center bg-synth">
    <!-- <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo"> -->
    <!-- <h1 class="my-5 bg-dark text-light p-3 rounded d-flex align-items-center neon">
      <span class="mx-2 text-white">Click to see tasks</span> -->
    <!-- </h1> -->
  </div>
</template>

<script>
export default {
  name: 'Home'
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
}
.neon:hover {
  background-color: #f038ff;
  -webkit-box-shadow: 10px 10px 99px 6px rgba(240, 56, 255, 1);
  -moz-box-shadow: 10px 10px 99px 6px rgba(240, 56, 255, 1);
  box-shadow: 10px 10px 99px 6px rgba(240, 56, 255, 1);
}
</style>
