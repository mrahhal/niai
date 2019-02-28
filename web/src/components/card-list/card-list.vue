<template>
  <transition-group name="card-appear" tag="div" class="card-list" appear>
    <slot></slot>
  </transition-group>
</template>

<script lang="ts" src="./card-list.ts"></script>
<style lang="scss" scoped src="./card-list.scss"></style>
