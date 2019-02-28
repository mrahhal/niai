<template>
  <div>
    <niai-search :loading="loading" @input="onSearch" ref="search"></niai-search>

    <div style="margin-top: 20px"></div>

    <div class="similar-section similar-kanji">
      <template v-for="kanji in kanjis">
        <div class="similar-list-container" v-if="kanji.similar.length" :key="kanji.character">
          <kanji-card-list :kanjis="[kanji, ...kanji.similar]"></kanji-card-list>
        </div>
      </template>
    </div>

    <div class="text-2" v-if="!kanjis.length">
      Just start typing to search.
      <br>For example, type
      <a @click="setSearchValue('枝方寄')">枝方寄</a> to lookup several kanjis at the same time!
    </div>
  </div>
</template>

<script lang="ts" src="./Home.ts"></script>
<style lang="scss" scoped src="./Home.scss"></style>
