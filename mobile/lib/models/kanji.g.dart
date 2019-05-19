// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'kanji.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

KanjiSummary _$KanjiSummaryFromJson(Map<String, dynamic> json) {
  return KanjiSummary()
    ..character = json['character'] as String
    ..meanings = (json['meanings'] as List)?.map((e) => e as String)?.toList();
}

Map<String, dynamic> _$KanjiSummaryToJson(KanjiSummary instance) =>
    <String, dynamic>{
      'character': instance.character,
      'meanings': instance.meanings
    };

KanjiSimilar _$KanjiSimilarFromJson(Map<String, dynamic> json) {
  return KanjiSimilar()
    ..character = json['character'] as String
    ..meanings = (json['meanings'] as List)?.map((e) => e as String)?.toList()
    ..score = (json['score'] as num)?.toDouble();
}

Map<String, dynamic> _$KanjiSimilarToJson(KanjiSimilar instance) =>
    <String, dynamic>{
      'character': instance.character,
      'meanings': instance.meanings,
      'score': instance.score
    };

Kanji _$KanjiFromJson(Map<String, dynamic> json) {
  return Kanji()
    ..character = json['character'] as String
    ..meanings = (json['meanings'] as List)?.map((e) => e as String)?.toList()
    ..similar = (json['similar'] as List)
        ?.map((e) =>
            e == null ? null : KanjiSimilar.fromJson(e as Map<String, dynamic>))
        ?.toList();
}

Map<String, dynamic> _$KanjiToJson(Kanji instance) => <String, dynamic>{
      'character': instance.character,
      'meanings': instance.meanings,
      'similar': instance.similar
    };
