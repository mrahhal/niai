<p align="center">
  <img align="center" width="100px" height="100px" src="logo/logo.svg">
</p>

# niai

![CI](https://github.com/mrahhal/niai/workflows/CI/badge.svg)

Lookup similar Kanjis, Homonyms, Synonyms!

![snap_light](images/snap_light.png)
![snap_light](images/snap_dark.png)

This solution consists of several modules listed below.

## Modules

### Aggregator

This is a console application that incorporates several dictionaries, as well as data from [WaniKani](https://www.wanikani.com), and produces various aggregated data readily available for usage in the backend.

This is basically run only once to produce the json files. You can execute `./produce.ps1` to run this.
Note that running the aggregator can take up to 3GBs of memory.

Technology stack: .Net Core

### Niai

This is the web api that powers everything. A swagger document is also published at "/swagger".

Technology stack: Asp.Net Core

### Web

This is the website.

Technology stack: vue.js, TypeScript, scss

### Mobile

<img src="https://raw.githubusercontent.com/mrahhal/niai/dev/images/snap_mobile.png" width="300" />

<a href='https://play.google.com/store/apps/details?id=net.mrahhal.niai&pcampaignid=MKT-Other-global-all-co-prtnr-py-PartBadge-Mar2515-1'><img height="100" alt='Get it on Google Play' src='https://play.google.com/intl/en_us/badges/images/generic/en_badge_web_generic.png'/></a>

ios version coming soon.

Technology stack: flutter

## Usage

If you're trying to run the aggregator app, you should add your WK api key to an environment variable:

- `WK_INFO_API_KEY`: Your WK api key. Make sure to set this to your own api key, you can find it at https://www.wanikani.com/settings/account.

## News

- We were featured in a Tofugu article! https://www.tofugu.com/japanese/japanese-learning-resources-march-2019/

## Credit

- JMdict: http://www.edrdg.org
- KANJIDIC: http://www.edrdg.org
- KRADFILE/RADKFILE: http://www.edrdg.org
- Innocent Corpus: https://forum.koohii.com/post-168613.html#pid168613
- Logo by [@AliMzahem](https://github.com/AliMzahem)
- Old logo by [@Tobaloidee](https://github.com/Tobaloidee)
