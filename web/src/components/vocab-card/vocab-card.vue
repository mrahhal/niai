<template>
  <div class="card vocab-card" :class="{'card-faded': !vocab.frequency}">
    <div class="vocab-card-top">
      <div>
        <div class="vocab-card-kanji">{{vocab.kanji}}</div>
      </div>
      <div class="flex-1"></div>
      <meta-list :frequency="vocab.frequency"></meta-list>
    </div>
    <div>
      <div class="card-label">Meanings</div>
      <vocab-contextual-meaning
        v-for="(m, index) in meanings"
        :key="index"
        :meaning="m"
        :index="index + 1"
        @navigateTo="$emit('navigateTo', $event)"
      ></vocab-contextual-meaning>
      <div class="show-more-cont" v-if="!showExtraMeanings && extraMeanings.length">
        <a @click="showExtraMeanings = true">show more</a>
      </div>
      <div v-else-if="extraMeanings.length">
        <vocab-contextual-meaning
          v-for="(m, index) in extraMeanings"
          :key="index"
          :meaning="m"
          :index="index + shownCount + 1"
          @navigateTo="$emit('navigateTo', $event)"
        ></vocab-contextual-meaning>
      </div>
    </div>
    <div class="flex-1"></div>
  </div>
</template>

<script lang="ts" src="./vocab-card.ts"></script>
<style lang="scss" scoped src="./vocab-card.scss"></style>
