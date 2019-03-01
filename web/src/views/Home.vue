<template>
  <div>
    <niai-search :loading="loading" @input="onSearch" ref="search"></niai-search>

    <div style="margin-top: 20px"></div>

    <template v-if="result">
      <div class="similar-section similar-kanji">
        <template v-for="kanji in kanjis">
          <div class="similar-list-container" v-if="kanji.similar.length" :key="kanji.character">
            <card-list>
              <kanji-card
                v-for="kanji in [kanji, ...kanji.similar]"
                :kanji="kanji"
                :key="kanji.character"
              ></kanji-card>
            </card-list>
          </div>
        </template>
      </div>

      <div class="similar-section similar-homonyms" v-if="homonyms.length">
        <div class="similar-section-name">Homonyms</div>
        <card-list>
          <vocab-card v-for="(homonym, index) in homonyms" :vocab="homonym" :key="index"></vocab-card>
        </card-list>
      </div>

      <div class="similar-section similar-synonyms" v-if="synonyms.length">
        <div class="similar-section-name">Synonyms</div>
        <card-list>
          <vocab-card v-for="(synonym, index) in synonyms" :vocab="synonym" :key="index"></vocab-card>
        </card-list>
      </div>
    </template>

    <div class="text-2" v-else>
      Just start typing to search for similar Kanjis, homonyms, and synonyms!
      <br>
      <br>Lookup several kanjis at the same time! -
      <a @click="setSearchValue('枝方寄')">枝方寄</a>
      <br>Lookup homonyms (same reading, different meaning) -
      <a @click="setSearchValue('かえる')">かえる</a>
      <br>Lookup synonyms (similar meaning) -
      <a @click="setSearchValue('love')">love</a>
    </div>
  </div>
</template>

<script lang="ts" src="./Home.ts"></script>
<style lang="scss" scoped src="./Home.scss"></style>
