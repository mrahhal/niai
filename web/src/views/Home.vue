<template>
  <div>
    <niai-search :loading="loading" @input="onSearch" ref="search"></niai-search>

    <template v-if="recentSearches.length">
      <div style="margin-top: 10px"></div>

      <div class="recent-searches">
        <span class="text-2">Recent Searches:</span>
        <div class="pl-3" v-for="search in recentSearches" :key="search">
          <a @click="setSearchValue(search)" :key="search">{{search}}</a>
        </div>
      </div>
    </template>

    <div style="margin-top: 20px"></div>

    <template v-if="result">
      <div class="similar-section similar-kanji" v-if="kanjis.length">
        <div class="similar-section-header">
          <div class="similar-section-name">Similar Kanji</div>
        </div>
        <template v-for="kanji in kanjis">
          <div class="similar-list-container" v-if="kanji.similar.length" :key="kanji.character">
            <card-list>
              <kanji-card
                v-for="kanji in [kanji, ...kanji.similar]"
                :kanji="kanji"
                :key="kanji.character"
                @navigateTo="setSearchValue($event)"
              ></kanji-card>
            </card-list>
          </div>
        </template>
      </div>

      <div class="similar-section similar-homonyms" v-if="homonyms.length">
        <div class="similar-section-header">
          <div class="similar-section-name">Homonyms</div>
          <div class="similar-section-counter">{{homonyms.length}}</div>
        </div>
        <card-list>
          <vocab-card
            v-for="(homonym, index) in homonyms"
            :vocab="homonym"
            :key="index"
            @navigateTo="setSearchValue($event)"
          ></vocab-card>
        </card-list>
      </div>

      <div class="similar-section similar-synonyms" v-if="synonyms.length">
        <div class="similar-section-header">
          <div class="similar-section-name">Synonyms</div>
          <div class="similar-section-counter">{{synonyms.length}}</div>
        </div>
        <card-list>
          <vocab-card
            v-for="(synonym, index) in synonyms"
            :vocab="synonym"
            :key="index"
            @navigateTo="setSearchValue($event)"
          ></vocab-card>
        </card-list>
      </div>
    </template>

    <template v-else-if="noResultsFound">
      <div class="no-results">
        <h1>無</h1>
        <h3>No results found</h3>
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

      <hr>

      <div class="mb-3">
        <strong>Donations help keep the server running, improve this app and work on new ones for Japanese, all while keeping everything ad-free. Thank you!</strong>
      </div>

      <form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
        <input type="hidden" name="cmd" value="_s-xclick" />
        <input type="hidden" name="hosted_button_id" value="Z33348GZ36RSU" />
        <input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif" border="0" name="submit" title="PayPal - The safer, easier way to pay online!" alt="Donate with PayPal button" />
        <img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1" height="1" />
      </form>

      <hr>

      <recent-changes></recent-changes>
    </div>
  </div>
</template>

<script lang="ts" src="./Home.ts"></script>
<style lang="scss" scoped src="./Home.scss"></style>
