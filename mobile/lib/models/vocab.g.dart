// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vocab.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Vocab _$VocabFromJson(Map<String, dynamic> json) {
  return Vocab()
    ..kanji = json['kanji'] as String
    ..frequency = json['frequency'] as int
    ..meanings = (json['meanings'] as List)
        ?.map((e) => e == null
            ? null
            : VocabContextualMeaning.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$VocabToJson(Vocab instance) => <String, dynamic>{
      'kanji': instance.kanji,
      'frequency': instance.frequency,
      'meanings': instance.meanings
    };

VocabContextualMeaning _$VocabContextualMeaningFromJson(
    Map<String, dynamic> json) {
  return VocabContextualMeaning()
    ..kanji = json['kanji'] as String
    ..kana = json['kana'] as String
    ..meanings = (json['meanings'] as List)?.map((e) => e as String)?.toList()
    ..tags = (json['tags'] as List)
        ?.map((e) => e == null ? null : Tag.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$VocabContextualMeaningToJson(
        VocabContextualMeaning instance) =>
    <String, dynamic>{
      'kanji': instance.kanji,
      'kana': instance.kana,
      'meanings': instance.meanings,
      'tags': instance.tags
    };
