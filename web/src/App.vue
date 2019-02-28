<template>
  <div id="app" :class="['theme-' + theme, {'sidebar-expanded': expanded}]">
    <div id="app-sidebar">
      <div class="sidebar-main">
        <router-link to="/similar">Niai</router-link>
        <router-link to="/about">About</router-link>
      </div>
      <div class="sidebar-footer">
        <div class="theme-btn">
          <div class="icon-btn" @click="toggleTheme">
            <svg-sun v-if="theme == 'dark'"></svg-sun>
            <svg-moon v-if="theme == 'light'"></svg-moon>
          </div>
        </div>
      </div>
    </div>
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
