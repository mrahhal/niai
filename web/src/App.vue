<template>
  <div id="app" :class="['theme-' + theme]">
    <div id="app-nav">
      <router-link to="/">Niai</router-link>
      <router-link to="/about">About</router-link>
    </div>
    <div id="app-view">
      <router-view/>
    </div>
  </div>
</template>

<script lang="ts" src="./App.ts"></script>
<style lang="scss" src="./App.scss"></style>
