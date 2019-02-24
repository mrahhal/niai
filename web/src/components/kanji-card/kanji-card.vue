<template>
  <div class="kanji-card">
    <div class="kanji-card-top">
      <div class="kanji-card-character">{{kanji.character}}</div>
      <div style="flex: 1"></div>
      <div class="label">{{kanji.frequency}}</div>
    </div>
    <div class="kanji-card-meaning mt-1">{{kanji.meanings.join(', ')}}</div>
    <div class="kanji-card-reading mt-1">
      <div class="kanji-card-reading-on">{{kanji.onyomi}}</div>
      <div class="kanji-card-reading-kun">{{kanji.kunyomi}}</div>
    </div>
    <div class="label-list mt-1">
      <div class="label" v-for="tag in kanji.tags" :title="tag.value" :key="tag.key">{{tag.key}}</div>
    </div>
  </div>
</template>

<script lang="ts" src="./kanji-card.ts"></script>
<style lang="scss" scoped src="./kanji-card.scss"></style>
