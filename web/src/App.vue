<template>
  <div id="app" :class="['theme-' + theme]">
    <div id="app-nav">
      <div class="nav-main">
        <router-link to="/similar">Niai</router-link>
        <router-link to="/about">About</router-link>
      </div>
      <div class="nav-footer">
        <div class="theme-btn">
          <div class="icon-btn" @click="toggleTheme">
            <svg-sun v-if="theme == 'dark'"></svg-sun>
            <svg-moon v-if="theme == 'light'"></svg-moon>
          </div>
        </div>
      </div>
    </div>
    <div id="app-view">
      <router-view/>
    </div>
  </div>
</template>

<script lang="ts" src="./App.ts"></script>
<style lang="scss" src="./App.scss"></style>
