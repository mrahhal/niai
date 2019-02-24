<template>
  <div class="niai-search">
    <input
      ref="input"
      placeholder="Start typing to search"
      @input="emitValue"
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
  border-bottom: 2px solid var(--color-separator);
  background: var(--color-fg);
  outline: none;
  width: 100%;
  font-size: 20px;

  &:focus {
    border-bottom-color: var(--color-primary);
  }
}
</style>
