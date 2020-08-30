<template>
  <div class="about-page">
    <div class="about-page-loading" v-if="loading">
      <svg-spinner></svg-spinner>
    </div>
    <template v-else>
      <div class="about-card">
        <img class="about-profile-pic" src="@/assets/mrahhal-profile.jpg">

        <div>
          Niai
          <span class="version">v{{metadata.version}}</span>
        </div>
        <div class="about-links">
          <div>
            <svg-github></svg-github>
            <a href="https://github.com/mrahhal/niai" target="_blank">GitHub</a>
          </div>
        </div>
        <hr>

        <div>
          <h4>DB Stats</h4>

          <div>Kanji: {{metadata.kanjiCount}}</div>
          <div>Vocabs: {{metadata.vocabCount}}</div>
          <div>Homonyms: {{metadata.homonymCount}}</div>
          <div>Synonyms: {{metadata.synonymCount}}</div>
        </div>
        <hr>

        <div>
          <h4>Contact</h4>

          <div>
            <a href="mailto://m.r992@hotmail.com">m.r992@hotmail.com</a>
          </div>
        </div>
        <hr>

        <div>
          <div class="mb-3">
            Donations help keep the server running, improve this app and work on new ones for Japanese, all while keeping everything ad-free. Thank you!
          </div>

          <form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
            <input type="hidden" name="cmd" value="_s-xclick" />
            <input type="hidden" name="hosted_button_id" value="Z33348GZ36RSU" />
            <input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" title="PayPal - The safer, easier way to pay online!" alt="Donate with PayPal button" />
            <img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1" height="1" />
          </form>
        </div>
      </div>
    </template>
  </div>
</template>

<script lang="ts" src="./About.ts"></script>
<style lang="scss" scoped src="./About.scss"></style>
