<template>
  <div class="kanji-card-list">
    <kanji-card v-for="kanji in kanjis" :kanji="kanji" :key="kanji.character"></kanji-card>
  </div>
</template>

<script lang="ts" src="./kanji-card-list.ts"></script>
<style lang="scss" scoped src="./kanji-card-list.scss"></style>
