<template>
  <div class="meaning-list">
    <a
      class="plain-link"
      v-for="(meaning, index) in meanings"
      :key="index"
      @click="$emit('navigateTo', meaning)"
    >{{meaning}}</a>
  </div>
</template>

<script lang="ts" src="./meaning-list.ts"></script>

<style lang="scss" scoped>
.meaning-list {
  > a {
    &:not(:last-child)::after {
      content: ", ";
    }
  }
}
</style>
