<template>
  <div class="vocab-contextual-meaning mb-2">
    <div>
      {{index}}.
      <a class="plain-link" @click="$emit('navigateTo', meaning.kana)">{{meaning.kana}}</a>
      <meaning-list :meanings="meaning.meanings" @navigateTo="$emit('navigateTo', $event)"></meaning-list>
    </div>
    <div class="label-list">
      <div
        class="label tooltipped tooltipped-n"
        v-for="tag in meaning.tags"
        :aria-label="tag.value"
        :key="tag.key"
      >{{tag.key}}</div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  props: ["meaning", "index"]
});
</script>

