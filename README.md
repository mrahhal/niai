<p align="center"><img src="/logo/logotype-vertical.png"></p>

# niai

[![Build status](https://ci.appveyor.com/api/projects/status/8pcyjuyijui8o6ox?svg=true)](https://ci.appveyor.com/project/mrahhal/niai)

Lookup similar Kanjis, Homonyms, Synonyms!

![snap_light](images/snap_light.png)
![snap_light](images/snap_dark.png)

This solution consists of several modules listed below.

## Modules

### Aggregator

This is a console application that incorporates several dictionaries, as well as data from [WaniKani](https://www.wanikani.com), and produces various aggregated data readily available for usage in the backend.

This is basically run only once to produce the json files. You can execute `./produce.ps1` to produce the files.

Technology stack: .Net Core

### Niai

This is the web api that powers everything. A swagger document is also published at "/swagger".

Technology stack: Asp.Net Core

### Web

This is the website.

Technology stack: vue.js, TypeScript, scss

### Mobile

![snap_mobile](images/snap_mobile.png)

<a style="height: 200px" href='https://play.google.com/store/apps/details?id=net.mrahhal.niai&pcampaignid=MKT-Other-global-all-co-prtnr-py-PartBadge-Mar2515-1'><img alt='Get it on Google Play' src='https://play.google.com/intl/en_us/badges/images/generic/en_badge_web_generic.png'/></a>

ios version coming soon.

Technology stack: flutter

## Usage

If you're trying to run the aggregator app, you should add your WK api key to an environment variable:

- `WK_INFO_API_KEY`: Your WK api key. Make sure to set this to your own api key, you can find it at https://www.wanikani.com/settings/account.

## News

- We were featured in a Tofugu article! https://www.tofugu.com/japanese/japanese-learning-resources-march-2019/

## Credit

- JMdict: http://www.edrdg.org/enamdict/enamdict_doc.html
- KANJIDIC: http://nihongo.monash.edu/kanjidic2/index.html
- Innocent Corpus: https://forum.koohii.com/post-168613.html#pid168613
- @mwil's WK scripts: https://github.com/mwil/wanikani-userscripts
- Logo by [@Tobaloidee](https://github.com/Tobaloidee)
