<template>
  <transition-group name="kanji-card-appear" tag="div" class="kanji-card-list" appear>
    <kanji-card v-for="kanji in kanjis" :kanji="kanji" :key="kanji.character"></kanji-card>
  </transition-group>
</template>

<script lang="ts" src="./kanji-card-list.ts"></script>
<style lang="scss" scoped src="./kanji-card-list.scss"></style>
