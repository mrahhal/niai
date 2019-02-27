<template>
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 66 66" class="niai-icon svg-spinner">
    <circle
      class="path"
      fill="none"
      stroke-width="6"
      stroke-linecap="round"
      stroke="currentColor"
      cx="33"
      cy="33"
      r="30"
    ></circle>
  </svg>
</template>

<style lang="scss" scoped>
$offset: 187;
$duration: 1.4s;

.svg-spinner {
  animation: rotator $duration linear infinite;

  .path {
    stroke-dasharray: $offset;
    stroke-dashoffset: 0;
    transform-origin: center;
    animation: dash $duration ease-in-out infinite;
  }
}

@keyframes rotator {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(270deg);
  }
}

@keyframes dash {
  0% {
    stroke-dashoffset: $offset;
  }
  50% {
    stroke-dashoffset: $offset/4;
    transform: rotate(135deg);
  }
  100% {
    stroke-dashoffset: $offset;
    transform: rotate(450deg);
  }
}
</style>

