<template>
  <div class="niai-search">
    <input @input="$emit('input', $event.target.value)">
    <svg-spinner></svg-spinner>
  </div>
</template>

<script lang="ts" src="./niai-search.ts"></script>

<style scoped lang="scss">
.niai-search {
  position: relative;
}

input {
  padding: 15px;
  border: none;
  border-bottom: 1px dashed var(--color-bg-3);
  background: var(--color-bg-2);
  outline: none;
  width: 100%;
}

.svg-spinner {
  position: absolute;
  height: 30px;
  width: 30px;
  right: 5px;
  top: 5px;
}
</style>
