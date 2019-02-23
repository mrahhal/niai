<template>
  <div id="app">
    <div id="app-nav">
      <router-link to="/">Niai</router-link>
      <router-link to="/about">About</router-link>
    </div>
    <div id="app-view">
      <router-view/>
    </div>
  </div>
</template>

<style lang="scss" src="./App.scss"></style>
