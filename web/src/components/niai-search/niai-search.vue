<template>
  <div class="niai-search" :class="{ loading: loading, 'has-text': hasText }">
    <svg-search></svg-search>
    <svg-spinner></svg-spinner>
    <div class="close-btn icon-btn" @click="clear">
      <svg-close-circle></svg-close-circle>
    </div>
    <input ref="input" placeholder="Start typing to search" @input="emitValue" v-model="q">
  </div>
</template>

<script lang="ts" src="./niai-search.ts"></script>

<style scoped lang="scss">
.niai-search {
  position: relative;

  > .close-btn {
    padding: 0;
  }

  > svg,
  > .close-btn {
    position: absolute;
    left: 10px;
    top: 12px;
    transition: opacity linear 0.1s;
  }

  svg {
    fill: currentColor;
    width: 25px;
    height: 25px;
  }

  .svg-spinner,
  .close-btn {
    opacity: 0;
    pointer-events: none;
  }

  &.has-text {
    .svg-search,
    .svg-spinner {
      opacity: 0;
      pointer-events: none;
    }

    .close-btn {
      opacity: 0.6;
      pointer-events: initial;

      &:hover {
        opacity: 1;
      }
    }
  }

  &.loading {
    .svg-search,
    .close-btn {
      opacity: 0;
      pointer-events: none;
    }

    .svg-spinner {
      opacity: 1;
    }
  }
}

input {
  padding: 10px;
  padding-left: 45px;
  border: none;
  border-bottom: 2px solid var(--color-separator);
  background: var(--color-fg);
  outline: none;
  width: 100%;
  font-size: 20px;

  &:focus {
    border-bottom-color: var(--color-primary-500);
  }
}
</style>
