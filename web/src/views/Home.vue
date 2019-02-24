<template>
  <div>
    <niai-search @input="onSearch"></niai-search>

    <div style="margin-top: 10px"></div>

    <template v-for="kanji in kanjis">
      <div v-if="kanji.similar.length" :key="kanji.character" style="margin-top: 30px">
        <div style="font-size: 30px">{{kanji.character}}</div>
        <kanji-card-list :kanjis="kanji.similar"></kanji-card-list>
      </div>
    </template>
  </div>
</template>

<script lang="ts" src="./Home.ts"></script>
