<template>
  <div class="about-page">
    <div class="about-page-loading" v-if="loading">
      <svg-spinner></svg-spinner>
    </div>
    <template v-else>
      <div class="about-card">
        <img class="about-profile-pic" src="@/assets/mrahhal-profile.jpg">

        <div>
          Niai
          <span class="version">v{{metadata.version}}</span>
        </div>
        <div class="about-links">
          <div>
            <svg-github></svg-github>
            <a href="https://github.com/mrahhal/niai" target="_blank">GitHub</a>
          </div>
        </div>
        <hr>

        <div>
          <h4>DB Stats</h4>

          <div>Kanji: {{metadata.kanjiCount}}</div>
          <div>Vocabs: {{metadata.vocabCount}}</div>
          <div>Homonyms: {{metadata.homonymCount}}</div>
          <div>Synonyms: {{metadata.synonymCount}}</div>
        </div>
        <hr>

        <div>
          <h4>Contact</h4>

          <div>
            <a href="mailto://m.r992@hotmail.com">m.r992@hotmail.com</a>
          </div>
        </div>
      </div>
    </template>
  </div>
</template>

<script lang="ts" src="./About.ts"></script>
<style lang="scss" scoped src="./About.scss"></style>
