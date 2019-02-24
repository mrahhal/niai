<template>
  <div>
    <niai-search :loading="loading" @input="onSearch" ref="search"></niai-search>

    <div style="margin-top: 20px"></div>

    <template v-for="(kanji, index) in kanjis">
      <div v-if="kanji.similar.length" :key="index" style="margin-bottom: 30px">
        <div style="font-size: 30px">{{kanji.character}}</div>
        <kanji-card-list :kanjis="kanji.similar"></kanji-card-list>
      </div>
    </template>

    <div class="text-2" v-if="!kanjis.length">
      Just start typing to search.
      <br>For example, type
      <a @click="setSearchValue('枝方談寄')">枝方寄</a> to lookup several kanjis at the same time!
    </div>
  </div>
</template>

<script lang="ts" src="./Home.ts"></script>
