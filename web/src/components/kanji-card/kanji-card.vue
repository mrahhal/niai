<template>
  <div class="card kanji-card" :class="{'original-item': isOriginal}">
    <div class="kanji-card-top">
      <div class="kanji-card-character">{{kanji.character}}</div>
      <div class="kanji-card-links">
        <a
          class="kanji-card-link tooltipped tooltipped-n"
          :href="jishoHref"
          target="_blank"
          aria-label="Jisho"
        >
          <img class="kanji-card-link-img a-bit-smaller" src="@/assets/jisho.png">
        </a>

        <a
          class="kanji-card-link tooltipped tooltipped-n"
          v-if="kanji.waniKaniLevel"
          :href="waniKaniHref"
          target="_blank"
          aria-label="WaniKani"
        >
          <img class="kanji-card-link-img" src="@/assets/wanikani.png">
          <div class="kanji-card-link-text">{{kanji.waniKaniLevel}}</div>
        </a>
      </div>
      <meta-list :frequency="kanji.frequency" :grade="kanji.grade"></meta-list>
    </div>
    <div>
      <div class="card-label">Meanings</div>
      <div class="kanji-card-meaning">{{kanji.meanings.join(', ')}}</div>

      <div class="card-label">音読み</div>
      <div class="kanji-card-reading-on">{{kanji.onyomi}}</div>

      <div class="card-label">訓読み</div>
      <div class="kanji-card-reading-kun">{{kanji.kunyomi}}</div>
    </div>
    <div class="flex-1"></div>
    <div class="card-footer kanji-card-footer">
      <div class="label-list mt-1">
        <div class="label" v-if="kanji.jlpt">N{{kanji.jlpt}}</div>
        <div
          class="label tooltipped tooltipped-n"
          v-for="tag in kanji.tags"
          :aria-label="tag.value"
          :key="tag.key"
        >{{tag.key}}</div>
      </div>
    </div>
  </div>
</template>

<script lang="ts" src="./kanji-card.ts"></script>
<style lang="scss" scoped src="./kanji-card.scss"></style>
