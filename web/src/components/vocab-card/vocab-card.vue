<template>
  <div class="card vocab-card">
    <div class="vocab-card-top">
      <div>
        <div class="vocab-card-kanji">{{vocab.kanji}}</div>
        <div>{{vocab.kana}}</div>
      </div>
      <div class="flex-1"></div>
      <meta-list :frequency="vocab.frequency"></meta-list>
    </div>
    <div>
      <div class="card-label">Meanings</div>
      <div>{{vocab.meanings.join(', ')}}</div>
    </div>
    <div class="flex-1"></div>
    <div class="card-footer vocab-card-footer">
      <div class="label-list mt-1">
        <div
          class="label tooltipped tooltipped-n"
          v-for="tag in vocab.tags"
          :aria-label="tag.value"
          :key="tag.key"
        >{{tag.key}}</div>
      </div>
    </div>
  </div>
</template>

<script lang="ts" src="./vocab-card.ts"></script>
<style lang="scss" scoped src="./vocab-card.scss"></style>
