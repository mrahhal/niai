<template>
  <div class="niai-search" :class="{ loading: loading }">
    <svg-search></svg-search>
    <svg-spinner></svg-spinner>
    <input ref="input" placeholder="Start typing to search" @input="emitValue">
  </div>
</template>

<script lang="ts" src="./niai-search.ts"></script>

<style scoped lang="scss">
.niai-search {
  position: relative;

  svg {
    fill: currentColor;
    width: 25px;
    height: 25px;
    position: absolute;
    left: 10px;
    top: 12px;
    transition: opacity linear .1s;
  }

  .svg-spinner {
    opacity: 0;
  }

  &.loading {
    .svg-search {
      opacity: 0;
    }

    .svg-spinner {
      opacity: 1;
    }
  }
}

input {
  padding: 15px;
  padding-left: 45px;
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
