<template>
  <div class="card vocab-card">
    <div>{{vocab.kanji}} - {{vocab.kana}}</div>
    <div>{{vocab.meanings.join(', ')}}</div>
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
