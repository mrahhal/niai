<template>
  <div class="meta-list">
    <div class="meta-list-item tooltipped tooltipped-n" v-if="frequency" aria-label="Frequency">
      <div class="meta-list-item-text">{{frequency}}</div>
      <div class="meta-list-item-icon">
        <svg-clock></svg-clock>
      </div>
    </div>

    <div class="meta-list-item tooltipped tooltipped-n" v-if="grade" aria-label="Grade">
      <div class="meta-list-item-text">{{grade}}</div>
      <div class="meta-list-item-icon">
        <svg-school></svg-school>
      </div>
    </div>
  </div>
</template>

<script lang="ts" src="./meta-list.ts"></script>

<style lang="scss" scoped>
.meta-list {
  display: flex;
  flex-flow: column;
  align-items: flex-end;
}

.meta-list-item {
  display: flex;
  font-size: var(--font-size-sm);
  align-items: center;

  svg {
    width: 15px;
    height: 15px;
  }
}

.meta-list-item-text {
  margin-right: 5px;
}

.meta-list-item-icon {
  @include flex-center();
}
</style>

