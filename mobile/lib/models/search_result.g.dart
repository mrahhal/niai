// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'search_result.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

SearchResult _$SearchResultFromJson(Map<String, dynamic> json) {
  return SearchResult()
    ..kanjis = (json['kanjis'] as List)
        ?.map(
            (e) => e == null ? null : Kanji.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..homonyms = (json['homonyms'] as List)
        ?.map(
            (e) => e == null ? null : Vocab.fromJson(e as Map<String, dynamic>))
        ?.toList()
    ..synonyms = (json['synonyms'] as List)
        ?.map(
            (e) => e == null ? null : Vocab.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$SearchResultToJson(SearchResult instance) =>
    <String, dynamic>{
      'kanjis': instance.kanjis,
      'homonyms': instance.homonyms,
      'synonyms': instance.synonyms
    };
