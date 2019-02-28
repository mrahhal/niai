<template>
  <div id="app" :class="['theme-' + theme, {'sidebar-expanded': expanded}]">
    <app-sidebar @theme-toggled="toggleTheme"></app-sidebar>
    <div id="app-view">
      <div id="mobile-navbar">
        <div class="icon-btn" @click="toggleExpansion">
          <svg-bars></svg-bars>
        </div>
      </div>
      <router-view/>
    </div>
  </div>
</template>

<script lang="ts" src="./App.ts"></script>
<style lang="scss" src="./App.scss"></style>
