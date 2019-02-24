<template>
  <div class="niai-search">
    <input
      ref="input"
      placeholder="Start typing to search"
      @input="$emit('input', $event.target.value)"
    >
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
  background: var(--color-fg);
  outline: none;
  width: 100%;
  font-size: 20px;
}
</style>
