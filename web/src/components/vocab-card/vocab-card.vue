<template>
  <div class="card vocab-card" :class="{'card-faded': !vocab.frequency}">
    <div class="vocab-card-top">
      <div>
        <div class="vocab-card-kanji">{{vocab.kanji}}</div>
        <a class="plain-link" @click="$emit('navigateTo', vocab.kana)">{{vocab.kana}}</a>
      </div>
      <div class="flex-1"></div>
      <meta-list :frequency="vocab.frequency"></meta-list>
    </div>
    <div>
      <div class="card-label">Meanings</div>
      <meaning-list :meanings="vocab.meanings" @navigateTo="$emit('navigateTo', $event)"></meaning-list>
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
