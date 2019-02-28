<template>
  <div id="app-sidebar">
    <div class="sidebar-main">
      <router-link to="/similar">Niai</router-link>
      <router-link to="/about">About</router-link>
    </div>
    <div class="sidebar-footer">
      <div class="theme-btn">
        <div class="icon-btn" @click="$emit('theme-toggled')">
          <svg-sun v-if="theme == 'dark'"></svg-sun>
          <svg-moon v-if="theme == 'light'"></svg-moon>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { getTheme, themeChanges } from "../../services/theme";
import { Component, Vue } from "vue-property-decorator";

@Component
export default class AppSidebar extends Vue {
  private theme = getTheme();

  created() {
    themeChanges.subscribe(theme => {
      this.theme = theme;
    });
  }
}
</script>

<style scoped lang="scss">
#app-sidebar {
  background: var(--color-fg);
  width: var(--sidebar-width);
  flex-shrink: 0;
  display: flex;
  flex-flow: column;
  border-right: 1px solid var(--color-separator);
  position: absolute;
  height: 100%;
  transition: transform ease-in-out 0.1s;
  transform: translateX(calc(-1 * var(--sidebar-width)));

  a {
    @include flex-center();
    @include anchor-unstyled();
    padding: 10px 20px;
    opacity: 0.6;
    font-weight: bold;

    &:not(:last-child) {
      border-bottom: 1px solid var(--color-separator);
    }

    &:hover {
      opacity: 1;
    }

    &.router-link-active {
      opacity: 1;
      color: var(--color-primary-500);
    }
  }

  .sidebar-main {
    flex: 1;
  }
}

.sidebar-expanded {
  #app-sidebar {
    transform: none;
  }
}

@include breakpoint(md) {
  #app-sidebar {
    position: static;
    transform: none;
  }
}
</style>
