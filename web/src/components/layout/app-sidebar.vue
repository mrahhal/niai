<template>
  <div id="app-sidebar">
    <div class="sidebar-main">
      <router-link to="/similar">Niai</router-link>
      <router-link to="/about">About</router-link>
      <a href="mailto://m.r992@hotmail.com" class="tooltipped tooltipped-n" aria-label="Suggestions/Feedback/Bugs">Feedback</a>
    </div>
    <div class="sidebar-footer">
      <div class="theme-btn">
        <div class="icon-btn" @click="$emit('theme-toggled')">
          <svg-sun v-if="theme == 'dark'"></svg-sun>
          <svg-moon v-if="theme == 'light'"></svg-moon>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts" src="./app-sidebar.ts"></script>
<style lang="scss" scoped src="./app-sidebar.scss"></style>
