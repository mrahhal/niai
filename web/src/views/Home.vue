<template>
  <div>
    <niai-search @input="onSearch" ref="search"></niai-search>

    <div style="margin-top: 20px"></div>

    <template v-for="kanji in kanjis">
      <div v-if="kanji.similar.length" :key="kanji.character" style="margin-bottom: 30px">
        <div style="font-size: 30px">{{kanji.character}}</div>
        <kanji-card-list :kanjis="kanji.similar"></kanji-card-list>
      </div>
    </template>

    <div class="text-2" v-if="!kanjis.length">
      Just start typing to search.
      <br>For example, type
      <a @click="onSampleClick('枝談')">枝談</a> to lookup several kanjis together!
    </div>
  </div>
</template>

<script lang="ts" src="./Home.ts"></script>
