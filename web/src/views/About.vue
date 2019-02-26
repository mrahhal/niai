<template>
  <div class="about-page">
    <div class="about-card">
      <img class="about-profile-pic" src="@/assets/mrahhal-profile.jpg">

      <div>Mohammad Rahhal</div>
      <div>
        <a href="https://github.com/mrahhal" target="_blank">mrahhal</a>
      </div>
      <div>
        <a href="https://github.com/mrahhal" target="_blank">GitHub</a>
      </div>
      <div>
        <a href="https://www.wanikani.com/users/mrahhal" target="_blank">WaniKani</a>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.about-page {
  @include flex-center();
}

.about-card {
  width: 400px;
  position: relative;
  background: var(--color-fg);
  box-shadow: var(--box-shadow);
  border-radius: var(--border-radius);
  padding: 20px;
  padding-top: 70px;
  margin-top: 80px;
  text-align: center;
  border-bottom: 3px solid var(--color-primary-500);
}

.about-profile-pic {
  position: absolute;
  left: 50%;
  top: 0;
  transform: translate(-50%, -50%);
  border-radius: 50%;
  width: 100px;
  height: 100px;
}
</style>
