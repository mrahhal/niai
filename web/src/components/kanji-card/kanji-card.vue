<template>
  <div class="kanji-card">
    <div class="kanji-card-character">{{kanji.character}}</div>
    <div class="kanji-card-meaning">{{kanji.meanings.join(', ')}}</div>
    <div class="kanji-card-reading">
      {{kanji.onyomi}}
      <br>
      {{kanji.kunyomi}}
    </div>
  </div>
</template>

<script lang="ts" src="./kanji-card.ts"></script>
<style lang="scss" scoped src="./kanji-card.scss"></style>
